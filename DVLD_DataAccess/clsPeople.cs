using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    static public class clsPeople
    {
        public enum PeopleFilterSort
        {
            FirstName,
            LastName,
            SecondName,
            NationalNo,
            ThirdName,
            Phone,
            Gendor,
            PersonID,
            CountryID,
            Email
        }

        
        

        static public int AddNewPerson(
                string NationalNo, string FirstName, string SecondName,
                string ThirdName, string LastName, string Address, DateTime DateOfBirth,
                int Gendor, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int ID = -1;
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

            if (ThirdName != null)
            {
                cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            if (Email != null)
            {
                cmd.Parameters.AddWithValue("@Email", Email);

            }
            else
            {
                cmd.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != null)
            {
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            try
            {
                connection.Open();
                object id = cmd.ExecuteScalar();
                if (id != null)
                {
                    ID = Convert.ToInt32(id);
                    return ID;
                }

                return ID;
            }
            catch (Exception ex)
            {
                // You can log ex.Message here
                return ID;
            }
            finally
            {
                connection.Close();
            }
        }

        static public bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = "DELETE FROM [dbo].[People]     WHERE PersonID=@PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    IsDeleted = true;
                }
                else { IsDeleted = false; }



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
                cmd.Parameters.AddWithValue("@ThirdName", ThirdName);

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
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

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
             ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
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
                    ThirdName = reader["ThirdName"] == DBNull.Value ? null : reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
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


        static public DataTable GetAllPeople()
        {
          
            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";

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

        static public bool IspersonExist(string NationalNo)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = @"SELECT *
                     FROM People
                     WHERE NationalNo = @NationalNo";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IsExist = reader.HasRows;


                reader.Close();
            }
            catch
            {
                IsExist = false;
            }
            finally
            {
                connection.Close();
            }

            return IsExist;

        }

        static public DataTable FilterPeople(PeopleFilterSort FilterBy, string FilterExpression)
        {
            if (FilterBy == PeopleFilterSort.none)
            {
                return GetAllPeople();
            }
            string ColumnName = _ColumnMap[FilterBy];

            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = $@"SELECT *
                          FROM People
                          WHERE {ColumnName} = @FilterExpression";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FilterExpression", FilterExpression);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        static private string GetSortQuery(DVLD_General.Common.SortType Type, string ColumnName="")
        {
            if (Type == DVLD_General.Common.SortType.Ascending)
            {
                return $@"SELECT *
                        FROM People
                        ORDER BY {ColumnName} ASC";
            }
            else
            {
                return $@"SELECT *
                          FROM People
                          ORDER BY {ColumnName} Desc"; ;
            }
        }

        static public DataTable SortPeople(DVLD_General.Common.PeopleFilterSort SortBy, DVLD_General.Common.SortType Type)
        {
            if(SortBy== DVLD_General.Common.PeopleFilterSort.none)
            {
                return GetAllPeople();
            }
            string ColumnName = _ColumnMap[SortBy];

            SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

            string query = GetSortQuery(Type, ColumnName);

            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
                  
            return dataTable;




            }

        




    }




}
