namespace DVLD.Tests.Appointments.Street_Test
{
    partial class frmStreetTestAppointment
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
            this.ctrlScheduleTest1 = new DVLD.Tests.ctrlScheduleTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlScheduleTest1
            // 
            this.ctrlScheduleTest1.Location = new System.Drawing.Point(1, 2);
            this.ctrlScheduleTest1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            this.ctrlScheduleTest1.Size = new System.Drawing.Size(400, 580);
            this.ctrlScheduleTest1.TabIndex = 55617;
            this.ctrlScheduleTest1.TestType = DVLD_Business.clsTestType.enTestType.VisionTest;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(290, 586);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 28);
            this.btnClose.TabIndex = 55616;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStreetTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 617);
            this.Controls.Add(this.ctrlScheduleTest1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmStreetTestAppointment";
            this.Text = "frmStreetTestAppointment";
            this.Load += new System.EventHandler(this.frmStreetTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ctrlScheduleTest ctrlScheduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}