using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;  
namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {
        public class TestTypeDAL
        {
            public static bool FindByID(
    int TestTypeID,
    ref string TestTypeTitle,
    ref string TestTypeDescription,
    ref decimal TestTypeFees)
            {
                bool isFound = false;

                using (SqlConnection conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString))
                {
                    string query = "SELECT * FROM TestTypes WHERE TestTypeID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", TestTypeID);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                TestTypeTitle = (string)reader["TestTypeTitle"];
                                TestTypeDescription = (string)reader["TestTypeDescription"];
                                TestTypeFees = (decimal)reader["TestTypeFees"];
                            }
                        }
                    }
                }

                return isFound;
            }


            public static DataTable GetAllTypes()
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString))
                {
                    string query = "SELECT * FROM TestTypes";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                return dt;
            }



            public static bool UpdateType(
        int TestTypeID,
        string TestTypeTitle,
        string TestTypeDescription,
        decimal TestTypeFees)
            {
                int rowsAffected = 0;

                using (SqlConnection conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString))
                {
                    string query = @"UPDATE TestTypes
                             SET TestTypeTitle = @Title,
                                 TestTypeDescription = @Description,
                                 TestTypeFees = @Fees
                             WHERE TestTypeID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", TestTypeID);
                        cmd.Parameters.AddWithValue("@Title", TestTypeTitle);
                        cmd.Parameters.AddWithValue("@Description", TestTypeDescription);
                        cmd.Parameters.AddWithValue("@Fees", TestTypeFees);

                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                return (rowsAffected > 0);
            }
        }
    
    
    
    
        
    }

}
