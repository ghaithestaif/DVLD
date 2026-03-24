using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application
{
    public partial class frmApplicationInfo : Form
    {
        int _LocalDrivingLicenseAppplication=-1;
        public frmApplicationInfo(int LocalDrivingLicenseAppplication)
        {
             _LocalDrivingLicenseAppplication  = LocalDrivingLicenseAppplication;
            InitializeComponent();
        }

        private void frmApplicationInfo_Load(object sender, EventArgs e)
        {
            crtApplicationInfo1.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseAppplication);
        }
    }
}
