using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OneRosterOAuth;
using OneRosterUserSearch.Objects;

namespace OneRosterUserSearch
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Initialize UserGridView
            var value = new DataGridViewTextBoxColumn()
            {
                Name = "Value"
            };
            var property = new DataGridViewTextBoxColumn()
            {
                Name = "Property"
            };

            value.SortMode = DataGridViewColumnSortMode.NotSortable;
            property.SortMode = DataGridViewColumnSortMode.NotSortable;
            userDisplay.Columns.AddRange(property, value);
            userDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            userDisplay.BackgroundColor = Color.White;
            userDisplay.RowHeadersVisible = false;

            // Initialize ClassGridView
            var classId = new DataGridViewTextBoxColumn()
            {
                Name = "Class ID"
            };
            var className = new DataGridViewTextBoxColumn()
            {
                Name = "Class Name"
            };
            var courseId = new DataGridViewTextBoxColumn()
            {
                Name = "Course ID"
            };
            var org = new DataGridViewTextBoxColumn()
            {
                Name = "Org"
            };
            var teacherName = new DataGridViewTextBoxColumn()
            {
                Name = "Teacher Name"
            };
            className.SortMode = DataGridViewColumnSortMode.NotSortable;
            teacherName.SortMode = DataGridViewColumnSortMode.NotSortable;
            classId.SortMode = DataGridViewColumnSortMode.NotSortable;
            courseId.SortMode = DataGridViewColumnSortMode.NotSortable;
            org.SortMode = DataGridViewColumnSortMode.NotSortable;

            classDisplay.Columns.AddRange(classId, className, courseId, org, teacherName);
            classDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            classDisplay.BackgroundColor = Color.White;
            classDisplay.RowHeadersVisible = false;

            loadUrl();
        }

        private OneRosterConnection _oneRoster;
        private string _oneRosterUrl;
        private string _oneRosterKey;
        private string _oneRosterSecret;
        private string _studentUsername;
        private OneRoster _oneRosterUser;
        private Loading _loadingForm;

        private bool getCredentials()
        {
            if (oneRosterUrl.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter your OneRoster Server's Url");
                return false;
            }
            if (oneRosterKey.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter your OneRoster Server API Key");
                return false;
            }
            if (oneRosterSecret.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter your OneRoster Server API Secret");
                return false;
            }

            _oneRosterUrl = oneRosterUrl.Text.Trim().TrimEnd('/');
            _oneRosterKey = oneRosterKey.Text.Trim();
            _oneRosterSecret = oneRosterSecret.Text.Trim();
            return true;
        }

        private void userSearchBtn_Click(object sender, EventArgs e)
        {
            // user didn't fill out all credentials
            if (!getCredentials())
            {
                return;
            }

            if (userSearch.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the username to search for");
                return;
            }
            _studentUsername = userSearch.Text.Trim();

            userSearchBtn.Enabled = false;
            userSearchWorker.RunWorkerAsync();
            _loadingForm = new Loading();
            _loadingForm.Show();
        }

        
        private void userSearchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _oneRoster = new OneRosterConnection(_oneRosterKey, _oneRosterSecret);
            var filter = _oneRoster.urlEncode($"username='{_studentUsername}'");
            var userUrl = $"{_oneRosterUrl}/users?filter={filter}";

            var getTask = _oneRoster.makeRequest(userUrl);
            Task.WaitAll(getTask);
            HttpResponseMessage response = getTask.Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($@"Bad Request: {response.Content}");
            }
            var readResult = response.Content.ReadAsStringAsync();
            Task.WaitAll(readResult);
            var oneRosterUserList = JsonConvert.DeserializeObject<OneRosterUserList>(readResult.Result);
            if (oneRosterUserList.oneRosterUserList.Count == 0)
            {
                MessageBox.Show($@"No user with username {_studentUsername} found");
            }
            _oneRosterUser = oneRosterUserList.oneRosterUserList[0];
            var oneRosterDict = _oneRosterUser.toDictionary();
            Invoke(new Action(() =>
            {
                populateUserDisplay(oneRosterDict);
            }));

            // get class list for student

            var classUrl = $"{_oneRosterUrl}/users/{_oneRoster.urlEncode(_oneRosterUser.sourcedId)}/classes";
            getTask = _oneRoster.makeRequest(classUrl);
            Task.WaitAll(getTask);
            response = getTask.Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($@"Bad Request Classes: {response.StatusCode}");
            }
            readResult = response.Content.ReadAsStringAsync();
            Task.WaitAll(readResult);
            var classList = JsonConvert.DeserializeObject<ClassList>(readResult.Result);
            var classDisplayList = new List<List<object>>();
            foreach (Class _class in classList.classList)
            {
                var teacherUrl = $"{_oneRosterUrl}/classes/{_oneRoster.urlEncode(_class.sourcedId)}/teachers";
                getTask = _oneRoster.makeRequest(teacherUrl);
                Task.WaitAll(getTask);
                response = getTask.Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show($@"Bad Request Teachers: {response.StatusCode}");
                }
                readResult = response.Content.ReadAsStringAsync();
                Task.WaitAll(readResult);
                _class.teacherList = JsonConvert.DeserializeObject<OneRosterUserList>(readResult.Result);
                var classDisplayObj = new List<object>
                {
                    _class.sourcedId,
                    _class.title,
                    _class.courseObject.sourcedId,
                    _class.schoolObject.sourcedId,
                    string.Join(",",_class.teacherList.oneRosterUserList.Select(teacher => $"{teacher.givenName} {teacher.familyName}").ToArray())
            };
                classDisplayList.Add(classDisplayObj);
            }

            Invoke(new Action(() =>
            {
                populateClassDisplay(classDisplayList);
            }));
        }

        private void populateUserDisplay(IDictionary<string, object> inputDictionary)
        {
            userDisplay.Rows.Clear();
            userDisplay.Rows.AddRange(inputDictionary.Select(kvp =>
            {
                var row = new DataGridViewRow();
                row.CreateCells(userDisplay, kvp.Key, kvp.Value);
                row.ReadOnly = true;
                return row;
            }).ToArray());
        }

        private void populateClassDisplay(IEnumerable<List<object>> inputList)
        {
            classDisplay.Rows.Clear();
            classDisplay.Rows.AddRange(inputList.Select(index =>
            {
                var row = new DataGridViewRow();
                row.CreateCells(classDisplay, index[0], index[1], index[2], index[3], index[4]);
                row.ReadOnly = true;
                return row;
            }).ToArray());
        }

        private void userSearchWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                userSearchBtn.Enabled = true;
                _loadingForm.Close();
            }));
            
        }

        private void credentialBtn_click(object sender, EventArgs e)
        {
            using (var credentials = new CredentialManager(oneRosterKey.Text, oneRosterSecret.Text))
            {
                credentials.ShowDialog();
                oneRosterKey.Text = credentials.SelectedKey;
                oneRosterSecret.Text = credentials.SelectedSecret;
                credentials.Close();
            }
                
        }

        public static string getFolderPath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "OneRosterStudentSchedule");
            Directory.CreateDirectory(path);
            return path;
        }

        private void saveUrlBtn_Click(object sender, EventArgs e)
        {
            var savePath = Path.Combine(getFolderPath(), "OneRosterURL.txt");
            try
            {
                using (TextWriter tw = new StreamWriter(savePath))
                {
                    tw.Write(StringCipher.encrypt(oneRosterUrl.Text.Trim(), StringCipher.getKey()));
                    MessageBox.Show(@"URL Saved");
                }
            }
            catch (IOException a)
            {
                // something happened?
                MessageBox.Show(a.Message);
            }
        }

        private void loadUrl()
        {
            try
            {
                // Get syncInfo from file, written by GroupSync WebAPI
                using (var tr = new StreamReader(Path.Combine(getFolderPath(), "OneRosterURL.txt")))
                {
                    oneRosterUrl.Text = StringCipher.decrypt(tr.ReadToEnd(), StringCipher.getKey());
                }

            }
            catch (Exception)
            {
                oneRosterUrl.Text = "";
            }
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            testBtn.Enabled = false;
            if (!getCredentials())
            {
                testBtn.Enabled = true;
                return;
            }
            credTestWorker.RunWorkerAsync();
            
            
        }

        private void credTestWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _oneRoster = new OneRosterConnection(_oneRosterKey, _oneRosterSecret);
            var getTask = _oneRoster.makeRequest($"{_oneRosterUrl}/users?fields=sourcedId&offset=0&limit=1&sort=sourcedId");
            Task.WaitAll(getTask);
            HttpResponseMessage response = getTask.Result;
            MessageBox.Show(response.StatusCode != HttpStatusCode.OK
                ? $@"Bad Request: {response.StatusCode}"
                : @"Authorization Success");
        }

        private void credTestWorker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                testBtn.Enabled = true;
            }));
        }

    }
}
