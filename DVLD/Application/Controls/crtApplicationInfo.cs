using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.People;
using DVLD_Buisness;
using DVLD_Business;
namespace DVLD.Application.Controls
{
    public partial class crtApplicationInfo : UserControl
    {
        int _localDrivingLicenseID;
        public int LocalDrivingLicenseID
        {
            get { return _localDrivingLicenseID; }
        }
        clsLocalDrivingLicenseApplication _localDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
        {
            get { return _localDrivingLicenseApplication; }
        }
        public crtApplicationInfo()
        {
            InitializeComponent();
        }

        private void crtApplicationInfo_Load(object sender, EventArgs e)
        {
            // fill the combo box



        }

        public void loadInfoByLocalDrivingLicenseAppplication(int LocalDrivingLicenseID)
        {
            _localDrivingLicenseApplication= clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseID);
            if(_localDrivingLicenseApplication == null)
            {
                return;
            }
            _FillControlWithInfo();
        }
        public void loadInfoByApplicationID(int ApplicationID)
        {
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_localDrivingLicenseApplication != null)
            {
                return;
            }
            _FillControlWithInfo();
        }

        private void _FillControlWithInfo()
        {
            txtApplicationID.Text = _localDrivingLicenseApplication.ApplicationID.ToString();
            txtLocalDrivingLicenseID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            txtLicenseClass.Text = _localDrivingLicenseApplication.LicenseClass.ClassName.ToString();
            txtStatus.Text = _localDrivingLicenseApplication.StatusText.ToString();
            txtFee.Text = _localDrivingLicenseApplication.PaidFees.ToString("C");
            txtType.Text = clsApplicationType.Find(_localDrivingLicenseApplication.ApplicationTypeID).Title.ToString();
            txtApplicant.Text = _localDrivingLicenseApplication.ApplicantPerson.FullName.ToString();
            txtDate.Text = _localDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            txtStatusDate.Text = _localDrivingLicenseApplication.LastStatusDate.ToShortDateString();
            txtPassedTests.Text = _localDrivingLicenseApplication.PassedTests().ToString() + "/3";
            txtCreatedBy.Text = _localDrivingLicenseApplication.CreatedByUser.UserName.ToString();

        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // not now

        }

        private void llShoePersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = _localDrivingLicenseApplication.ApplicantPerson.PersonID;
            frmPersonDetails personDetails = new frmPersonDetails(personID);
            personDetails.ShowDialog();
        }
    }
}
