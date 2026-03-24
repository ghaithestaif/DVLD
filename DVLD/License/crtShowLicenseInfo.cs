using DVLD.Properties;
using DVLD_Business;
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

namespace DVLD.License
{
    public partial class crtShowLicenseInfo : UserControl
    {
        int _LicensesID;
        clsLicense _License;
        clsPeople _Person;
        public clsLicense License
            { get { return _License; } }

        public clsPeople Person
        {
            get { return _Person; }
        }

        public crtShowLicenseInfo()
        {
                        
            InitializeComponent();
        }
        void LoadImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
        }
      public  void  LoadData(int LicenseID)
        {
            _LicensesID = LicenseID;
            _License = clsLicense.Find(_LicensesID);
            if (_License == null)
            {
                return;
            }
            _Person = clsPeople.Find(_License.DriverInfo.PersonID);
            if (_License == null)
            {
                MessageBox.Show("not a valid License ID");
                return;
            }



            lblClass.Text=_License.LicenseClassInfo.ClassName;
            lblDateOfBirth .Text= _Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text=_License.ExpirationDate.ToShortDateString();
            lblFullName.Text=_Person.FullName.ToString();
            lblGendor.Text=_Person.Gendor.ToString();
            lblIsActive.Text = _License.IsActive.ToString();

            //for now
            lblIsDetained.Text = "No";
            lblIssueDate.Text= _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = ((clsLicense.enIssueReason)_License.IssueReason).ToString();
            lblLicenseID.Text= _License.LicenseID.ToString();
            lblNationalNo.Text=_Person.NationalNo.ToString();
            lblNotes.Text= _License.Notes.ToString();
            LoadImage();



        }

        public void ResetLicenseInfo()
        {
            lblClass.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblFullName.Text = "???";
            lblGendor.Text = "???";
            lblIsActive.Text = "???";
            lblIsDetained.Text = "??";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblNotes.Text = "???";
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
        }

        private void crtShowLicenseInfo_Load(object sender, EventArgs e)
        {


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
