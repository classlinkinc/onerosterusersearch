using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using OneRosterUserSearch.Objects;

namespace OneRosterUserSearch
{
    public partial class CredentialManager : Form
    {
        public CredentialManager(string initKey, string initSecret)
        {
            InitializeComponent();

            SelectedKey = initKey;
            SelectedSecret = initSecret;

            var alias = new DataGridViewTextBoxColumn()
            {
                Name = "Alias"
            };
            var keyCol = new DataGridViewTextBoxColumn()
            {
                Name = "Key"
            };
            var secrCol = new DataGridViewTextBoxColumn()
            {
                Name = "Secret"
            };
            var selectCol = new DataGridViewButtonColumn()
            {
                Name = "",
            };
            var delCol = new DataGridViewButtonColumn()
            {
                Name = ""
            };

            credDataView.Columns.AddRange(alias, keyCol, secrCol, selectCol, delCol);
            credDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            credDataView.BackgroundColor = Color.White;
            credDataView.RowHeadersVisible = false;

            loadCreds();
            updateSelected();
            _promptSave = false;
        }

        public string SelectedKey;
        public string SelectedSecret;
        private const int UseCol = 3;
        private const int DelCol = 4;
        private bool _promptSave;

        private void loadCreds()
        {
            var credList = getCredentialList();
            credDataView.Rows.Clear();
            foreach (Credentials cred in credList)
            {
                if (string.IsNullOrEmpty(cred.alias) && string.IsNullOrEmpty(cred.key) && string.IsNullOrEmpty(cred.secret)) continue;
                var row = new DataGridViewRow { Resizable = DataGridViewTriState.False };
                var alias = new DataGridViewTextBoxCell();
                var rowKey = new DataGridViewTextBoxCell();
                var rowSec = new DataGridViewTextBoxCell();
                var selectBtn = new DataGridViewButtonCell();
                var delBtn = new DataGridViewButtonCell();
                row.Cells.AddRange(alias, rowKey, rowSec, selectBtn, delBtn);
                row.Cells[0].Value = cred.alias;
                row.Cells[1].Value = cred.key;
                row.Cells[2].Value = cred.secret;
                row.Cells[UseCol].Value = "USE";
                row.Cells[DelCol].Value = "REMOVE";
                credDataView.Rows.Add(row);
            }
        }

        private void credDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0 ||
                e.RowIndex >= senderGrid.RowCount - 1) return;
            try
            {
                switch (e.ColumnIndex)
                {
                    case UseCol:
                        SelectedKey = senderGrid.Rows[e.RowIndex].Cells[1].Value?.ToString();
                        SelectedSecret = senderGrid.Rows[e.RowIndex].Cells[2].Value?.ToString();
                        selectedCredential.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value?.ToString();
                        Close();
                        break;
                    case DelCol:
                        if (
                            MessageBox.Show(@"Are you sure you want to remove?", @"Remove Credentials",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            credDataView.Rows.RemoveAt(e.RowIndex);
                            _promptSave = true;
                        }
                        
                        break;
                        // do nothing
                }
                
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void credDataView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _promptSave = true;
            credDataView.Rows[credDataView.RowCount - 1].Cells[3].Value = "USE";
            credDataView.Rows[credDataView.RowCount - 1].Cells[4].Value = "REMOVE";
            credDataView.Rows[credDataView.RowCount - 1].Resizable = DataGridViewTriState.False;
        }

        private void updateSelected()
        {
            foreach (DataGridViewRow row in credDataView.Rows)
            {
                if (!string.Equals(row.Cells[1].Value?.ToString(), SelectedKey) ||
                    !string.Equals(row.Cells[2].Value?.ToString(), SelectedSecret)) continue;
                selectedCredential.Text = row.Cells[0].Value.ToString();
                break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveCredentials();
        }

        private void saveCredentials()
        {
            var credList = (from DataGridViewRow row in credDataView.Rows
                select new Credentials
                {
                    alias = row.Cells[0].Value?.ToString(), key = row.Cells[1].Value?.ToString(), secret = row.Cells[2].Value?.ToString()
                }).ToList();
            var savePath = Path.Combine(Main.getFolderPath(), "Credentials.txt");
            

            try
            {
                using (TextWriter tw = new StreamWriter(savePath))
                {
                    tw.Write(StringCipher.encrypt(JsonConvert.SerializeObject(credList), StringCipher.getKey()));
                    MessageBox.Show(@"Credentials Saved");
                    _promptSave = false;
                }
            }
            catch (IOException e)
            {
                // something happened?
                MessageBox.Show(e.Message);
            }
        }

        private static IEnumerable<Credentials> getCredentialList()
        {
            try
            {
                // Get syncInfo from file, written by GroupSync WebAPI
                using (var tr = new StreamReader(Path.Combine(Main.getFolderPath(), "Credentials.txt")))
                {
                    return JsonConvert.DeserializeObject<List<Credentials>>(StringCipher.decrypt(tr.ReadToEnd(), StringCipher.getKey()));
                }
                    
            }
            catch (Exception)
            {
                return new List<Credentials>();
            }
        }

        private void cellChanged(object sender, DataGridViewCellEventArgs e)
        {
            _promptSave = true;
        }

        private void CredentialManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_promptSave && MessageBox.Show(@"Credentials Changed. Save?", @"Remove Credentials", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveCredentials();
            }
        }

        private string _cellData;
        private void credDataView_CellEnter(object sender, DataGridViewCellCancelEventArgs e)
        {
            var gridView = (DataGridView)sender;
            _cellData = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            _promptSave = true;
        }

        private void credDataView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var gridView = (DataGridView)sender;
            var tempData = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            _promptSave = !string.Equals(tempData, _cellData);
            _cellData = string.Empty;
        }
    }
}
