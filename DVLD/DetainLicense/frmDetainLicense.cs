using DVLD.License;
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
    public partial class frmDetainLicense : Form
    {
        int _LicenseID;
        clsLicense _License;
        int _DetainID;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            
            lblCreatedByUser.Text =  Global_Classes.General.CurrentUser.UserName;
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void crtShowLicenseInfoWithFilter1_OnLicesneFound()
        {

            _License = crtShowLicenseInfoWithFilter1.LicenseInfo;

            if (clsDetainLicense.IsLicenseDetained(_License.LicenseID))
            {
                MessageBox.Show("This License is already detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            //check if the License is active
            if (_License.IsActive != true)
            {
                MessageBox.Show("This License is not active and cannot be detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

                btnDetain.Enabled = true;
            lblLicenseID.Text = _License.LicenseID.ToString();
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(_License == null)
            {
                MessageBox.Show("Please select a License to detain.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (MessageBox.Show("Are you sure you want to detain this License?", "Confirm Detain", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (!clsDetainLicense.DetainLicense(_License, Convert.ToDecimal(txtFineFees.Text.Trim()), Global_Classes.General.CurrentUser.UserID))
            {
                MessageBox.Show("Failed to detain the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                return;
            }
            MessageBox.Show("License detained successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            llShowLicenseHistory.Enabled= true;
            llShowLicenseHistory.Visible = true;
            llShowLicenseInfo.Visible = true; 
            llShowLicenseInfo.Enabled = true;



        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only digits, control characters, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_License.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmDriverLicenseHistory frm = new frmDriverLicenseHistory(_License.DriverID);
            //frm.ShowDialog();
        }
    }
}
