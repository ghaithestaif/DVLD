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
using System.Diagnostics.Eventing.Reader;
using DVLD_Business;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        clsUser _LogInUser= new clsUser();
        
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Pass = "",
                UserName = "";

            if (Global_Classes.General.GetStoredInfo(ref Pass, ref UserName))
            {

                txtPassword.Text =Pass;
                txtUserName.Text =UserName;
                rbRememberMe.Checked = true;

            }
            else
            {
                rbRememberMe.Checked = false; 
            }
            
            
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

            _LogInUser = clsUser.FindByUsernameAndPassword(UserName, HashedPassword);
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
                Global_Classes.General.CurrentUser = _LogInUser;
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
