using DVLD.License;
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

namespace DVLD.Application.ReplacementForDamagedLostLicense
{
    public partial class frmReplacementForDamagedLostLicense : Form
    {
        clsLicense _License;
        clsLicense ReplaceLicense;
        enum enReplacementType
        {
            Damaged,
            Lost
        }
        enReplacementType _ReplacementType = enReplacementType.Damaged;
        
        public frmReplacementForDamagedLostLicense()
        {
            InitializeComponent();
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _ReplacementType = rbDamagedLicense.Checked ? enReplacementType.Damaged : enReplacementType.Lost;
            lblApplicationFees.Text = clsApplicationType.Find((int)(_ReplacementType == enReplacementType.Damaged ? clsApplication.enApplicationType.ReplaceDamagedDrivingLicense : clsApplication.enApplicationType.ReplaceLostDrivingLicense)).Fees.ToString("C");
        }

        private void frmReplacementForDamagedLostLicense_Load(object sender, EventArgs e)
        {
            // first check that tha License is active or not, if not active then show message and close the form
            
            lblCreatedByUser.Text = Global_Classes.General.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
        }

        private void crtShowLicenseInfoWithFilter1_OnLicesneFound()
        {
            
            _License = crtShowLicenseInfoWithFilter1.LicenseInfo;
            lblOldLicenseID.Text = _License.LicenseID.ToString();
            if (_License.IsActive == false)
            {
                MessageBox.Show("This license is not active, you cannot replace it.", "License Not Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssueReplacement.Enabled = false;
                return;
            }
            btnIssueReplacement.Enabled = true;

        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (_License == null) { 
                MessageBox.Show("Please select a license to replace.", "No License Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
             ReplaceLicense = _License.ReplaceLicense("", _ReplacementType == enReplacementType.Damaged ? clsApplication.enApplicationType.ReplaceDamagedDrivingLicense : clsApplication.enApplicationType.ReplaceLostDrivingLicense);
            if(ReplaceLicense == null)
            {
                MessageBox.Show("Failed to issue replacement license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblApplicationID.Text = ReplaceLicense.ApplicationID.ToString();
            lblRreplacedLicenseID.Text= ReplaceLicense.LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;
            btnIssueReplacement.Enabled = false;
            crtShowLicenseInfoWithFilter1.enableFilter = false;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = _License.DriverID;
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(DriverID);
            frm.ShowDialog();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(ReplaceLicense.LicenseID);
            frm.ShowDialog();
        }
    }
}
