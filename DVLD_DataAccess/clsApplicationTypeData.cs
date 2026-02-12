using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {
        public static bool Find(
    int applicationTypeID,
    ref string applicationTypeTitle,
    ref decimal applicationFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString))
            {
                string query = @"SELECT ApplicationTypeTitle, ApplicationFees
                         FROM ApplicationTypes
                         WHERE ApplicationTypeID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", applicationTypeID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                            applicationFees = (decimal)reader["ApplicationFees"];

                            isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection connection = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString))
            {
                string query = "SELECT ApplicationTypeID, ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        public static bool UpdateApplicationType(
                 int applicationTypeID,
                 string applicationTypeTitle,
                 decimal applicationFees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString))
            {
                string query = @"UPDATE ApplicationTypes
                         SET ApplicationTypeTitle = @Title,
                             ApplicationFees = @Fees
                         WHERE ApplicationTypeID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", applicationTypeID);
                    command.Parameters.AddWithValue("@Title", applicationTypeTitle);
                    command.Parameters.AddWithValue("@Fees", applicationFees);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }

    }


}

