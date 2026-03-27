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

namespace DVLD.Application.International_Driving_License
{
    public partial class frmInternationalLicenseList : Form
    {
        DataTable InternationalLicense;

        public frmInternationalLicenseList()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenseList_Load(object sender, EventArgs e)
        {
            InternationalLicense= clsInternationalLicense.GetAllInternationalLicenses();
            LocalDrivingLicenseGridView.DataSource = InternationalLicense;
        }
    }
}
