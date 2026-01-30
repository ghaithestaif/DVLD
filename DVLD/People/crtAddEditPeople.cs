using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class crtAddEditPeople : UserControl
    {
        
        public crtAddEditPeople()
        {
            InitializeComponent();

        }
        private void AddEditPeople_Load(object sender, EventArgs e)
        {
         //   dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            
        }
    

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            string nationalNo = txtNationalNo.Text;

            if (DVLD_Business.People.IspersonExist(nationalNo))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "This National No already exists.");
            }


            if (string.IsNullOrEmpty(nationalNo))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtNationalNo, "National No cannot be empty.");
            }

        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            string firstName = txtFirstName.Text;
            if(string.IsNullOrWhiteSpace(firstName))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name cannot be empty.");
            }
        }
        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            string secondName = txtSecondName.Text;
            if(string.IsNullOrWhiteSpace(secondName))
            {
                e.Cancel = true;
                txtSecondName.Focus();
                errorProvider1.SetError(txtSecondName, "Second Name cannot be empty.");
            }
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            string lastName = txtLastName.Text;
            if(string.IsNullOrEmpty(lastName))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name cannot be empty.");
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = txtPhone.Text;
            if (string.IsNullOrWhiteSpace(phone)) {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtPhone, "Phone cannot be empty.");


            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            string address = txtAddress.Text;
            if(string.IsNullOrWhiteSpace(address))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Address cannot be empty.");
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (!DVLD.Validating.clsValidating.IsEmail(email))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email is not valid.");
            }
        }

        private void rbtnMan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMan.Checked)
            {
                pPicture.Image=Resources.Male_512;

            }
            else if (rbtnFemale.Checked)
            {
                pPicture.Image = Resources.Female_512;
            }

        }
    }
}
