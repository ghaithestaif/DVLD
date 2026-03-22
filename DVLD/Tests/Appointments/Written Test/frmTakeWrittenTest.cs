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

namespace DVLD.Tests.Appointments.Written_Test
{
    public partial class frmTakeWrittenTest : Form
    {
        int _AppointmentID;
        public event Action OnTestTaken;
        public frmTakeWrittenTest(int Appointment)
        {
            _AppointmentID = Appointment;
            InitializeComponent();
        }

        private void frmTakeWrittenTest_Load(object sender, EventArgs e)
        {
            crtTakeTest1.LoadData(_AppointmentID,clsTestType.enTestType.WrittenTest);
        }
        bool _HandlePassedTest()
        {
            crtTakeTest1.TestAppointments.IsLocked = true;
            return (!crtTakeTest1.TestAppointments.Save()) ? false : true;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTests TestResult = new clsTests();
            TestResult.TestAppointmentID = _AppointmentID;
            TestResult.TestResult = (rbFail.Checked) ? false : true;
            TestResult.Notes = txtNotes.Text;
            TestResult.CreatedByUserID = Global_Classes.General.CurrentUser.UserID;
            if (!TestResult.Save())
            {
                MessageBox.Show("Error saving test result. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }
            else
            {

                if (!_HandlePassedTest())
                {
                    MessageBox.Show("Error saving test result. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Test result saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnTestTaken?.Invoke();


                this.Close();
            }
        }
    }
}
