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

namespace DVLD.License.International_Driving_License
{
    public partial class frmInternationLIcenseApplication : Form
    {
        //int ApplicationID= 0;
        //clsApplication Application=new clsApplication();
        //clsLicense License=new clsLicense();
        clsLicense License;
        int InternationalLicenseID;

        public frmInternationLIcenseApplication()
        {
            
            InitializeComponent();
        }
        
        bool _Validate()
        {
            //check if the local license is active 
            if (License.IsActive == false)
            {
                MessageBox.Show("the Local driving license is not active");
                return false;
            }
            // check if the person has an international license from the same class
            if (clsInternationalLicense.DoesDriverHaveInternationalLicense(License.DriverID, License.LicenseClassID))
            {
                MessageBox.Show("the driver already has an international driving license");
                return false;
            }
            if (License.LicenseClassID != 3 )
            {

                MessageBox.Show("this License class is not valid for international license");
                return false;
            }

            return true;

        }
        void _LoadFormData()
        {
            lblIssueDate.Text=DateTime.Now.ToShortDateString();
           // lblFee.Text;
           lblApplicationDate.Text=DateTime.Now.ToShortDateString();
            lblExpirationDate.Text=DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = Global_Classes.General.CurrentUser.UserID.ToString();

        }
        
        private void frmInternationLIcenseApplication_Load(object sender, EventArgs e)
        {
            crtShowLicenseInfoWithFilter1.OnLicesneFound += () =>
            {
                lblLocalLicenseID.Text = crtShowLicenseInfoWithFilter1.LicenseInfo.LicenseID.ToString();
                License= crtShowLicenseInfoWithFilter1.LicenseInfo;
            };
            _LoadFormData();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (License == null)
            {
                MessageBox.Show("Local Driving License is not found try again");
                return;
            }
            if (!_Validate())
            {
                return;
            }
            InternationalLicenseID = License.IssueInternationalLicense(Global_Classes.General.CurrentUser.UserID);
            if (InternationalLicenseID==-1)
            {
                MessageBox.Show("Failed to isse the license");
                return;

            }
            lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
            MessageBox.Show("International Driving License is issued successfully");

        }

        private void llShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(crtShowLicenseInfoWithFilter1.LicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(License.LicenseID,InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
