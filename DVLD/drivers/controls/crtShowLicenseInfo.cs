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
        int _InternationalLicenseID;
        clsLicense _License;
        clsInternationalLicense _InternationalLicense;
        enum enLicenseType
        {
            International = 0,
            Local = 1
        }
        enLicenseType _LicenseType = enLicenseType.Local;  

        public clsLicense License
            { get { return _License; } }

        


        public crtShowLicenseInfo()
        {
                        
            InitializeComponent();
        }
        void LoadImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
        }
        void _handleInternationalLicense()
        {
            if(enLicenseType.International!=_LicenseType)
            {
                return;
            }
            lblInternationalLicensetext.Visible = true;
            lblInternationalLicenseID.Visible = true;
            pbInternationalLicenseIcon.Visible = true;
            lblInternationalLicensetext.Enabled = true;
            lblInternationalLicenseID.Enabled = true;
            pbInternationalLicenseIcon.Enabled = true;
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName.ToString();
            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor.ToString();
            lblIsActive.Text = (_InternationalLicense.IsActive) ? "Yes" : "No";
            //for now
            lblIsDetained.Text = "No";
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblLicenseID.Text = _LicensesID.ToString();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo.ToString();
            lblNotestext.Visible = false;
            pbIssueReason.Visible = false;
            lblIssueReasonText.Visible = false;
            pbNotes.Visible = false;
            lblNotes.Visible = false;
            lblIssueReason.Visible = false;

        }
        void _HandleLocalLicense()
        {
            if (enLicenseType.Local != _LicenseType)
            {
                return;
            }
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName.ToString();
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor.ToString();
            lblIsActive.Text = (_License.IsActive) ? "Yes" : "No";

            //for now
            lblIsDetained.Text = "No";
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = ((clsLicense.enIssueReason)_License.IssueReason).ToString();
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo.ToString();
            if (_License.Notes == null)
                lblNotes.Text = "None";
            else
                lblNotes.Text = _License.Notes.ToString();
        }
        public  void  LoadData(int LicenseID,int InternationalLicenseID = -1)
        {
            //check if it is international license
            if(InternationalLicenseID == -1)
            {
                _LicenseType=enLicenseType.Local;
                _LicensesID = LicenseID;
                _License = clsLicense.Find(_LicensesID);
            }
            else
            {
                _LicenseType = enLicenseType.International;
                _InternationalLicenseID = InternationalLicenseID;
                _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
                _LicensesID = LicenseID;
                _License = clsLicense.Find(_LicensesID);
            }
            
            if (_License == null)
            {
                MessageBox.Show("not a valid License ID");
                return;
            }

            if (_LicenseType == enLicenseType.International && _InternationalLicense == null)
            {
                MessageBox.Show("not a valid License ID");
                return;
            }



            if (_LicenseType == enLicenseType.International)
            {
                _handleInternationalLicense();
            }

            if(_LicenseType==enLicenseType.Local)
            {
                _HandleLocalLicense();
            }


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

            if (_License.DriverInfo.PersonInfo.Gendor == 0)
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
