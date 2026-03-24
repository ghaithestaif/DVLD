namespace DVLD.Application
{
    partial class frmApplicationInfo
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
            this.crtApplicationInfo1 = new DVLD.Application.Controls.crtApplicationInfo();
            this.SuspendLayout();
            // 
            // crtApplicationInfo1
            // 
            this.crtApplicationInfo1.Location = new System.Drawing.Point(12, 11);
            this.crtApplicationInfo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crtApplicationInfo1.Name = "crtApplicationInfo1";
            this.crtApplicationInfo1.Size = new System.Drawing.Size(943, 478);
            this.crtApplicationInfo1.TabIndex = 0;
            // 
            // frmApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 506);
            this.Controls.Add(this.crtApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmApplicationInfo";
            this.Text = "frmApplicationInfo";
            this.Load += new System.EventHandler(this.frmApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.crtApplicationInfo crtApplicationInfo1;
    }
}