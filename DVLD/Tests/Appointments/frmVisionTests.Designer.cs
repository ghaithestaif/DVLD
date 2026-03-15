namespace DVLD.Tests
{
    partial class frmVisionTests
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AppointmentGridView = new System.Windows.Forms.DataGridView();
            this.txtNumberOfRecords = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewUserButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.crtApplicationInfo2 = new DVLD.Application.Controls.crtApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(328, 131);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(383, 38);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Vision Test Appointment";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // AppointmentGridView
            // 
            this.AppointmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentGridView.Location = new System.Drawing.Point(12, 707);
            this.AppointmentGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AppointmentGridView.MultiSelect = false;
            this.AppointmentGridView.Name = "AppointmentGridView";
            this.AppointmentGridView.ReadOnly = true;
            this.AppointmentGridView.RowHeadersWidth = 51;
            this.AppointmentGridView.RowTemplate.Height = 24;
            this.AppointmentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppointmentGridView.Size = new System.Drawing.Size(972, 133);
            this.AppointmentGridView.TabIndex = 23;
            // 
            // txtNumberOfRecords
            // 
            this.txtNumberOfRecords.AutoSize = false;
            this.txtNumberOfRecords.BackColor = System.Drawing.Color.Transparent;
            this.txtNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfRecords.Location = new System.Drawing.Point(119, 861);
            this.txtNumberOfRecords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumberOfRecords.Name = "txtNumberOfRecords";
            this.txtNumberOfRecords.Size = new System.Drawing.Size(96, 23);
            this.txtNumberOfRecords.TabIndex = 25;
            this.txtNumberOfRecords.TabStop = false;
            this.txtNumberOfRecords.Text = null;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(12, 861);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(91, 23);
            this.guna2HtmlLabel3.TabIndex = 24;
            this.guna2HtmlLabel3.Text = "Records:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(804, 845);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 44);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewUserButton
            // 
            this.btnAddNewUserButton.Animated = true;
            this.btnAddNewUserButton.AutoRoundedCorners = true;
            this.btnAddNewUserButton.BackgroundImage = global::DVLD.Properties.Resources.AddAppointment_32;
            this.btnAddNewUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewUserButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.btnAddNewUserButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewUserButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewUserButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewUserButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewUserButton.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewUserButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewUserButton.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUserButton.Location = new System.Drawing.Point(890, 644);
            this.btnAddNewUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNewUserButton.Name = "btnAddNewUserButton";
            this.btnAddNewUserButton.Size = new System.Drawing.Size(81, 58);
            this.btnAddNewUserButton.TabIndex = 22;
            this.btnAddNewUserButton.Click += new System.EventHandler(this.btnAddNewUserButton_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD.Properties.Resources.Vision_512;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(375, 11);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(185, 114);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 16;
            this.guna2PictureBox1.TabStop = false;
            // 
            // crtApplicationInfo2
            // 
            this.crtApplicationInfo2.Location = new System.Drawing.Point(12, 166);
            this.crtApplicationInfo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crtApplicationInfo2.Name = "crtApplicationInfo2";
            this.crtApplicationInfo2.Size = new System.Drawing.Size(943, 478);
            this.crtApplicationInfo2.TabIndex = 27;
            // 
            // frmVisionTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 892);
            this.Controls.Add(this.crtApplicationInfo2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNumberOfRecords);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.AppointmentGridView);
            this.Controls.Add(this.btnAddNewUserButton);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmVisionTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vision Tests";
            this.Load += new System.EventHandler(this.frmVisionTests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Application.Controls.crtApplicationInfo crtApplicationInfo1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnAddNewUserButton;
        private System.Windows.Forms.DataGridView AppointmentGridView;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtNumberOfRecords;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private System.Windows.Forms.Button btnClose;
        private Application.Controls.crtApplicationInfo crtApplicationInfo2;
    }
}