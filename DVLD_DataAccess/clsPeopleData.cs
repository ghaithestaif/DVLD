using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_General;

namespace DVLD_DataAccess
{
    static public class clsPeopleData
    {
        private static readonly Dictionary<DVLD_General.Common.PeopleFilter, string> _ColumnMap
             = new Dictionary<DVLD_General.Common.PeopleFilter, string>()
         {
            { DVLD_General.Common.PeopleFilter.FirstName, "FirstName" },
            { DVLD_General.Common.PeopleFilter.LastName, "LastName" },
            { DVLD_General.Common.PeopleFilter.SecondName, "SecondName" },
            { DVLD_General.Common.PeopleFilter.NationalNo, "NationalNo" },
            {DVLD_General.Common.PeopleFilter.ThirdName,"ThirdName" },
            {DVLD_General.Common.PeopleFilter.Phone,"Phone" },
            {DVLD_General.Common.PeopleFilter.Gendor,"Gendor" },
            {DVLD_General.Common.PeopleFilter.PersonID, "PersonID"},
            {Common.PeopleFilter.CountryID,"NationalityCountryID"},
            {Common.PeopleFilter.Email,"Email" }
         };
        

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

        static public bool FindPerson(
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
                ORDER BY People.FirstName"; ;
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
                throw;
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
        static public bool IspersonExist(int PersonID )
        {
            bool IsExist = false;

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

        static public DataTable FilterPeople(DVLD_General.Common.PeopleFilter FilterBy, string FilterExpression)
        {
            if (FilterBy == DVLD_General.Common.PeopleFilter.none)
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

        


        static public bool FindPerson(
             string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
             ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
             ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

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

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
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


        



        }




    }
