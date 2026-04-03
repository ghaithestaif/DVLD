using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.drivers.controls;
using DVLD.License;
using DVLD_Buisness;
using DVLD_Business;

namespace DVLD.Application.Renew_Driving_License
{
    public partial class frmRenewDrivingLicese : Form
    {
        clsLicense OldLicense;
        int NewLicenseID;
        void LoadLicenseData()
        { 
            float LicenseFee = clsLicenseClass.Find(OldLicense.LicenseClassID).ClassFees;
            double ApplicationFee = Convert.ToDouble(  clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees);
            int TotalFees = Convert.ToInt32(LicenseFee + ApplicationFee);
            lblOldLicenseID.Text = OldLicense.LicenseID.ToString();
            lblExpirationDate.Text = OldLicense.ExpirationDate.ToShortDateString();
            lblLicenseFee.Text = LicenseFee.ToString();
            lblApplicationFee.Text = ApplicationFee.ToString();
            lbltotalFees.Text= TotalFees.ToString();
            lblExpirationDate.Text = OldLicense.ExpirationDate.ToShortDateString();

        }
        public frmRenewDrivingLicese()
        {
            InitializeComponent();
            
        }
        

        private void frmRenewDrivingLicese_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = Global_Classes.General.CurrentUser.UserName;
            lblIssueDate.Text = DateTime.Now.ToShortDateString();

   

        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicense NewLicense = new clsLicense();
            if (txtNotes.Text == null)
            {
                txtNotes.Text = string.Empty;
            }
            NewLicense = OldLicense.RenewLicense(txtNotes.Text.Trim());

            if(NewLicense == null)
            {
                MessageBox.Show("An error occurred while renewing the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("License renewed successfully. New License ID: " + NewLicense.LicenseID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            linkLabel1.Enabled= true;
            NewLicenseID= NewLicense.LicenseID;





        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseHistory frm=new frmDriverLicenseHistory(OldLicense.DriverID);
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(NewLicenseID);
            frm.ShowDialog();

        }

        private void crtShowLicenseInfoWithFilter2_OnLicesneFound()
        {
            OldLicense = crtShowLicenseInfoWithFilter2.LicenseInfo;
            if (!OldLicense.IsLicenseExpired())
            {
                MessageBox.Show("This License is not valid for renewal", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
            }
            LoadLicenseData();
        }
    }
}
