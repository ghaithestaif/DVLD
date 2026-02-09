using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class AddEditUser : Form
    {
        public event Action UserSaved;

        enum enMode { Addnew,Update}
        enMode _mode;
        

        public AddEditUser(int PersonID)
        {
            if (PersonID == -1) 
            {
                _mode = enMode.Addnew;
            } 
            else
            {
                _mode= enMode.Update;
                personDetailsWithFilters1.loadPersonInfo(PersonID);
            }
                InitializeComponent();
        }
        

        private void btnNext_Click(object sender, EventArgs e)

        {
            if (!(DVLD_Business.People.IspersonExist(personDetailsWithFilters1.PersonID)))
            {
                MessageBox.Show("Please select a person to continue.", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(clsUser.IsPersonLinkedToUser(personDetailsWithFilters1.PersonID))
            {
                MessageBox.Show("The selected person is already linked to a user account. Please select a different person.", "Person Already Linked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tabControl1.SelectedTab = tabPage2;
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "Username can not be empty.");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password can not be empty.");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password can not be empty.");
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btnSave.Enabled = false;

            }
            else
            {
                if (!DVLD_Business.People.IspersonExist(personDetailsWithFilters1.PersonID))
                {
                    MessageBox.Show("Please choose an existant person", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool _ValidateInputs()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Username is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password is required");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
                return false;
            }

            return true;
        }

        private clsUser _FillObject()
        {
            // first validate the form
            _ValidateInputs();


            clsUser user = new clsUser();
            user.Person = DVLD_Business.People.Find(personDetailsWithFilters1.PersonID);
            user.UserName = txtUserName.Text;
            user.Password = Util.Utill.HashPassword(txtPassword.Text);
            user.IsActive = rbIsActive.Checked;
            return user;
        }
        void ChangeFormTitle()
        {
            if (_mode == enMode.Addnew)
            {
                _mode = enMode.Update;
                lFormTitle.Text = "Update User";

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUser user = _FillObject();
            if (user != null)
            {
                if (user.Save())
                {
                    MessageBox.Show("User saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserID.Text = user.UserID.ToString();
                    ChangeFormTitle();
                    UserSaved?.Invoke();

                }
                else
                {
                    MessageBox.Show("An error occurred while saving the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }
    }
}
