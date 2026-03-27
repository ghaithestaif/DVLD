using DVLD.Properties;
using DVLD.Tests.Appointments;
using DVLD_Buisness;
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
using static DVLD_Business.clsTestType;
namespace DVLD.Tests
{
    public partial class frmVisionTests : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _App;
        DataTable _dtVisionTestAppointments;
        clsTestType.enTestType _TestType;
        public clsTestType.enTestType TestType
        {
           
            get { return _TestType; }
            set
            {
                _TestType = value;

                switch (_TestType)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            lblTitle.Text = "Vision Test appointment";
                            PictureBox.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            lblTitle.Text = "Written Test appointment";
                            PictureBox.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            lblTitle.Text = "Street Test appointment";
                            PictureBox.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }


        public frmVisionTests(int LocalDrivingLicenseApplicationID,clsTestType.enTestType testtype)
        {
            _TestType = testtype;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            InitializeComponent();
        }




        
        

        private void btnAddNewUserButton_Click(object sender, EventArgs e)
        {
            frmVisionTestsAppointment frm = new frmVisionTestsAppointment(_LocalDrivingLicenseApplicationID, TestType);
            frm.ctrlScheduleTest1.OnAppointmentSaved += RefreshGrid;
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }
        void RefreshGrid()
        {
            _dtVisionTestAppointments = _App.GetAllTestAppointments((int)_TestType);
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestsAppointment frm = new frmVisionTestsAppointment(_LocalDrivingLicenseApplicationID,  TestType, Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value));
            frm.ctrlScheduleTest1.OnAppointmentSaved += RefreshGrid;


            frm.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest( Convert.ToInt32(AppointmentGridView.CurrentRow.Cells["TestAppointmentID"].Value), _TestType);
            frm.OnTestTaken += RefreshGrid;
            frm.ShowDialog();
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

        private void frmVisionTests_Load(object sender, EventArgs e)
        {
            _App = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            crtApplicationInfo2.loadInfoByLocalDrivingLicenseAppplication(_LocalDrivingLicenseApplicationID);
            _dtVisionTestAppointments = _App.GetAllTestAppointments((int)_TestType);
            AppointmentGridView.DataSource = _dtVisionTestAppointments;
            TestType = _TestType;
        }
    }
}
