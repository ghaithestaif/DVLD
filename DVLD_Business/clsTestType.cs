using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccess.clsTestTypeData;

namespace DVLD_Business
{
    
public class  clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestType() { }

        public clsTestType(int id, string title, string description, decimal fees)
        {
            TestTypeID = id;
            TestTypeTitle = title;
            TestTypeDescription = description;
            TestTypeFees = fees;
        }

        // Get All
        public static DataTable GetAllTypes()
        {
            return TestTypeDAL.GetAllTypes();
        }

        public static clsTestType Find(int TestTypeID)
        {
            string title = "";
            string description = "";
            decimal fees = 0;

            bool isFound = TestTypeDAL.FindByID(
                TestTypeID,
                ref title,
                ref description,
                ref fees);

            if (isFound)
            {
                return new clsTestType(
                    TestTypeID,
                    title,
                    description,
                    fees);
            }
            else
                return null;
        }

        // Update
        public bool Save()
        {
            return TestTypeDAL.UpdateType(
                this.TestTypeID,
                this.TestTypeTitle,
                this.TestTypeDescription,
                this.TestTypeFees);
        }
    }

}

