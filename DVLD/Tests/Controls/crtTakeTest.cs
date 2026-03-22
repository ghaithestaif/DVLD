using DVLD.Properties;
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

namespace DVLD.Tests.TestTypes
{
    public partial class crtTakeTest : UserControl
    {
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        clsTestAppointments _TestAppointments = new clsTestAppointments();
        public clsTestAppointments TestAppointments { 
        
        
            get
            {
                return _TestAppointments;
            }
            private set
            {
                _TestAppointments = value;
            }


        }
        public crtTakeTest()
        {
            InitializeComponent();
            
        }
        clsTestType.enTestType _TestType;
        public clsTestType.enTestType TestType
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value; // VERY IMPORTANT

                switch (value)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            lblTitle.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            lblTitle.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }

                    case clsTestType.enTestType.StreetTest:
                        {
                            lblTitle.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            break;
                        }
                }
            }
        }
        private void crtTakeTest_Load(object sender, EventArgs e)
        {

        }
       public  void LoadData(int AppointmentID, clsTestType.enTestType TestType)
        {
            _TestAppointments=clsTestAppointments.Find(AppointmentID);
            
            _LocalDrivingLicenseApplication= clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_TestAppointments.LocalDrivingLicenseApplicationID);
            _TestType = TestType;
            
            //check if the data is loaded successfully
            if (_LocalDrivingLicenseApplication == null || _TestAppointments == null)
            {
                return;
            }

            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblFees.Text = _TestAppointments.PaidFees.ToString();
            lblFullName.Text = _LocalDrivingLicenseApplication.ApplicantPerson.FullName;
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblTrial.Text = _LocalDrivingLicenseApplication.NumberOfTestsTrials(((int)_TestType)).ToString();
            lblDate.Text = _TestAppointments.AppointmentDate.ToString("dd/MM/yyyy");
            lblFees.Text = _TestAppointments.PaidFees.ToString("C");






        }

    }
}
