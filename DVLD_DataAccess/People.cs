using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_DataAccess
{
    static public class People
    {
        //ThirdName , email, imagePath are allow null
        static public bool AddNewPerson( ref int ID,
                string NationalNo, string FirstName, string SecondName,
                string ThirdName, string LastName, string Address, DateTime DateOfBirth,
                int Gendor, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[People]
        ([NationalNo],
         [FirstName],
         [SecondName],
         [ThirdName],
         [LastName],
         [DateOfBirth],
         [Gendor],
         [Address],
         [Phone],
         [Email],
         [NationalityCountryID],
         [ImagePath])
        VALUES
        (@NationalNo,
         @FirstName,
         @SecondName,
         @ThirdName,
         @LastName,
         @DateOfBirth,
         @Gendor,
         @Address,
         @Phone,
         @Email,
         @NationalityCountryID,
         @ImagePath);
         select SCOPE_IDENTITY();
           ";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Parameters
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object id = cmd.ExecuteScalar();
                if (id != null)
                {
                    ID = Convert.ToInt32(id);
                    return ID > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                // You can log ex.Message here
                return false;
            }
            finally
            {
                    connection.Close();
            }
        }

        static public bool DeletePerson(string NationalNo)
        {
            bool IsDeleted= false;  
            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = "DELETE FROM [dbo].[People]     WHERE NationalNo=@NationalNo";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@NationalNo",NationalNo);


            try{
                connection.Open();
               int RowsAffected= cmd.ExecuteNonQuery();
                if(RowsAffected > 0)    {
                    IsDeleted= true;
                }
                else { IsDeleted= false; }



            }
            catch { IsDeleted = false; }
            finally { connection.Close(); }



            return IsDeleted;
        }

        static public bool UpdatePerson(
             int PersonID,
             string NationalNo, string FirstName, string SecondName,
             string ThirdName, string LastName, string Address, DateTime DateOfBirth,
             int Gendor, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = @"UPDATE [dbo].[People]
                     SET [NationalNo] = @NationalNo,
                         [FirstName] = @FirstName,
                         [SecondName] = @SecondName,
                         [ThirdName] = @ThirdName,
                         [LastName] = @LastName,
                         [DateOfBirth] = @DateOfBirth,
                         [Gendor] = @Gendor,
                         [Address] = @Address,
                         [Phone] = @Phone,
                         [Email] = @Email,
                         [NationalityCountryID] = @NationalityCountryID,
                         [ImagePath] = @ImagePath
                     WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Parameters
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName == null)
                cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ThirdName", Email);

            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);

            if (Email == null)
                cmd.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Email", Email);

            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath == null)
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ImagePath", Email);
            
            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Log ex.Message if needed
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        static public bool FindPersonByID(
             int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
             ref string ThirdName,ref string LastName,ref DateTime DateOfBirth,ref int Gendor,ref string Address,
             ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = @"SELECT *
                     FROM People
                     WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"]== DBNull.Value?null:reader["ThirdName"].ToString(); 
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (int)reader["Gendor"];
                    Address = reader["Address"] .ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"]==DBNull.Value?null:reader["Email"].ToString(); 
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();
                }

                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }












    }




}
