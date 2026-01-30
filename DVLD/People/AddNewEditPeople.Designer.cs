namespace DVLD.People
{
    partial class AddNewEditPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewEditPeople));
            this.addEditPeople = new DVLD.People.crtAddEditPeople();
            this.txtAddNewEditPerson = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtPersonID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // addEditPeople
            // 
            this.addEditPeople.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addEditPeople.Location = new System.Drawing.Point(15, 100);
            this.addEditPeople.Name = "addEditPeople";
            this.addEditPeople.Size = new System.Drawing.Size(828, 389);
            this.addEditPeople.TabIndex = 0;
            // 
            // txtAddNewEditPerson
            // 
            this.txtAddNewEditPerson.BackColor = System.Drawing.Color.Transparent;
            this.txtAddNewEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddNewEditPerson.ForeColor = System.Drawing.Color.Red;
            this.txtAddNewEditPerson.Location = new System.Drawing.Point(308, 30);
            this.txtAddNewEditPerson.Name = "txtAddNewEditPerson";
            this.txtAddNewEditPerson.Size = new System.Drawing.Size(215, 33);
            this.txtAddNewEditPerson.TabIndex = 1;
            this.txtAddNewEditPerson.Text = "Add new Person";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Person ID:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox2.Location = new System.Drawing.Point(126, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // txtPersonID
            // 
            this.txtPersonID.AutoSize = true;
            this.txtPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonID.Location = new System.Drawing.Point(162, 71);
            this.txtPersonID.Name = "txtPersonID";
            this.txtPersonID.Size = new System.Drawing.Size(40, 20);
            this.txtPersonID.TabIndex = 29;
            this.txtPersonID.Text = "N/A";
            // 
            // AddNewEditPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 501);
            this.Controls.Add(this.txtPersonID);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddNewEditPerson);
            this.Controls.Add(this.addEditPeople);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewEditPeople";
            this.Text = "AddNewEditPeople";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private crtAddEditPeople addEditPeople;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtAddNewEditPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtPersonID;
    }
}