using DVLD.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class AddNewEditPeople : Form
    {
        private DVLD_Business.People _AddEditPerson = new DVLD_Business.People();
        public int PersonID;

        public DVLD_Business.People.enMode mode = DVLD_Business.People.enMode.enAddnew;
        public event Action DataBack;
        // Create a protected method to raise the event with a parameter
        
        public AddNewEditPeople(int PersonID)
        {

            InitializeComponent();
            _prepareForm();
            if (PersonID != -1)
            {
                this.PersonID = PersonID;

                _AddEditPerson = DVLD_Business.People.Find(PersonID);
                mode = DVLD_Business.People.enMode.enUpdate;
                LoadPerson();
            }
            else
            {
                  mode = DVLD_Business.People.enMode.enAddnew;

            }
            
        }
       public void LoadFormTitle()
       {
            if (mode == DVLD_Business.People.enMode.enAddnew)
            {
                this.Text = "Add New Person";
                txtAddNewEditPerson.Text = "Add New Person";

            }
            else if (mode == DVLD_Business.People.enMode.enUpdate)
            {
                this.Text = "Edit Person";
                txtAddNewEditPerson.Text = "Edit Person";
                txtPersonID.Text = _AddEditPerson.PersonID.ToString();
            }

        }

        private void AddNewEditPeople_Load(object sender, EventArgs e)
        {
            LoadFormTitle();
            

        }
        private void _LoadImage(string Path)
        {

            if (File.Exists(Path))
            {
               pPicture.ImageLocation = Path;
                llRemove.Enabled= true;
            }
            else
            {
                pPicture.Image = null; // clear PictureBox if file not found
            }

        }
        private void _FillCountryComboBox()
        {
            DataTable dt = DVLD_Business.Countries.GetAllCountries();
            cbCountry.DataSource = dt;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }


        void _prepareForm()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            _FillCountryComboBox();

        }
        public void LoadPerson()
        {

            

            txtAddress.Text = _AddEditPerson.Address;
            txtEmail.Text = _AddEditPerson.Email;
            txtFirstName.Text = _AddEditPerson.FirstName;
            txtSecondName.Text = _AddEditPerson.SecondName;
            txtThirdName.Text = _AddEditPerson.ThirdName;
            txtPhone.Text = _AddEditPerson.Phone;
            txtNationalNo.Text = _AddEditPerson.NationalNo;
            dtpDateOfBirth.Value = _AddEditPerson.DateOfBirth;
            txtLastName.Text = _AddEditPerson.LastName;
            _LoadImage(_AddEditPerson.ImagePath);
            

            cbCountry.SelectedValue = _AddEditPerson.NationalityCountryID;

            if (_AddEditPerson.Gendor == 0)
            {
                rbtnMan.Checked = true;

            }
            else { rbtnFemale.Checked = true; }


        }  
        private void rbtnMan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMan.Checked)
            {
                pPicture.Image = Resources.Male_512;

            }
            else if (rbtnFemale.Checked)
            {
                pPicture.Image = Resources.Female_512;
            }

        }
        private bool _HandleImage()
        {
            if(_AddEditPerson.ImagePath!=pPicture.ImageLocation)
            {
                if(_AddEditPerson.ImagePath!=null)
                {
                    _DeleteOldImage(_AddEditPerson.ImagePath);
                }
                if(pPicture.ImageLocation!=null)
                {
                    string SourceImagePath = pPicture.ImageLocation;
                    if (Util.Utill.CopyImageToProjectFolder(ref SourceImagePath))
                    {
                        pPicture.ImageLocation = SourceImagePath;
                        _AddEditPerson.ImagePath = SourceImagePath;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        void _DeleteOldImage(string OldImagePath)
        {

            if (File.Exists(OldImagePath))
            {
                try
                {
                    File.Delete(OldImagePath); // deletes the old image
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not delete old image: " + ex.Message);
                }
            }


        }
        private void SetImageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
        }

            
        private void btnSave_Click(object sender, EventArgs e)
        {

          
            if (!_HandleImage())
            {
                return;
            }
            _AddEditPerson.NationalNo = txtNationalNo.Text;
            _AddEditPerson.FirstName = txtFirstName.Text;
            _AddEditPerson.SecondName =txtSecondName.Text;
            _AddEditPerson.ThirdName = txtThirdName.Text;
            _AddEditPerson.LastName = txtLastName.Text;
            _AddEditPerson.DateOfBirth = dtpDateOfBirth.Value;
            _AddEditPerson.Phone = txtPhone.Text;
            _AddEditPerson.Address = txtAddress.Text;
            _AddEditPerson.Email = txtEmail.Text;

            _AddEditPerson.NationalityCountryID = (int)cbCountry.SelectedValue;
            if (rbtnFemale.Checked)
            {
                _AddEditPerson.Gendor = 1;
            }
            else { _AddEditPerson.Gendor = 0; }


            if (_AddEditPerson.Save())
            {
                DataBack?.Invoke();

                if (mode == DVLD_Business.People.enMode.enAddnew)
                {
                    mode = DVLD_Business.People.enMode.enUpdate;
                    MessageBox.Show("Person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFormTitle();


                }
                else
                {
                    MessageBox.Show("Person updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
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

        
        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                e.Cancel = false;
            }
            else if (!DVLD.Validating.clsValidating.IsEmail(email))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email is not valid.");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            string FirstName = txtFirstName.Text;
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "FirstName cannot be empty.");


            }
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            string SecondName = txtSecondName.Text;
            if (string.IsNullOrWhiteSpace(SecondName))
            {
                e.Cancel = true;
                txtSecondName.Focus();
                errorProvider1.SetError(txtSecondName, "Second Name cannot be empty.");


            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            string LastName = txtLastName.Text;
            if (string.IsNullOrWhiteSpace(LastName))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name cannot be empty.");


            }
        }

      

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string Phone = txtPhone.Text;
            if (string.IsNullOrWhiteSpace(Phone))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Phone cannot be empty.");


            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            string Address = txtAddress.Text;
            if (string.IsNullOrWhiteSpace(Address))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Address cannot be empty.");


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnMan_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnMan.Checked)
            {
                pPicture.Image = Resources.Male_512;
            }
            else
            {
                pPicture.Image= Resources.Female_512;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbtnFemale.Checked)
            {
                pPicture.Image = Resources.Female_512;
                pPicture.ImageLocation = null;
            }
            else if (rbtnMan.Checked)
            {
                pPicture.Image = Resources.Male_512;
                pPicture.ImageLocation = null;

            }
        }

        private void SetImageLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                openFileDialog1.Title = "Choose a picture";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                 pPicture.ImageLocation = openFileDialog1.FileName;
                    llRemove.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }

            }
            


            
        }

        
    }
}
