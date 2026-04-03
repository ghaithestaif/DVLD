namespace DVLD.DetainLicense
{
    partial class frmDetainLicenseList
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
            this.components = new System.ComponentModel.Container();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNumberOfRecords = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvDetainLicenseList = new System.Windows.Forms.DataGridView();
            this.cbYesNo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnReleaseLicense = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLicenseList)).BeginInit();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FillColor = System.Drawing.Color.Silver;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilter.ItemHeight = 20;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "FullName",
            ""});
            this.cbFilter.Location = new System.Drawing.Point(67, 216);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(137, 26);
            this.cbFilter.TabIndex = 27;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(8, 219);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(54, 18);
            this.guna2HtmlLabel2.TabIndex = 26;
            this.guna2HtmlLabel2.Text = "FilterBy:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(457, 190);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(162, 27);
            this.guna2HtmlLabel1.TabIndex = 24;
            this.guna2HtmlLabel1.Text = "Detain Licenses";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // txtNumberOfRecords
            // 
            this.txtNumberOfRecords.AutoSize = false;
            this.txtNumberOfRecords.BackColor = System.Drawing.Color.Transparent;
            this.txtNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfRecords.Location = new System.Drawing.Point(80, 504);
            this.txtNumberOfRecords.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumberOfRecords.Name = "txtNumberOfRecords";
            this.txtNumberOfRecords.Size = new System.Drawing.Size(72, 18);
            this.txtNumberOfRecords.TabIndex = 31;
            this.txtNumberOfRecords.TabStop = false;
            this.txtNumberOfRecords.Text = null;
            // 
            // txtFilter
            // 
            this.txtFilter.Animated = true;
            this.txtFilter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtFilter.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DefaultText = "";
            this.txtFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.Enabled = false;
            this.txtFilter.FillColor = System.Drawing.Color.Silver;
            this.txtFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Location = new System.Drawing.Point(207, 216);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderText = "";
            this.txtFilter.SelectedText = "";
            this.txtFilter.Size = new System.Drawing.Size(105, 27);
            this.txtFilter.TabIndex = 30;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(8, 504);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(68, 18);
            this.guna2HtmlLabel3.TabIndex = 29;
            this.guna2HtmlLabel3.Text = "Records:";
            // 
            // dgvDetainLicenseList
            // 
            this.dgvDetainLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainLicenseList.ContextMenuStrip = this.cmsApplications;
            this.dgvDetainLicenseList.Location = new System.Drawing.Point(8, 250);
            this.dgvDetainLicenseList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetainLicenseList.MultiSelect = false;
            this.dgvDetainLicenseList.Name = "dgvDetainLicenseList";
            this.dgvDetainLicenseList.ReadOnly = true;
            this.dgvDetainLicenseList.RowHeadersWidth = 51;
            this.dgvDetainLicenseList.RowTemplate.Height = 24;
            this.dgvDetainLicenseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainLicenseList.Size = new System.Drawing.Size(1063, 242);
            this.dgvDetainLicenseList.TabIndex = 28;
            // 
            // cbYesNo
            // 
            this.cbYesNo.BackColor = System.Drawing.Color.Transparent;
            this.cbYesNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbYesNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYesNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYesNo.Enabled = false;
            this.cbYesNo.FillColor = System.Drawing.Color.Silver;
            this.cbYesNo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbYesNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbYesNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbYesNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbYesNo.ItemHeight = 20;
            this.cbYesNo.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbYesNo.Location = new System.Drawing.Point(207, 216);
            this.cbYesNo.Margin = new System.Windows.Forms.Padding(2);
            this.cbYesNo.Name = "cbYesNo";
            this.cbYesNo.Size = new System.Drawing.Size(137, 26);
            this.cbYesNo.TabIndex = 33;
            this.cbYesNo.Visible = false;
            this.cbYesNo.SelectedIndexChanged += new System.EventHandler(this.cbYesNo_SelectedIndexChanged);
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseToolStripMenuItem,
            this.releaseLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(242, 140);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Animated = true;
            this.btnReleaseLicense.AutoRoundedCorners = true;
            this.btnReleaseLicense.BackgroundImage = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.btnReleaseLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReleaseLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReleaseLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReleaseLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReleaseLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReleaseLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReleaseLicense.ForeColor = System.Drawing.Color.White;
            this.btnReleaseLicense.Location = new System.Drawing.Point(945, 190);
            this.btnReleaseLicense.Margin = new System.Windows.Forms.Padding(2);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(61, 47);
            this.btnReleaseLicense.TabIndex = 32;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD.Properties.Resources.Detain_512;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(426, 16);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(202, 169);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 23;
            this.guna2PictureBox1.TabStop = false;
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showLicenseToolStripMenuItem.Text = "Show &License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseLicenseToolStripMenuItem
            // 
            this.releaseLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_322;
            this.releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            this.releaseLicenseToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.releaseLicenseToolStripMenuItem.Text = "Release License";
            this.releaseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseLicenseToolStripMenuItem_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Animated = true;
            this.btnDetainLicense.AutoRoundedCorners = true;
            this.btnDetainLicense.BackgroundImage = global::DVLD.Properties.Resources.Detain_321;
            this.btnDetainLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetainLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetainLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetainLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.Location = new System.Drawing.Point(1010, 190);
            this.btnDetainLicense.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(61, 47);
            this.btnDetainLicense.TabIndex = 25;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // frmDetainLicenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 539);
            this.Controls.Add(this.cbYesNo);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.txtNumberOfRecords);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.dgvDetainLicenseList);
            this.Controls.Add(this.btnDetainLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDetainLicenseList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDetainLicenseList";
            this.Load += new System.EventHandler(this.frmDetainLicenseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLicenseList)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtNumberOfRecords;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private System.Windows.Forms.DataGridView dgvDetainLicenseList;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicense;
        private Guna.UI2.WinForms.Guna2Button btnReleaseLicense;
        private Guna.UI2.WinForms.Guna2ComboBox cbYesNo;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseLicenseToolStripMenuItem;
    }
}