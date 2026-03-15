using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestAppointments
    {

        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }

        public clsTestType TestType = new clsTestType();
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; }


        public clsTestAppointments()
        {
            TestAppointmentID = -1;
            Mode = enMode.AddNew;
        }

        private clsTestAppointments(
            int TestAppointmentID,
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked,
            int? RetakeTestApplicationID)
        {

            this.TestAppointmentID = TestAppointmentID;
            TestType=clsTestType.Find(TestTypeID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            Mode = enMode.Update;
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {

            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            bool isFound =
                clsTestAppointmentsData.Find(
                    TestAppointmentID,
                    ref TestTypeID,
                    ref LocalDrivingLicenseApplicationID,
                    ref AppointmentDate,
                    ref PaidFees,
                    ref CreatedByUserID,
                    ref IsLocked,
                    ref RetakeTestApplicationID);

            if (isFound)
            {
                return new clsTestAppointments(
                    TestAppointmentID,
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked,
                    RetakeTestApplicationID);
            }

            return null;
        }

        private bool _AddNew()
        {

            this.TestAppointmentID =
                clsTestAppointmentsData.AddNewTestAppointment(
                    TestType.TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked,
                    RetakeTestApplicationID);

            return (TestAppointmentID != -1);
        }

        private bool _Update()
        {

            return clsTestAppointmentsData.UpdateTestAppointment(
                TestAppointmentID,
                TestType.TestTypeID,
                LocalDrivingLicenseApplicationID,
                AppointmentDate,
                PaidFees,
                CreatedByUserID,
                IsLocked,
                RetakeTestApplicationID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static DataTable GetAll()
        {
            return clsTestAppointmentsData.GetAllTestAppointments();
        }

        public static bool Delete(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointment(TestAppointmentID);
        }




    }
}