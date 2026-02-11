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
        
        int _UserID;
        clsUser _User=new clsUser();
        public int UserID { get { return _UserID; } }
        clsUser User { get { return _User; } }  
        public AddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        

        private void btnNext_Click(object sender, EventArgs e)

        {
            if (_mode == enMode.Update)
            {
                tabControl1.SelectedTab = tabPage2;
                return;
            }

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
        void _LoadLogInInfo()
        {
            //this is only called when it is in update mode so the passwords are not going to be displayed
           llUserID.Text= _User.UserID.ToString();  
            txtConfirmPassword.Enabled= false;
            txtPassword.Enabled= false;
            txtUserName.Text= _User.UserName.ToString();
            rbIsActive.Checked=_User.IsActive;  
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            if (_UserID == -1)
            {
                _mode = enMode.Addnew;
            }
            else
            {
                _mode = enMode.Update;
                _User = clsUser.Find(UserID);
                _LoadLogInInfo();
                personDetailsWithFilters1.loadPersonInfo(_User.Person.PersonID);
                personDetailsWithFilters1.FilterEnabled = false;
                lFormTitle.Text = "Update User";
            }


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


        private bool _ValidateInputs()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Username is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) && _mode != enMode.Update)
            {
                errorProvider1.SetError(txtPassword, "Password is required");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text && _mode != enMode.Update)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
                return false;
            }

            return true;
        }

        private void _FillObject()
        {
            // first validate the form
            if (_mode == enMode.Update) {
                _User.UserName = txtUserName.Text;
                _User.IsActive = rbIsActive.Checked;
                return;
            }

            _User.Person = DVLD_Business.People.Find(personDetailsWithFilters1.PersonID);
            _User.UserName = txtUserName.Text;
            _User.Password = Util.Utill.HashPassword(txtPassword.Text);
            _User.IsActive = rbIsActive.Checked;
            
        }
        void ChangeFormTitle()
        {
            if (_mode == enMode.Addnew)
            {
                _mode = enMode.Update;
                lFormTitle.Text = "Update User";
                personDetailsWithFilters1.FilterEnabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInputs())
            {
                return;
            }

            _FillObject();
            if (_User != null)
            {
                if (_User.Save())
                {
                    
                    MessageBox.Show("User saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llUserID.Text = _User.UserID.ToString();
                    ChangeFormTitle();
                    personDetailsWithFilters1.FilterEnabled = false;
                    UserSaved?.Invoke();

                }
                else
                {
                    MessageBox.Show("An error occurred while saving the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
