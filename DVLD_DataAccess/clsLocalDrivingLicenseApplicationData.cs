using DVLD_General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace DVLD_DataAccess
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        //making a dictionary for the enum to string mapping for the filter options
        private static readonly Dictionary<DVLD_General.Common.LocalDrivingLicenseApplicationFilter, string> _ColumnMap
             = new Dictionary<DVLD_General.Common.LocalDrivingLicenseApplicationFilter, string>()
         {
            { DVLD_General.Common.LocalDrivingLicenseApplicationFilter.FullName, "FullName" },
            { DVLD_General.Common.LocalDrivingLicenseApplicationFilter.ID, "LocalDrivingLicenseApplicationID" },
            { DVLD_General.Common.LocalDrivingLicenseApplicationFilter.NationalNo, "NationalNo" },
            { DVLD_General.Common.LocalDrivingLicenseApplicationFilter.status, "Status" },

         };
        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID,
            int LicenseClassID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = @"
INSERT INTO LocalDrivingLicenseApplications
    (ApplicationID, LicenseClassID)
VALUES
    (@ApplicationID, @LicenseClassID);
SELECT CAST(SCOPE_IDENTITY() AS int);";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    cmd.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return (result == null || result == DBNull.Value) ? -1 : Convert.ToInt32(result);
                }
            }
            catch (Exception)
            {
                // Consider logging the exception here
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }

        public static bool UpdateLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int LicenseClassID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = @"
UPDATE LocalDrivingLicenseApplications SET
    ApplicationID = @ApplicationID,
    LicenseClassID = @LicenseClassID
WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    cmd.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;
                    cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                // Consider logging the exception here
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                // Consider logging the exception here
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }

        public static bool FindLocalDrivingLicenseApplicationByID(
            int LocalDrivingLicenseApplicationID,
            ref int ApplicationID,
            ref int LicenseClassID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = @"
SELECT ApplicationID, LicenseClassID
FROM LocalDrivingLicenseApplications
WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ApplicationID = rdr.GetInt32(rdr.GetOrdinal("ApplicationID"));
                            LicenseClassID = rdr.GetInt32(rdr.GetOrdinal("LicenseClassID"));
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                // Consider logging the exception here
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = "SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID FROM LocalDrivingLicenseApplications";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                // Consider logging the exception here
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }

        static public bool DoesPersonHaveAnActiveApplication(int ApplicantPersonID, int ApplicationClassID,int ApplicationTypeID)
        {
            SqlConnection cnn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
            string Query = $@"SELECT ActiveApplicationID = Applications.ApplicationID
                         FROM Applications
                         INNER JOIN LocalDrivingLicenseApplications 
                             ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                         WHERE ApplicantPersonID = @ApplicantPersonID
                         AND ApplicationTypeID = @ApplicationTypeID
                         AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                         AND ApplicationStatus = 1; ";

            using (SqlCommand cmd = new SqlCommand(Query, cnn))
            {
                cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
                cmd.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = ApplicationClassID;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;

                cnn.Open();
                object result = cmd.ExecuteScalar();

                return (result == null) ? false : true;
            }

        }


        public static DataTable GetAllApplications()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                string query = @"SELECT *
                              FROM LocalDrivingLicenseApplications_View
                              order by ApplicationDate Desc";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                // Log or rethrow as needed
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }



    }
}