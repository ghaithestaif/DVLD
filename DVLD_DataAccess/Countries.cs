using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class Countries
    {
        static public DataTable GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
            string query = "SELECT CountryID, CountryName FROM [dbo].[Countries]";
            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                // Log ex.Message if needed
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

    }
}
