namespace DVLD.Application
{
    partial class frmAddEditLocalDrivingLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.personDetailsWithFilters1 = new DVLD.People.Controls.PersonDetailsWithFilters();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.lApplicationFee = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lCreatedBy = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.llApplicationDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabControl1.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPersonalInfo);
            this.tabControl1.Controls.Add(this.tpApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(2, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 424);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Controls.Add(this.personDetailsWithFilters1);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(807, 398);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(664, 358);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(123, 35);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // personDetailsWithFilters1
            // 
            this.personDetailsWithFilters1.FilterEnabled = true;
            this.personDetailsWithFilters1.Location = new System.Drawing.Point(3, 6);
            this.personDetailsWithFilters1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.personDetailsWithFilters1.Name = "personDetailsWithFilters1";
            this.personDetailsWithFilters1.Size = new System.Drawing.Size(794, 347);
            this.personDetailsWithFilters1.TabIndex = 9;
            this.personDetailsWithFilters1.Load += new System.EventHandler(this.personDetailsWithFilters1_Load);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.lApplicationFee);
            this.tpApplicationInfo.Controls.Add(this.lCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.llApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.lID);
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel4);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel3);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel2);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel1);
            this.tpApplicationInfo.Controls.Add(this.guna2HtmlLabel5);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(807, 398);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // lApplicationFee
            // 
            this.lApplicationFee.BackColor = System.Drawing.Color.Transparent;
            this.lApplicationFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApplicationFee.Location = new System.Drawing.Point(284, 179);
            this.lApplicationFee.Name = "lApplicationFee";
            this.lApplicationFee.Size = new System.Drawing.Size(21, 20);
            this.lApplicationFee.TabIndex = 13;
            this.lApplicationFee.Text = "??";
            // 
            // lCreatedBy
            // 
            this.lCreatedBy.BackColor = System.Drawing.Color.Transparent;
            this.lCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCreatedBy.Location = new System.Drawing.Point(284, 217);
            this.lCreatedBy.Name = "lCreatedBy";
            this.lCreatedBy.Size = new System.Drawing.Size(21, 20);
            this.lCreatedBy.TabIndex = 12;
            this.lCreatedBy.Text = "??";
            // 
            // llApplicationDate
            // 
            this.llApplicationDate.BackColor = System.Drawing.Color.Transparent;
            this.llApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llApplicationDate.Location = new System.Drawing.Point(284, 103);
            this.llApplicationDate.Name = "llApplicationDate";
            this.llApplicationDate.Size = new System.Drawing.Size(21, 20);
            this.llApplicationDate.TabIndex = 11;
            this.llApplicationDate.Text = "??";
            // 
            // lID
            // 
            this.lID.BackColor = System.Drawing.Color.Transparent;
            this.lID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lID.Location = new System.Drawing.Point(284, 65);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(21, 20);
            this.lID.TabIndex = 10;
            this.lID.Text = "??";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(284, 141);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(121, 21);
            this.cbLicenseClass.TabIndex = 0;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(89, 103);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(130, 20);
            this.guna2HtmlLabel4.TabIndex = 8;
            this.guna2HtmlLabel4.Text = "Application Date:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(89, 141);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(114, 20);
            this.guna2HtmlLabel3.TabIndex = 7;
            this.guna2HtmlLabel3.Text = "License Class:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(89, 179);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(132, 20);
            this.guna2HtmlLabel2.TabIndex = 6;
            this.guna2HtmlLabel2.Text = "Application Fees:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(89, 217);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(91, 20);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "Created By:";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(89, 65);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(142, 20);
            this.guna2HtmlLabel5.TabIndex = 4;
            this.guna2HtmlLabel5.Text = "D.L.Application ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(543, 485);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(670, 485);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lFormTitle
            // 
            this.lFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lFormTitle.Location = new System.Drawing.Point(130, 20);
            this.lFormTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lFormTitle.Name = "lFormTitle";
            this.lFormTitle.Size = new System.Drawing.Size(536, 35);
            this.lFormTitle.TabIndex = 8;
            this.lFormTitle.Text = "New Local Driving License Application";
            // 
            // frmAddEditLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 526);
            this.Controls.Add(this.lFormTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditLocalDrivingLicenseApplication";
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.frmAddEditLocalDrivingLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private Guna.UI2.WinForms.Guna2HtmlLabel lFormTitle;
        private System.Windows.Forms.Button btnNext;
        private People.Controls.PersonDetailsWithFilters personDetailsWithFilters1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel llApplicationDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lID;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lApplicationFee;
        private Guna.UI2.WinForms.Guna2HtmlLabel lCreatedBy;
    }
}