namespace OneRosterUserSearch
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.oneRosterUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.oneRosterSecret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.oneRosterKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userSearchBtn = new System.Windows.Forms.Button();
            this.userSearchWorker = new System.ComponentModel.BackgroundWorker();
            this.userDisplay = new System.Windows.Forms.DataGridView();
            this.classDisplay = new System.Windows.Forms.DataGridView();
            this.credentialBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveUrlBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.credTestWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.userDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // oneRosterUrl
            // 
            this.oneRosterUrl.Location = new System.Drawing.Point(119, 12);
            this.oneRosterUrl.Name = "oneRosterUrl";
            this.oneRosterUrl.Size = new System.Drawing.Size(365, 20);
            this.oneRosterUrl.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "OneRoster URL:";
            // 
            // oneRosterSecret
            // 
            this.oneRosterSecret.Location = new System.Drawing.Point(119, 64);
            this.oneRosterSecret.Name = "oneRosterSecret";
            this.oneRosterSecret.Size = new System.Drawing.Size(365, 20);
            this.oneRosterSecret.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "OneRoster Secret:";
            // 
            // oneRosterKey
            // 
            this.oneRosterKey.Location = new System.Drawing.Point(119, 38);
            this.oneRosterKey.Name = "oneRosterKey";
            this.oneRosterKey.Size = new System.Drawing.Size(365, 20);
            this.oneRosterKey.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "OneRoster Key:";
            // 
            // userSearch
            // 
            this.userSearch.Location = new System.Drawing.Point(119, 90);
            this.userSearch.Name = "userSearch";
            this.userSearch.Size = new System.Drawing.Size(284, 20);
            this.userSearch.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Student Username:";
            // 
            // userSearchBtn
            // 
            this.userSearchBtn.Location = new System.Drawing.Point(409, 90);
            this.userSearchBtn.Name = "userSearchBtn";
            this.userSearchBtn.Size = new System.Drawing.Size(75, 20);
            this.userSearchBtn.TabIndex = 6;
            this.userSearchBtn.Text = "Search";
            this.userSearchBtn.UseVisualStyleBackColor = true;
            this.userSearchBtn.Click += new System.EventHandler(this.userSearchBtn_Click);
            // 
            // userSearchWorker
            // 
            this.userSearchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.userSearchWorker_DoWork);
            this.userSearchWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.userSearchWorker_Complete);
            // 
            // userDisplay
            // 
            this.userDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDisplay.Location = new System.Drawing.Point(12, 137);
            this.userDisplay.Name = "userDisplay";
            this.userDisplay.Size = new System.Drawing.Size(472, 385);
            this.userDisplay.TabIndex = 18;
            // 
            // classDisplay
            // 
            this.classDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classDisplay.Location = new System.Drawing.Point(490, 137);
            this.classDisplay.Name = "classDisplay";
            this.classDisplay.Size = new System.Drawing.Size(309, 385);
            this.classDisplay.TabIndex = 19;
            // 
            // credentialBtn
            // 
            this.credentialBtn.Location = new System.Drawing.Point(647, 12);
            this.credentialBtn.Name = "credentialBtn";
            this.credentialBtn.Size = new System.Drawing.Size(152, 42);
            this.credentialBtn.TabIndex = 7;
            this.credentialBtn.Text = "Credential Manager";
            this.credentialBtn.UseVisualStyleBackColor = true;
            this.credentialBtn.Click += new System.EventHandler(this.credentialBtn_click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(487, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Student Schedule";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Student Details";
            // 
            // saveUrlBtn
            // 
            this.saveUrlBtn.Location = new System.Drawing.Point(490, 12);
            this.saveUrlBtn.Name = "saveUrlBtn";
            this.saveUrlBtn.Size = new System.Drawing.Size(75, 20);
            this.saveUrlBtn.TabIndex = 2;
            this.saveUrlBtn.Text = "Save URL";
            this.saveUrlBtn.UseVisualStyleBackColor = true;
            this.saveUrlBtn.Click += new System.EventHandler(this.saveUrlBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(491, 38);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 46);
            this.testBtn.TabIndex = 23;
            this.testBtn.Text = "Test Credentials";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // credTestWorker
            // 
            this.credTestWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.credTestWorker_DoWork);
            this.credTestWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.credTestWorker_RunWorkerComplete);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(811, 534);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.saveUrlBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.credentialBtn);
            this.Controls.Add(this.classDisplay);
            this.Controls.Add(this.userDisplay);
            this.Controls.Add(this.userSearchBtn);
            this.Controls.Add(this.userSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.oneRosterUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oneRosterSecret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oneRosterKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OneRoster User Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.userDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oneRosterUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oneRosterSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oneRosterKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button userSearchBtn;
        private System.ComponentModel.BackgroundWorker userSearchWorker;
        private System.Windows.Forms.DataGridView userDisplay;
        private System.Windows.Forms.DataGridView classDisplay;
        private System.Windows.Forms.Button credentialBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveUrlBtn;
        private System.Windows.Forms.Button testBtn;
        private System.ComponentModel.BackgroundWorker credTestWorker;
    }
}

