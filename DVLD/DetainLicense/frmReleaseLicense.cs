using DVLD_Buisness;
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

namespace DVLD.DetainLicense
{
    public partial class frmReleaseLicense : Form
    {
        clsLicense _License;
        clsDetainLicense _Detaininfo;
        public frmReleaseLicense()
        {
            InitializeComponent();
        }
        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            lblApplicationFees.Text =  clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString("C");
            lblCreatedByUser.Text = Global_Classes.General.CurrentUser.UserName;
        }

        private void crtShowLicenseInfoWithFilter1_OnLicesneFound()
        {
            _License = crtShowLicenseInfoWithFilter1.LicenseInfo;
            if (!clsDetainLicense.IsLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("The license is not detained");
                return;
            }

            lblLicenseID.Text = _License.LicenseID.ToString();
            //find the Detain record for the Licesnse

            _Detaininfo = clsDetainLicense.FindDetainByLicenseID(_License.LicenseID);
            if(_Detaininfo == null)
            {
                MessageBox.Show("Failed to find the detain information for the license");
                return;
            }

            lblDetainDate.Text = _Detaininfo.DetainDate.ToShortDateString();
             lblDetainID.Text = _Detaininfo.DetainID.ToString();
            lblFineFees.Text = _Detaininfo.FineFees.ToString("C");
            lblTotalFees.Text = (_Detaininfo.FineFees + clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees).ToString("C");

            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int ApplicationID = -1;
            if(!_License.ReleaseLicense(Global_Classes.General.CurrentUser.UserID, ref ApplicationID))
            {
                       MessageBox.Show("Failed to release the license");
                return;
            }
            lblApplicationID.Text = ApplicationID.ToString();
             MessageBox.Show("License released successfully");
            btnRelease.Enabled = false;

        }
    }
}
