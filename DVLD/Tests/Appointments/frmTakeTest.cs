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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
         int _AppointmentID;
         clsTestType.enTestType _TestType;
       public event Action OnTestTaken;
        public frmTakeTest( int AppointmentID, clsTestType.enTestType TestType)
        {
                _AppointmentID = AppointmentID;
                _TestType = TestType;
            InitializeComponent();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            crtTakeTest1.LoadData( _AppointmentID, _TestType);
            crtTakeTest1.TestType = _TestType;

        }

        bool _HandlePassedTest()
        {
            crtTakeTest1.TestAppointments.IsLocked = true;
            return (!crtTakeTest1.TestAppointments.Save()) ? false : true;
                

        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
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
