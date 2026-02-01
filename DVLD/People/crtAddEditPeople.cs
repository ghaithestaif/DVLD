using DVLD.Properties;
using DVLD_Business;
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
using static DVLD_Business.clsPeople;

namespace DVLD.People
{
    public partial class crtAddEditPeople : UserControl
    {
        public event Action PersonSaved;
        private DVLD_Business.clsPeople.enMode mode = DVLD_Business.clsPeople.enMode.enAddnew;
        private DVLD_Business.clsPeople _AddEditPerson = new DVLD_Business.clsPeople();
        private int _PersonID;
        
        public crtAddEditPeople()
        {
            InitializeComponent();

        }
        private void AddEditPeople_Load(object sender, EventArgs e)
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            _LoadPerson();
        }

        private void _LoadImage(string Path)
        {

            if (File.Exists(Path))
            {
                // Dispose previous image if any
                if (pPicture.Image != null)
                    pPicture.Image.Dispose();

                // Load image into PictureBox safely
                using (var temp = Image.FromFile(Path))
                {
                    pPicture.Image = new Bitmap(temp); // make a copy
                }
            }
            else
            {
                pPicture.Image = null; // clear PictureBox if file not found
            }

        }
        private void _FillCountryComboBox()
        {
            DataTable dt=DVLD_Business.clsCountries.GetAllCountries();
            cbCountry.DataSource = dt;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }
        private void _LoadPerson()
        {
            if ((mode == enMode.enAddnew)) {
                _FillCountryComboBox();
                return;
            }
            _AddEditPerson = DVLD_Business.clsPeople.Find(PersonID);


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
            _FillCountryComboBox();
            cbCountry.SelectedValue = _AddEditPerson.NationalityCountryID;
            if (_AddEditPerson.Gendor == 0) {
                rbtnMan.Checked = true;

            }
            else { rbtnFemale.Checked = true; }


        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            string nationalNo = txtNationalNo.Text;

            if (DVLD_Business.clsPeople.IspersonExist(nationalNo))
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
            if (string.IsNullOrWhiteSpace(firstName))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name cannot be empty.");
            }
        }
        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            string secondName = txtSecondName.Text;
            if (string.IsNullOrWhiteSpace(secondName))
            {
                e.Cancel = true;
                txtSecondName.Focus();
                errorProvider1.SetError(txtSecondName, "Second Name cannot be empty.");
            }
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            string lastName = txtLastName.Text;
            if (string.IsNullOrEmpty(lastName))
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
            if (string.IsNullOrWhiteSpace(address))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Address cannot be empty.");
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
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


        private void btnClose_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _AddEditPerson.NationalNo = txtNationalNo.Text;
            _AddEditPerson.FirstName = txtFirstName.Text;
            _AddEditPerson.SecondName = txtSecondName.Text;
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
                PersonSaved?.Invoke();

                if (mode == DVLD_Business.clsPeople.enMode.enAddnew)
                {
                    mode = DVLD_Business.clsPeople.enMode.enUpdate;
                    MessageBox.Show("Person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Person updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private string _CopyImage(string oldpath)
        {

         

            // Step 2: Define folder to store images
            string folderPath = Path.Combine(Application.StartupPath, "Images");
            Directory.CreateDirectory(folderPath); // creates folder if it doesn't exist

            // Step 3: Generate unique file name with GUID
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(oldpath);
            string newFilePath = Path.Combine(folderPath, newFileName);

            // Step 4: Copy the file to the new folder
            File.Copy(oldpath, newFilePath);

            // Step 5: Load the picture into PictureBox
            if (pPicture.Image != null)
                pPicture.Image.Dispose(); // free previous image

            pPicture.Image = Image.FromFile(newFilePath);

           return  newFilePath;


        }
        void _DeleteOldImage(string OldImagePath) {

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

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose a picture";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _DeleteOldImage(_AddEditPerson.ImagePath);
                        string originalPath = ofd.FileName;

                      string NewPath = _CopyImage(originalPath);
                        _AddEditPerson.ImagePath = NewPath;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                    
                }

            }





        }
    }

}
