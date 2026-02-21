using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _User;
        public int UserID { get { return _UserID; } }
        public clsUser User { get { return _User; } }
        public frmChangePassword(int ID)
        {
            _UserID = ID;
            _User = clsUser.Find(_UserID);
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            crtUserCard1.loadUserInformation(UserID);
        }
        bool _ValidateInput()
        {
            //validate Input
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text)||
                string.IsNullOrWhiteSpace(txtNewPassword.Text)||
                string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                //write a message
                MessageBox.Show("You have to fill all the fields","Error"); 
                return false;
            }
            if(_User.Password!= Util.Utill.HashPassword(txtOldPassword.Text))
            {
                MessageBox.Show("The oldpassword you entered is invalid","Error");
                return false;
            }
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Confirm Password you entered is incorrect", "Error"); 
                return false;
            }
            return true;

        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                e.Cancel = true;
                txtOldPassword.Focus();
                errorProvider1.SetError(txtOldPassword,"This Field cannot be empty");
            }
            string HashedPassword = Util.Utill.HashPassword(txtOldPassword.Text);
            if (HashedPassword != _User.Password)
            {
                e.Cancel = true;
                txtOldPassword.Focus();
                errorProvider1.SetError(txtOldPassword, "the password you entered is invalid");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtConfirmPassword.Text)) {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "this field Cannot be empty");
            
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text) {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "This Password is invalid");

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
                { return; }

            _User.Password = Util.Utill.HashPassword(txtNewPassword.Text);
            if (_User.Save())
            {
                MessageBox.Show("Password Saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
