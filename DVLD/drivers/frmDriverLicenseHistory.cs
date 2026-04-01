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
    public partial class frmDriverLicenseHistory : Form
    {
        int _PersonID;
        DataTable _LocalDrivingLicense;
        DataTable _InternationalDrivingLicense;
        public frmDriverLicenseHistory(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
        }
        void _FormatGrid()
        {
            if (dgvLocal.Columns.Count == 0) return;

            dgvLocal.Columns[0].HeaderText = "L.D.L.AppID";
            dgvLocal.Columns[0].Width = 70;

            dgvLocal.Columns[1].Width = 200;
            dgvLocal.Columns[2].Width = 100;
            dgvLocal.Columns[3].Width = 250;
            dgvLocal.Columns[4].Width = 200;



            if(dgvInternation.Columns.Count == 0) return;
            dgvInternation. Columns[0].Width = 70;

            dgvInternation.Columns[1].Width = 200;
            dgvInternation.Columns[2].Width = 100;
            dgvInternation.Columns[3].Width = 250;
            dgvInternation.Columns[4].Width = 200;




        }
        private void frmDriverLicenseHistory_Load(object sender, EventArgs e)
        {
             personDetailsWithFilters1.loadPersonInfo(_PersonID);
            personDetailsWithFilters1.FilterEnabled = false;
            _LocalDrivingLicense = clsLicense.GetAllPersonLicenses(_PersonID);
            dgvLocal.DataSource= _LocalDrivingLicense;
            _InternationalDrivingLicense = clsInternationalLicense.GetDriverInternationalLicenses(_PersonID);
            dgvInternation.DataSource = _InternationalDrivingLicense;
            _FormatGrid();

        }
    }
}
