using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DVLD_DataAccess
{
    public class clsDriverData
    {
        public static int AddNewDriver(
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = @"
             INSERT INTO Drivers
             (PersonID, CreatedByUserID, CreatedDate)
             VALUES
             (@PersonID, @CreatedByUserID, @CreatedDate);
             
             SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                    cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = CreatedDate;

                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    return (result == null || result == DBNull.Value)
                        ? -1
                        : Convert.ToInt32(result);
                }
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

        public static bool UpdateDriver(
            int DriverID,
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = @"
               UPDATE Drivers SET
                   PersonID = @PersonID,
                   CreatedByUserID = @CreatedByUserID,
                   CreatedDate = @CreatedDate
               WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                    cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = CreatedDate;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
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

        public static bool DeleteDriver(int DriverID)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = "DELETE FROM Drivers WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
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

        
            public static bool IsPersonADriver(int PersonID)
           {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = $@"SELECT top 1 found=1
                FROM People INNER JOIN
                                  Drivers ON People.PersonID = Drivers.PersonID
                where People.PersonID=@PersonID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                    conn.Open();

                    object result= cmd.ExecuteScalar();
                    return (result==null)?false :true;
                }
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

        

            public static int FindByPersonID(int PersonID)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = $@"SELECT DriverID
                   FROM Drivers
                   where Drivers.PersonID=@PersonID
                   ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    return (result == null) ? -1 : (int)result;
                }
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

        public static bool FindDriverByID(
            int DriverID,
            ref int PersonID,
            ref int CreatedByUserID,
            ref DateTime CreatedDate)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = @"
SELECT PersonID, CreatedByUserID, CreatedDate
FROM Drivers
WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                            CreatedByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                            CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));

                            return true;
                        }
                    }
                }

                return false;
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

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(AppSettings.ConnectionString);

                string query = "select * from Drivers_View";

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
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();

                    conn.Dispose();
                }
            }

            return dt;
        }




    }
}