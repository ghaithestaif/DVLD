using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public static DataTable GetAll()
        {
            // This method should contain the logic to retrieve all license classes from the database.
            SqlConnection conn = new SqlConnection(DVLD_DataAccess.AppSettings.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM LicenseClasses", conn);
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter dAdapter =new SqlDataAdapter(cmd);
                dAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                throw new Exception("An error occurred while retrieving license classes.", ex);
            }
            finally
            {
                conn.Dispose();
            }
            return dt;
        }


    }
}
