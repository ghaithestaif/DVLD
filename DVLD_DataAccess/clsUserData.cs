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

    // ---------- ADD NEW ----------
    public static int AddNew(
        int personID,
        string userName,
        string password,
        bool isActive)
    {
        SqlConnection connection = new SqlConnection(AppSettings.ConnectionString);
        SqlCommand command = new SqlCommand(
            @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
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

}
