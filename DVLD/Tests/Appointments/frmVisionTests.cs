using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Tests.Appointments;
using DVLD_Buisness;
using DVLD_Business;
namespace DVLD.Tests
{
    public partial class frmVisionTests : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _App;
        DataTable _dtVisionTestAppointments;
        public frmVisionTests(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            InitializeComponent();
        }
        void gridviewFormat()
        {

        }
        private void frmVisionTests_Load(object sender, EventArgs e)
        {
            _App = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            crtApplicationInfo2.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseApplicationID);
            _dtVisionTestAppointments= _App.GetAllTestAppointments();
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewUserButton_Click(object sender, EventArgs e)
        {
            frmVisionTestsAppointment frm = new frmVisionTestsAppointment(_LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }
    }
}
