namespace DVLD.License
{
    partial class frmDriverLicenseHistory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Local = new System.Windows.Forms.TabControl();
            this.tabControl1 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternation = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.personDetailsWithFilters1 = new DVLD.People.Controls.PersonDetailsWithFilters();
            this.groupBox1.SuspendLayout();
            this.Local.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Local);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 344);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // Local
            // 
            this.Local.Controls.Add(this.tabControl1);
            this.Local.Controls.Add(this.tabPage1);
            this.Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local.Location = new System.Drawing.Point(22, 31);
            this.Local.Name = "Local";
            this.Local.SelectedIndex = 0;
            this.Local.Size = new System.Drawing.Size(992, 295);
            this.Local.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.label1);
            this.tabControl1.Controls.Add(this.dgvLocal);
            this.tabControl1.Location = new System.Drawing.Point(4, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl1.Size = new System.Drawing.Size(984, 264);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Text = "Local";
            this.tabControl1.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInternation);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(984, 264);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "International";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLocal
            // 
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.Location = new System.Drawing.Point(6, 88);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.Size = new System.Drawing.Size(972, 150);
            this.dgvLocal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local License History";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "International Licenses History";
            // 
            // dgvInternation
            // 
            this.dgvInternation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternation.Location = new System.Drawing.Point(6, 92);
            this.dgvInternation.Name = "dgvInternation";
            this.dgvInternation.Size = new System.Drawing.Size(972, 150);
            this.dgvInternation.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(34, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // personDetailsWithFilters1
            // 
            this.personDetailsWithFilters1.FilterEnabled = true;
            this.personDetailsWithFilters1.Location = new System.Drawing.Point(257, 12);
            this.personDetailsWithFilters1.Name = "personDetailsWithFilters1";
            this.personDetailsWithFilters1.Size = new System.Drawing.Size(793, 352);
            this.personDetailsWithFilters1.TabIndex = 0;
            // 
            // frmDriverLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 706);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personDetailsWithFilters1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDriverLicenseHistory";
            this.Text = "frmDriverLicenseHistory";
            this.Load += new System.EventHandler(this.frmDriverLicenseHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.Local.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.PersonDetailsWithFilters personDetailsWithFilters1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl Local;
        private System.Windows.Forms.TabPage tabControl1;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInternation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}