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

namespace DVLD.License
{
    public partial class frmLicenseRelease : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _LocalDivinglicenseApplication;
        clsLicense NewLicense=new clsLicense();
        public frmLicenseRelease(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDivinglicenseApplication=clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            InitializeComponent();
        }

        private void frmLicenseRelease_Load(object sender, EventArgs e)
        {
            crtApplicationInfo1.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            











            

        }
    }
}
