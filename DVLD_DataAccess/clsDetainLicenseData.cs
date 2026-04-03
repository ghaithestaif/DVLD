using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetainLicenseData
    {
        public static int AddNewDetain(
            int LicenseID,
            DateTime DetainDate,
            decimal FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = @"
INSERT INTO DetainedLicenses
(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
VALUES
(@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
                    cmd.Parameters.AddWithValue("@FineFees", FineFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
                    cmd.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleasedByUserID", (object)ReleasedByUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return (result == null || result == DBNull.Value) ? -1 : Convert.ToInt32(result);
                }
            }
        }

        public static bool UpdateDetain(
            int DetainID,
            int LicenseID,
            DateTime DetainDate,
            decimal FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = @"
UPDATE DetainedLicenses SET
LicenseID=@LicenseID,
DetainDate=@DetainDate,
FineFees=@FineFees,
CreatedByUserID=@CreatedByUserID,
IsReleased=@IsReleased,
ReleaseDate=@ReleaseDate,
ReleasedByUserID=@ReleasedByUserID,
ReleaseApplicationID=@ReleaseApplicationID
WHERE DetainID=@DetainID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetainID", DetainID);
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
                    cmd.Parameters.AddWithValue("@FineFees", FineFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
                    cmd.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleasedByUserID", (object)ReleasedByUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteDetain(int DetainID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = "DELETE FROM DetainedLicenses WHERE DetainID=@DetainID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetainID", DetainID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool FindDetainByID(
            int DetainID,
            ref int LicenseID,
            ref DateTime DetainDate,
            ref decimal FineFees,
            ref int CreatedByUserID,
            ref bool IsReleased,
            ref DateTime? ReleaseDate,
            ref int? ReleasedByUserID,
            ref int? ReleaseApplicationID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = @"
SELECT * FROM DetainedLicenses WHERE DetainID=@DetainID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetainID", DetainID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LicenseID = reader.GetInt32(reader.GetOrdinal("LicenseID"));
                            DetainDate = reader.GetDateTime(reader.GetOrdinal("DetainDate"));
                            FineFees = reader.GetDecimal(reader.GetOrdinal("FineFees"));
                            CreatedByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                            IsReleased = reader.GetBoolean(reader.GetOrdinal("IsReleased"));
                            ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReleaseDate"));
                            ReleasedByUserID = reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ReleasedByUserID"));
                            ReleaseApplicationID = reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ReleaseApplicationID"));

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static DataTable GetAllDetains()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses_View"; // assuming you have a view
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }



        public static bool FindDetainByLicenseID(
            int LicenseID ,
            ref int DetainID,
            ref DateTime DetainDate,
            ref decimal FineFees,
            ref int CreatedByUserID,
            ref bool IsReleased,
            ref DateTime? ReleaseDate,
            ref int? ReleasedByUserID,
            ref int? ReleaseApplicationID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = @"
SELECT * FROM DetainedLicenses WHERE LicenseID=@LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DetainID = reader.GetInt32(reader.GetOrdinal("DetainID"));
                            DetainDate = reader.GetDateTime(reader.GetOrdinal("DetainDate"));
                            FineFees = reader.GetDecimal(reader.GetOrdinal("FineFees"));
                            CreatedByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                            IsReleased = reader.GetBoolean(reader.GetOrdinal("IsReleased"));
                            ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReleaseDate"));
                            ReleasedByUserID = reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ReleasedByUserID"));
                            ReleaseApplicationID = reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ReleaseApplicationID"));

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        




        public static bool IsLicenseDetained(int LicenseID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = @"SELECT TOP 1 Found = 1
                     FROM DetainedLicenses
                     WHERE LicenseID = @LicenseID and IsReleased = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    return (result != null && result != DBNull.Value)
                           && Convert.ToInt32(result) == 1;
                }
            }
        }

        public static bool ReleaseLicense(
            int LicenseID,
            int ReleaseApplicationID,
            int ReleasedByUserID)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
            {
                string query = @"
UPDATE DetainedLicenses SET
IsReleased=@IsReleased,
ReleaseDate=@ReleaseDate,
ReleasedByUserID=@ReleasedByUserID,
ReleaseApplicationID=@ReleaseApplicationID
WHERE LicenseID=@LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                    cmd.Parameters.AddWithValue("@IsReleased", true);
                    cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID );
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID );

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }





            }









        }



    }
}
