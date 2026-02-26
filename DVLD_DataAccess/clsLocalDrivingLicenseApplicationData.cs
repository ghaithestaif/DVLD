using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class clsLocalDrivingLicenseApplicationData
    {
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
    }
}