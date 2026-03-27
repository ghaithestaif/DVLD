using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class frmLicenseInfo : Form
    {
        int _LicenseID;
        int _InternationalLicenseID;
        public frmLicenseInfo(int LicenseID,int InternationalLicenseID=-1)
        {
            _LicenseID = LicenseID;
            _InternationalLicenseID = InternationalLicenseID;
            
            InitializeComponent();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_InternationalLicenseID != -1)
            {
                lblTitle.Text = "International Driving License Information";
               
            }
            else
            {
                lblTitle.Text = "Local Driving License Information";
            }
            crtShowLicenseInfo1.LoadData(_LicenseID, _InternationalLicenseID);

        }
    }
}
