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

namespace DVLD.Tests.Appointments
{
    public partial class frmVisionTestsAppointment : Form
    {
        int _LocalDrivingLicenseApplicationID;
        int _ApppointmentID;

        public frmVisionTestsAppointment(int LocalDrivingLicenseApplicationID,int ApppointmentID=-1)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
                _ApppointmentID = ApppointmentID;
            InitializeComponent();
        }
        
        private void frmVisionTestsAppointment_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID,_ApppointmentID);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
