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
        private void frmVisionTests_Load(object sender, EventArgs e)
        {
            _App = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            crtApplicationInfo2.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseApplicationID);
            _dtVisionTestAppointments= _App.GetAllTestAppointments();
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
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
        void RefreshGrid()
        {
            _dtVisionTestAppointments = _App.GetAllTestAppointments();
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestsAppointment frm = new frmVisionTestsAppointment(_LocalDrivingLicenseApplicationID, Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value));
            frm.ctrlScheduleTest1.OnAppointmentSaved += RefreshGrid;


            frm.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeVisionTest frm = new frmTakeVisionTest(_LocalDrivingLicenseApplicationID, Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value));
            frm.ShowDialog();
        }
    }
}
