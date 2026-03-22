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
    public partial class frmWrittenTestAppointment : Form
    {
        int _LocalDrivingLicenseApplicationID;
        int _ApppointmentID;
        
        public frmWrittenTestAppointment(int LocalDrivingLicenseApplicationID, int ApppointmentID = -1)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _ApppointmentID = ApppointmentID;
            InitializeComponent();
        }

        private void frmWrittenTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _ApppointmentID);
            ctrlScheduleTest1.TestType = clsTestType.enTestType.WrittenTest;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
