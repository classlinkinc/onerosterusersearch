namespace OneRosterUserSearch
{
    partial class CredentialManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CredentialManager));
            this.credDataView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedCredential = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.credDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // credDataView
            // 
            this.credDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.credDataView.Location = new System.Drawing.Point(12, 12);
            this.credDataView.Name = "credDataView";
            this.credDataView.Size = new System.Drawing.Size(692, 316);
            this.credDataView.TabIndex = 0;
            this.credDataView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.credDataView_CellEnter);
            this.credDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.credDataView_CellContentClick);
            this.credDataView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.credDataView_CellLeave);
            this.credDataView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellChanged);
            this.credDataView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.credDataView_RowsAdded);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected Credentials: ";
            // 
            // selectedCredential
            // 
            this.selectedCredential.AutoSize = true;
            this.selectedCredential.Location = new System.Drawing.Point(125, 345);
            this.selectedCredential.Name = "selectedCredential";
            this.selectedCredential.Size = new System.Drawing.Size(0, 13);
            this.selectedCredential.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(629, 340);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // CredentialManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 375);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.selectedCredential);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.credDataView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CredentialManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credential Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CredentialManager_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.credDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView credDataView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectedCredential;
        private System.Windows.Forms.Button saveBtn;
    }
}