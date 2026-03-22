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

namespace DVLD.Tests.Appointments.Written_Test
{
    public partial class frmWrittenTest : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _App;
        DataTable _dtVisionTestAppointments;
        public frmWrittenTest(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            InitializeComponent();
        }
        void RefreshGrid()
        {
            _dtVisionTestAppointments = _App.GetAllTestAppointments((int)clsTestType.enTestType.WrittenTest);
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
        }

        private void frmWrittenTest_Load(object sender, EventArgs e)
        {
            _App = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            crtApplicationInfo2.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseApplicationID);
            _dtVisionTestAppointments = _App.GetAllTestAppointments((int)clsTestType.enTestType.WrittenTest);
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //get the ID of the appointment
            int appointmentID = Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value);
            if (clsTestAppointments.Find(appointmentID).IsLocked)
            {
                editToolStripMenuItem.Enabled = false;
                takeTestToolStripMenuItem.Enabled = false;
            }
            else
            {
                editToolStripMenuItem.Enabled = true;
                takeTestToolStripMenuItem.Enabled = true;

            }

        }

        private void btnAddNewUserButton_Click(object sender, EventArgs e)
        {
            frmWrittenTestAppointment frm = new frmWrittenTestAppointment(_LocalDrivingLicenseApplicationID);
            frm.ctrlScheduleTest1.OnAppointmentSaved += RefreshGrid;
            frm.ctrlScheduleTest1.TestType = clsTestType.enTestType.WrittenTest;
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            
            frmWrittenTestAppointment frm = new frmWrittenTestAppointment(_LocalDrivingLicenseApplicationID, Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value));
            frm.ctrlScheduleTest1.OnAppointmentSaved += RefreshGrid;
            frm.ctrlScheduleTest1.TestType = clsTestType.enTestType.WrittenTest;
            frm.ShowDialog();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeWrittenTest frm = new frmTakeWrittenTest(Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value));
            frm.OnTestTaken += RefreshGrid;
            frm.ShowDialog();
        }
    }
}
