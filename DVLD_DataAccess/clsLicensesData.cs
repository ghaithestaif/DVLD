using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLicensesData
    {
        public static int AddNewLicense(
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
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = @"
INSERT INTO Licenses
(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
 Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
VALUES
(@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
 @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);

SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    cmd.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    return (result == null) ? -1 : Convert.ToInt32(result);
                }
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        public static bool UpdateLicense(
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
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = @"
UPDATE Licenses SET
    ApplicationID = @ApplicationID,
    DriverID = @DriverID,
    LicenseClass = @LicenseClass,
    IssueDate = @IssueDate,
    ExpirationDate = @ExpirationDate,
    Notes = @Notes,
    PaidFees = @PaidFees,
    IsActive = @IsActive,
    IssueReason = @IssueReason,
    CreatedByUserID = @CreatedByUserID
WHERE LicenseID = @LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    cmd.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        public static bool DeleteLicense(int LicenseID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        public static bool FindLicenseByID(
            int LicenseID,
            ref int ApplicationID,
            ref int DriverID,
            ref int LicenseClass,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref string Notes,
            ref decimal PaidFees,
            ref bool IsActive,
            ref byte IssueReason,
            ref int CreatedByUserID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID ";
                

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationID = (int)reader["ApplicationID"];
                            DriverID = (int)reader["DriverID"];
                            LicenseClass = (int)reader["LicenseClass"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpirationDate = (DateTime)reader["ExpirationDate"];
                            Notes = reader["Notes"] as string;
                            PaidFees = (decimal)reader["PaidFees"];
                            IsActive = (bool)reader["IsActive"];
                            IssueReason = (byte)reader["IssueReason"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];

                            return true;
                        }
                    }
                }
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = "SELECT * FROM Licenses";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }

            return dt;
        }


        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            SqlConnection cnn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
            string Query = $@"
        select Licenses.LicenseID

 from Licenses

 where ApplicationID = @ApplicationID and IsActive =1";
            try
            {
                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                    cnn.Open();
                    object result = cmd.ExecuteScalar();

                    return (result == null) ? -1 : (int)result;
                }
            }
            finally
            {
                if (cnn != null)
                    cnn.Dispose();

            }

        }




        public static bool DoesPersonHaveLicesne(int Person, int LicenseClassID)
        {
            SqlConnection cnn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
            string Query = $@"SELECT top 1 found=1
           FROM     Licenses INNER JOIN
                  Drivers ON Licenses.DriverID = Drivers.DriverID
				  where Drivers.PersonID=@Person and Licenses.LicenseClass=@LicenseClassID";
            try
            {
                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    cmd.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;
                    cmd.Parameters.Add("@Person", SqlDbType.Int).Value = Person;

                    cnn.Open();
                    object result = cmd.ExecuteScalar();

                    return (result == null) ? false : true;
                }
            }
            finally
            {
                if (cnn != null)
                    cnn.Dispose();

            }

        }

        public static DataTable GetAllPersonLicenses(int driverID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = $@"SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName,Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
            FROM     Drivers INNER JOIN
                  Licenses ON Drivers.DriverID = Licenses.DriverID INNER JOIN
                  LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
           WHERE  (Drivers.DriverID = @driverID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@driverID", SqlDbType.Int).Value = driverID;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }

            return dt;
        }








    }
}