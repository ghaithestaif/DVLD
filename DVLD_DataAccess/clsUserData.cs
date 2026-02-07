using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DVLD_General;
public class clsUserData
{


    private static readonly Dictionary<Common.UsersFilter, string> _UserColumnMap = new Dictionary<Common.UsersFilter, string>()
{
    { Common.UsersFilter.UserID, "UserID" },
    { Common.UsersFilter.PersonID, "People.PersonID" },
    { Common.UsersFilter.UserName, "UserName" },
        { Common.UsersFilter.FullName, "FullName"   },
        {Common.UsersFilter.IsActive, "IsActive" }

};

    // ---------- FIND ----------
    public static bool Find(
        int userID,
        ref int PersonID,
        ref string outUserName,
        ref string outPassword,
        ref bool outIsActive)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            "SELECT * FROM Users WHERE UserID = @UserID",
            connection);

        command.Parameters.AddWithValue("@UserID", userID);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                userID = (int)reader["UserID"];
                outUserName = (string)reader["UserName"];
                outPassword = (string)reader["Password"];
                outIsActive = (bool)reader["IsActive"];
                int personID = (int)reader["PersonID"];                

                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
    public static DataTable GetAllUsers()
    {
        DataTable dtUsers = new DataTable();

        using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
        {
            string query = @"
                       SELECT Users.*,
                              CASE 
                                  WHEN People.ThirdName IS NULL OR People.ThirdName = '' THEN
                                       People.FirstName + ' ' + People.SecondName + ' ' + People.LastName
                                  ELSE
                                       People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName
                              END AS FullName
                       FROM People
                       INNER JOIN Users ON People.PersonID = Users.PersonID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dtUsers);
            }
        }

        return dtUsers;
    }

    // ---------- ADD NEW ----------
    public static int AddNew(
        int personID,
        string userName,
       
        string password,
        bool isActive)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            @"INSERT INTO Users (PersonID, UserName, Password,PasswordSalt, IsActive)
              VALUES (@PersonID, @UserName, @Password, @IsActive);
              SELECT SCOPE_IDENTITY();",
            connection);

        command.Parameters.AddWithValue("@PersonID", personID);
        command.Parameters.AddWithValue("@UserName", userName);
        command.Parameters.AddWithValue("@Password", password);
        command.Parameters.AddWithValue("@IsActive", isActive);

        try
        {
            connection.Open();
            object result = command.ExecuteScalar();

            if (result != null)
                return Convert.ToInt32(result);

            return -1;
        }
        catch
        {
            return -1;
        }
        finally
        {
            connection.Close();
        }
    }

    // ---------- DELETE ----------
    public static bool Delete(int userID)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            "DELETE FROM Users WHERE UserID = @UserID",
            connection);

        command.Parameters.AddWithValue("@UserID", userID);

        try
        {
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    // ---------- IS EXIST ----------
    public static bool IsExist(int userID)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            "SELECT 1 FROM Users WHERE UserID = @UserID",
            connection);

        command.Parameters.AddWithValue("@UserID", userID);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }
        catch
        {
            return false;
        }
        finally
        {
            connection.Close();
        } 
    }
        public static bool Update(
           int userID,
           int personID,
           string userName,
           string password,
           bool isActive)
        {
               SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
               SqlCommand command = new SqlCommand(
                   @"UPDATE Users
                 SET PersonID = @PersonID,
                     UserName = @UserName,
                     Password = @Password,
                     IsActive = @IsActive
                 WHERE UserID = @UserID",
                   connection);
               
               command.Parameters.AddWithValue("@UserID", userID);
               command.Parameters.AddWithValue("@PersonID", personID);
               command.Parameters.AddWithValue("@UserName", userName);
               command.Parameters.AddWithValue("@Password", password);
               command.Parameters.AddWithValue("@IsActive", isActive);
        try
               {
                   connection.Open();
                   return command.ExecuteNonQuery() > 0;
               }
               catch
               {
                   return false;
               }
               finally
               {
                   connection.Close();
               }
        }

    public static bool Find(
        string UserName,
        ref int PersonID,
        ref int userID,
        ref string outPassword,
        ref bool outIsActive)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            "SELECT * FROM Users WHERE UserName = @UserName",
            connection);

        command.Parameters.AddWithValue("@UserName", UserName);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                userID = (int)reader["UserID"];
                UserName = (string)reader["UserName"];
                outPassword = (string)reader["Password"];
                outIsActive = (bool)reader["IsActive"];
                PersonID = (int)reader["PersonID"];

                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
    public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref int PersonID, ref bool IsActive)
    {
        bool isFound = false;

        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);

        string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Username", UserName);
        command.Parameters.AddWithValue("@Password", Password);


        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // The record was found
                isFound = true;
                UserID = (int)reader["UserID"];
                PersonID = (int)reader["PersonID"];
                UserName = (string)reader["UserName"];
                Password = (string)reader["Password"];
                IsActive = (bool)reader["IsActive"];


            }
            else
            {
                // The record was not found
                isFound = false;
            }

            reader.Close();


        }
        catch (Exception ex)
        {
            //Console.WriteLine("Error: " + ex.Message);

            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }



    public static DataTable FilterUsers(Common.UsersFilter filterBy, string filterExpression)
    {
        if (filterBy == Common.UsersFilter.None)
            return GetAllUsers(); // returns all users

        string columnName = _UserColumnMap[filterBy];

        using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
        {
            string query = $@"
                       SELECT Users.UserID, Users.PersonID, Users.UserName, Users.Password, Users.IsActive,
                              CASE 
                                  WHEN People.ThirdName IS NULL OR People.ThirdName = '' THEN
                                       People.FirstName + ' ' + People.SecondName + ' ' + People.LastName
                                  ELSE
                                       People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName
                              END AS FullName
                       FROM Users
                       INNER JOIN People ON People.PersonID = Users.PersonID";


            if (filterBy == Common.UsersFilter.FullName)
            {
                query += @"
                       WHERE
                       (
                           CASE 
                               WHEN People.ThirdName IS NULL OR People.ThirdName = '' THEN
                                    People.FirstName + ' ' + People.SecondName + ' ' + People.LastName
                               ELSE
                                    People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName
                           END
                       ) LIKE '%' + @FilterExpression + '%'";
            }
            else
            {
                query += $" WHERE {columnName} = @FilterExpression";
            }



            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FilterExpression", filterExpression);

                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // optionally log ex.Message
                    throw; // or handle exception properly
                }

                return dataTable;
            }
        }
    }


}
