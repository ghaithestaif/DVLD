using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        // Composition
        public clsApplication ApplicationInfo
        {
            get { return clsApplication.Find(ApplicationID); }
        }
        public clsDriver DriverInfo
        {
            get { return clsDriver.Find(DriverID); }
        }
        public clsLicenseClass LicenseClassInfo
        {
            get { return clsLicenseClass.Find(LicenseClassID); }
        }

        // Constructor for AddNew
        public clsLicense()
        {
            this.LicenseID = -1;
            Mode = enMode.AddNew;
        }

        // Private constructor for Find
        private clsLicense(
            int LicenseID,
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            decimal PaidFees,
            bool IsActive,
            byte IssueReason,
            int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        // 🔍 Find
        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = 0, DriverID = 0, LicenseClass = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicensesData.FindLicenseByID(
                LicenseID,
                ref ApplicationID,
                ref DriverID,
                ref LicenseClass,
                ref IssueDate,
                ref ExpirationDate,
                ref Notes,
                ref PaidFees,
                ref IsActive,
                ref IssueReason,
                ref CreatedByUserID))
            {
                return new clsLicense(
                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    IssueReason,
                    CreatedByUserID);
            }

            return null;
        }

        // ➕ Add New (PRIVATE)
        private bool _AddNew()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(
                ApplicationID,
                DriverID,
                LicenseClassID,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                IssueReason,
                CreatedByUserID);

            return (this.LicenseID != -1);
        }

        // ✏️ Update (PRIVATE)
        private bool _Update()
        {
            return clsLicensesData.UpdateLicense(
                LicenseID,
                ApplicationID,
                DriverID,
                LicenseClassID,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                IssueReason,
                CreatedByUserID);
        }

        // 💾 Save (PUBLIC)
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

        public bool Delete()
        {
            return clsLicensesData.DeleteLicense(this.LicenseID);
        }


        public static DataTable GetAll()
        {
            return clsLicensesData.GetAllLicenses();
        }
        public static bool DoesPersonHaveLicesne(int Person, int LicenseClassID)
        {
            return  clsLicensesData.DoesPersonHaveLicesne(Person, LicenseClassID);
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return clsLicensesData.GetLicenseIDByApplicationID(ApplicationID);
        }
        public static DataTable GetAllPersonLicenses(int PersonID)
        {
            return clsLicensesData.GetAllPersonLicenses(PersonID);
        }
        public int IssueInternationalLicense(int UserID)
        {
            //check if this person already has this License
            if (clsInternationalLicense.DoesDriverHaveInternationalLicense(this.DriverID,this.LicenseClassID))
            {
                return -1; 
            }
            //check if the person's local driving license is active or not
            if (this.IsActive==false) 
            {
                return -1;
            }

            //  create the object the application object
            clsInternationalLicense internationalLicense = new clsInternationalLicense();
            internationalLicense.DriverID = this.DriverID;
            internationalLicense.ApplicantPerson = this.DriverInfo.PersonInfo;
            internationalLicense.ApplicationDate=DateTime.Now;
            internationalLicense.ApplicationStatus=clsApplication.enApplicationStatus.New;
            internationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            internationalLicense.CreatedByUser = clsUser.Find(UserID);
            internationalLicense.DriverInfo=clsDriver.Find(DriverID);
            internationalLicense.IssueDate=DateTime.Now;
            internationalLicense.IsActive = true;
            internationalLicense.IssuedUsingLocalLicenseID = this.LicenseID;
            internationalLicense.ExpirationDate = internationalLicense.IssueDate.AddYears(1);
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.PaidFees = 51;


            if (!internationalLicense.Save())
            {
                return -1;
            }

            return internationalLicense.InternationalLicenseID;

        }


        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now) ? true : false;
        }



        public clsLicense RenewLicense(string Notes)
        {
            //check if the licsens is expired or not 
            if (!IsLicenseExpired())
                return null;





            //create a new application 
            clsApplication RenewApp =new clsApplication();
            RenewApp.ApplicantPerson=this.ApplicationInfo.ApplicantPerson;
            RenewApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            RenewApp.ApplicationDate = DateTime.Now;
            RenewApp.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            RenewApp.CreatedByUser = clsUser.Find(this.CreatedByUserID);
            RenewApp.LastStatusDate= DateTime.Now;
            RenewApp.PaidFees = clsApplicationType.Find(RenewApp.ApplicationTypeID).Fees;

            //save if
            if (!RenewApp.Save())
            {
                return null;
            }


            //create a new License and deactivate the old license

            


            clsLicenseClass LicenseClass=clsLicenseClass.Find(this.LicenseClassID);
            clsLicense NewLicense = new clsLicense();

            NewLicense.IssueReason = (int)clsLicense.enIssueReason.Renew;
            NewLicense.ApplicationID=RenewApp.ApplicationID;
            NewLicense.CreatedByUserID = this.CreatedByUserID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.ExpirationDate= DateTime.Now.AddYears(LicenseClass.DefaultValidityLength);
            NewLicense.Notes=Notes;
            NewLicense.PaidFees =Convert.ToDecimal(LicenseClass.ClassFees);
            NewLicense.IsActive=true;
            NewLicense.IssueDate=DateTime.Now;


            if (!NewLicense.Save())
            {
                RenewApp.Cancel(); 
                return null;
            }
            //deactivate the old license
            this.IsActive = false;
            if (!this.Save())
            {
                RenewApp.Cancel();
                NewLicense.Delete();
            }

            return NewLicense;


        }


        public clsLicense ReplaceLicense(string Notes, clsApplication.enApplicationType Type)
        {


            //check if the application type is valid for replacement

            if (Type!= clsApplication.enApplicationType.ReplaceDamagedDrivingLicense && Type != clsApplication.enApplicationType.ReplaceLostDrivingLicense) 
            {
                return null;
            }
            if (clsDetainLicense.IsLicenseDetained(this.LicenseID))
            {
                return null;
            }



            //check if the licsens is expired or not 
            if (this.IsLicenseExpired())
                return null;
            //create a new application 
            clsApplication ReplaceApp = new clsApplication();
            ReplaceApp.ApplicantPerson = this.ApplicationInfo.ApplicantPerson;
            ReplaceApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            ReplaceApp.ApplicationDate = DateTime.Now;
            ReplaceApp.ApplicationTypeID = (int)Type;
            ReplaceApp.CreatedByUser = clsUser.Find(this.CreatedByUserID);
            ReplaceApp.LastStatusDate = DateTime.Now;
            ReplaceApp.PaidFees = clsApplicationType.Find(ReplaceApp.ApplicationTypeID).Fees;

            //save if
            if (!ReplaceApp.Save())
            {
                return null;
            }


            //create a new License and deactivate the old license
            


            clsLicense ReplaceLicense = new clsLicense();
            
            ReplaceLicense.IssueReason = (Type == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense)? (byte)clsLicense.enIssueReason.DamagedReplacement : (byte)clsLicense.enIssueReason.LostReplacement;
            ReplaceLicense.ApplicationID = ReplaceApp.ApplicationID;
            ReplaceLicense.CreatedByUserID = this.CreatedByUserID;
            ReplaceLicense.DriverID = this.DriverID;
            ReplaceLicense.LicenseClassID = this.LicenseClassID;
            ReplaceLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(this.LicenseClassID).DefaultValidityLength);
            ReplaceLicense.Notes = Notes;
            ReplaceLicense.PaidFees = Convert.ToDecimal(clsLicenseClass.Find(this.LicenseClassID).ClassFees);
            ReplaceLicense.IsActive = true;
            ReplaceLicense.IssueDate = DateTime.Now;
            

            if(!ReplaceLicense.Save())
            {
                
                ReplaceApp.Cancel(); // if you have delete

                return null;

            }

            this.IsActive = false;
            if (!this.Save())
            {
                ReplaceApp.Cancel();
                ReplaceLicense.Delete(); 
                return null;

            }
            return ReplaceLicense;


        }
        public  bool ReleaseLicense( int UserID, ref int ApplicationID)
        {
            if (!clsDetainLicense.IsLicenseDetained(this.LicenseID))
            {
                return false; // License is not detained, cannot release
            }
            //create a new release application for the License
            
            clsApplication releaseApp = new clsApplication();

            releaseApp.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            releaseApp.ApplicationDate = DateTime.Now;
            releaseApp.ApplicantPerson = clsPeople.Find(this.DriverInfo.PersonID);
            releaseApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            releaseApp.CreatedByUser = clsUser.Find(UserID);
            releaseApp.LastStatusDate = DateTime.Now;
            releaseApp.PaidFees = clsApplicationType.Find(releaseApp.ApplicationTypeID).Fees;

            if(!releaseApp.Save())
            {
                return false;
            }

            ApplicationID= releaseApp.ApplicationID;
            if (!clsDetainLicenseData.ReleaseLicense(LicenseID, releaseApp.ApplicationID, UserID))
            {
                //rollback
                releaseApp.Cancel();
                return false;

            }

            return true;
        }

        public bool DetainLicense(int LicenseID,decimal Fees)
        {
            return clsDetainLicense.DetainLicense(this,Fees,this.CreatedByUserID);
        }



    }
}