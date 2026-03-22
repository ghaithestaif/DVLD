using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { enUpdate, enAddnew }
        public enMode Mode;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public int ApplicationID { get; set; }
        public DVLD_Business.People ApplicantPerson{ get; set; }
        public DateTime ApplicationDate { get; set; }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public int ApplicationTypeID { get; set; }

        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {
            get {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                        
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                        
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }



            }
        }

        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public   clsUser CreatedByUser{ get; set; }

        public clsApplication()
        {
            Mode = enMode.enAddnew;
            ApplicationID = -1;
        }

        private clsApplication(
            int applicationID,
            int applicantPersonID,
            DateTime applicationDate,
            int applicationTypeID,
            byte applicationStatus,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID)
        {
            ApplicationID = applicationID;
             ApplicantPerson= People.Find(applicantPersonID);
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = (enApplicationStatus)applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUser = clsUser.Find(createdByUserID);
            Mode = enMode.enUpdate;
        }

        // Business operations
        private int _AddNew()
        {
            return DVLD_DataAccess.clsApplicationData.AddNewApplication(
                ApplicantPerson.PersonID,
                ApplicationDate,
                ApplicationTypeID,
                ((byte)ApplicationStatus),
                LastStatusDate,
                PaidFees,
                CreatedByUser.UserID
            );
        }

        private bool _Update()
        {
            return DVLD_DataAccess.clsApplicationData.UpdateApplication(
                ApplicationID,
                ApplicantPerson.PersonID,
                ApplicationDate,
                ApplicationTypeID,
               (byte) ApplicationStatus,
                LastStatusDate,
                PaidFees,
                CreatedByUser.UserID
            );
        }

        public bool Save()
        {
            if (Mode == enMode.enAddnew)
            {
                ApplicationID = _AddNew();
                Mode = enMode.enUpdate;
                return ApplicationID > 0;
            }
            else if (Mode == enMode.enUpdate)
            {
                return _Update();
            }
            else
            {
                return false;
            }
        }

        public static clsApplication Find(int applicationID)
        {
            int applicantPersonID = -1;
            DateTime applicationDate = DateTime.MinValue;
            int applicationTypeID = 0;
            byte applicationStatus = 0;
            DateTime lastStatusDate = DateTime.MinValue;
            decimal paidFees = 0m;
            int createdByUserID = 0;

            bool found = DVLD_DataAccess.clsApplicationData.FindApplicationByID(
                applicationID,
                ref applicantPersonID,
                ref applicationDate,
                ref applicationTypeID,
                ref applicationStatus,
                ref lastStatusDate,
                ref paidFees,
                ref createdByUserID
            );

            if (!found)
                return null;

            return new clsApplication(
                applicationID,
                applicantPersonID,
                applicationDate,
                applicationTypeID,
                applicationStatus,
                lastStatusDate,
                paidFees,
                createdByUserID
            );
        }
        public bool Cancel()
        {
            return DVLD_DataAccess.clsApplicationData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Cancelled);
        }

        public bool SetComplete()
        {
            return DVLD_DataAccess.clsApplicationData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Completed);
        }

    }
}
