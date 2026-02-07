using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DVLD
{
    public partial class frmLogin : Form
    {
        clsUser _LogInUser= new clsUser();
        void FillUserData()
        {
            string directoryPath = System.IO.Directory.GetCurrentDirectory();
            string FileName = "Data.txt";
            string FileDestination = directoryPath + "\\" + FileName;

            if (!File.Exists(FileDestination)) {
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(FileDestination);

            for (int i = 0;i < lines.Length; i++) { 
                string item = lines[i].Trim();
                if (i==0)
                {
                    txtUserName.Text = item;
                }
                else
                {
                    txtPassword.Text = item;
                }
            }
        }
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            FillUserData();
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text.Trim();

            string UserName = txtUserName.Text.Trim();

            string HashedPassword = Util.Utill.HashPassword(enteredPassword);

            _LogInUser=clsUser.FindByUsernameAndPassword(UserName, HashedPassword);
            if (_LogInUser != null)
            {
                if(_LogInUser.IsActive == false)
                {
                    MessageBox.Show("Your account is inactive. Please contact the administrator.");
                    return;
                }
                if (rbRememberMe.Checked)
                {
                    Global_Classes.General.RemeberUser(UserName, txtPassword.Text);
                }
                else
                {
                    Global_Classes.General.RemeberUser("","");
                }

                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Hide();
            } 
            else
            {
                MessageBox.Show("Invalid username or password.");
            }



        }
    }
}
