using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        // 🔗 Composition with Person
        public DVLD_Business.clsPeople PersonInfo
        {
            get { return DVLD_Business.clsPeople.Find(PersonID); }
        }

        // 🟢 Constructor (Add New)
        public clsDriver()
        {
            this.DriverID = -1;
            Mode = enMode.AddNew;
        }

        // 🔒 Private constructor (for Find)
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            Mode = enMode.Update;
        }

        // 🔍 Find
        public static clsDriver Find(int DriverID)
        {
            int PersonID = 0, CreatedByUserID = 0;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.FindDriverByID(
                DriverID,
                ref PersonID,
                ref CreatedByUserID,
                ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }

            return null;
        }

        // ➕ Add New (PRIVATE)
        private bool _AddNew()
        {
            this.DriverID = clsDriverData.AddNewDriver(
                PersonID,
                CreatedByUserID,
                CreatedDate);

            return (this.DriverID != -1);
        }

        // ✏️ Update (PRIVATE)
        private bool _Update()
        {
            return clsDriverData.UpdateDriver(
                DriverID,
                PersonID,
                CreatedByUserID,
                CreatedDate);
        }

        // 💾 Save
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

        // ❌ Delete
        public static bool Delete(int DriverID)
        {
            return clsDriverData.DeleteDriver(DriverID);
        }

        // 📊 Get All
        public static DataTable GetAll()
        {
            return clsDriverData.GetAllDrivers();
        }
        public static bool IsPersonADriver(int PersonID)
        {
            return clsDriverData.IsPersonADriver(PersonID);
        }
        public static int FindByPersonID(int PersonID)
        {
            return clsDriverData.FindByPersonID(PersonID);
        }
    }
}