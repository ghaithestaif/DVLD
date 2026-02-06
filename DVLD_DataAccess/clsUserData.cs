using DVLD_DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
public class clsUserData
{
    // ---------- FIND ----------
    public static bool Find(
        int userID,
        ref int PersonID,
        ref string outUserName,
        ref string outPassword,
        ref string PasswordSalt,
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
                PasswordSalt = (string)reader["PasswordSalt"];
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

    // ---------- ADD NEW ----------
    public static int AddNew(
        int personID,
        string userName,
       
        string password,
        string PasswordSalt,
        bool isActive)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            @"INSERT INTO Users (PersonID, UserName, Password,PasswordSalt, IsActive)
              VALUES (@PersonID, @UserName, @Password,@PasswordSalt, @IsActive);
              SELECT SCOPE_IDENTITY();",
            connection);

        command.Parameters.AddWithValue("@PersonID", personID);
        command.Parameters.AddWithValue("@UserName", userName);
        command.Parameters.AddWithValue("@Password", password);
        command.Parameters.AddWithValue("@IsActive", isActive);
        command.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);

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
           string PasswordSalt,
           string password,
           bool isActive)
        {
               SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
               SqlCommand command = new SqlCommand(
                   @"UPDATE Users
                 SET PersonID = @PersonID,
                     UserName = @UserName,
                     Password = @Password,
                        PasswordSalt = @PasswordSalt,
                     IsActive = @IsActive
                 WHERE UserID = @UserID",
                   connection);
               
               command.Parameters.AddWithValue("@UserID", userID);
               command.Parameters.AddWithValue("@PersonID", personID);
               command.Parameters.AddWithValue("@UserName", userName);
               command.Parameters.AddWithValue("@Password", password);
               command.Parameters.AddWithValue("@IsActive", isActive);
               command.Parameters.AddWithValue("@PasswordSalt", PasswordSalt);
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
        ref string PasswordSalt,
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
                PasswordSalt = (string)reader["PasswordSalt"];
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

}
