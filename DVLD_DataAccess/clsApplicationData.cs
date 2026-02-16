using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {

        public static int AddNewApplication(
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            decimal PaidFees,
            int CreatedByUserID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = @"INSERT INTO Applications
                            (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                            VALUES
                            (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                            SELECT CAST(SCOPE_IDENTITY() AS int);";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
                    cmd.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = ApplicationDate;
                    cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                    cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
                    cmd.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = LastStatusDate;
                    cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                    cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result == null ? -1 : Convert.ToInt32(result);
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

        public static bool UpdateApplication(
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            decimal PaidFees,
            int CreatedByUserID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = @"UPDATE Applications SET
                                ApplicantPersonID = @ApplicantPersonID,
                                ApplicationDate = @ApplicationDate,
                                ApplicationTypeID = @ApplicationTypeID,
                                ApplicationStatus = @ApplicationStatus,
                                LastStatusDate = @LastStatusDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID
                            WHERE ApplicationID = @ApplicationID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
                    cmd.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = ApplicationDate;
                    cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                    cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
                    cmd.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = LastStatusDate;
                    cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                    cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
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

        public static bool DeleteApplication(int ApplicationID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
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

        public static bool FindApplicationByID(
            int ApplicationID,
            ref int ApplicantPersonID,
            ref DateTime ApplicationDate,
            ref int ApplicationTypeID,
            ref byte ApplicationStatus,
            ref DateTime LastStatusDate,
            ref decimal PaidFees,
            ref int CreatedByUserID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = @"SELECT ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
                            FROM Applications
                            WHERE ApplicationID = @ApplicationID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ApplicantPersonID = rdr.GetInt32(rdr.GetOrdinal("ApplicantPersonID"));
                            ApplicationDate = rdr.GetDateTime(rdr.GetOrdinal("ApplicationDate"));
                            ApplicationTypeID = rdr.GetInt32(rdr.GetOrdinal("ApplicationTypeID"));
                            ApplicationStatus = rdr.GetByte(rdr.GetOrdinal("ApplicationStatus"));
                            LastStatusDate = rdr.GetDateTime(rdr.GetOrdinal("LastStatusDate"));
                            PaidFees = rdr.GetDecimal(rdr.GetOrdinal("PaidFees"));
                            CreatedByUserID = rdr.GetInt32(rdr.GetOrdinal("CreatedByUserID"));
                            return true;
                        }
                    }
                }
                return false;
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

        public static DataTable GetAllApplications()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
                var sql = "SELECT ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID FROM Applications";
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
