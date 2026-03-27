using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsInternationalLicense : clsApplication
    {
        // Define Modes
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // Properties mapping to the database columns
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo{get; set;}

        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        // Default Constructor (Add New Mode)
        public clsInternationalLicense()
        {
            DriverInfo = null;
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;

            base.ApplicationDate = DateTime.Now;
            base.CreatedByUser = null;
            base.ApplicantPerson = null;
            base.ApplicationStatus = enApplicationStatus.New;
            base.ApplicationTypeID = (int)enApplicationType.NewInternationalLicense;
            base.PaidFees = 0; 

            Mode = enMode.AddNew;
        }

        // Private Constructor (Update Mode - Used by Find)
        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID,
            int PersonID,DateTime ApplicationDate, decimal PaidFees ,enApplicationStatus ApplicationStatus)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;

            this.DriverInfo = clsDriver.Find(DriverID);
            base.CreatedByUser =clsUser.Find(CreatedByUserID);
            base.ApplicationDate = ApplicationDate;
            base.ApplicantPerson = clsPeople.Find(PersonID);
            base.ApplicationStatus = ApplicationStatus;
            base.ApplicationTypeID = (int)enApplicationType.NewInternationalLicense;
            base.PaidFees = PaidFees;
            Mode = enMode.Update;
        }

        // Private Add New Method
        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(
                this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUser.UserID);

            return (this.InternationalLicenseID != -1);
        }

        // Private Update Method
        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate,
                this.IsActive, this.CreatedByUser.UserID);
        }

        // Find Method
        public static clsInternationalLicense Find(int InternationalLicenseID)
        {

            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            //find the application object
            


            if (clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID,
                ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {

                clsApplication app = clsApplication.Find(ApplicationID);



                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,
                    IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID,app.ApplicantPerson.PersonID,app.ApplicationDate,app.PaidFees,app.ApplicationStatus);
            }
            else
            {
                return null;
            }
        }

        // Save Method (Handles both Add and Update)
        public bool Save()
        {
            if (!base.Save())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update; // Change mode after successful insert
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }

        // Get All Method
        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        // Get Driver Specific Licenses
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }

        // Get Active License ID
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }
        public static  bool DoesDriverHaveInternationalLicense(int DriverID,int LicenseClassID)
        {
            return clsInternationalLicenseData.DoesDriverHaveInternationalLicense(DriverID, LicenseClassID);

        } 
    }
}