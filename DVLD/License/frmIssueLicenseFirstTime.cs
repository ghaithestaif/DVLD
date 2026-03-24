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
using static DVLD_Business.clsApplication;

namespace DVLD.License
{
    public partial class frmIssueLicenseFirstTime : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _LocalDivinglicenseApplication;
        
        public frmIssueLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDivinglicenseApplication=clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            InitializeComponent();
        }

        private void frmLicenseRelease_Load(object sender, EventArgs e)
        {
            //check if person has passed all tests
            if (!_LocalDivinglicenseApplication.HasPersonPassedAllTests())
            {
                MessageBox.Show("this perosn has not passed all tests");
                this.Close();
            }
            //check if this person has the license
            if(clsLicense.DoesPersonHaveLicesne(_LocalDivinglicenseApplication.ApplicantPerson.PersonID,_LocalDivinglicenseApplication.LicenseClass.LicenseClassID))
            {
                MessageBox.Show("this perosn has this License");
                this.Close();
            }
            if (!(_LocalDivinglicenseApplication.ApplicationStatus == enApplicationStatus.New))
            {
                MessageBox.Show("this application was cancelled or completed");
                this.Close();
            }


            crtApplicationInfo1.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseApplicationID);

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDivinglicenseApplication.IssueLicenseTheFirstTime(txtNotes.Text.Trim(), Global_Classes.General.CurrentUser.UserID);

            if (LicenseID == -1)
            {
                MessageBox.Show("License was not issued", "error");
                return;
            }
            else
            {
                MessageBox.Show("License was not issued. License ID ="+LicenseID);
                return;

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
