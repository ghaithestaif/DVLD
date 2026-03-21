using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsData
    {
        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM TestAppointments", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch { }
            }

            return dt;
        }

        public static bool Find(
            int TestAppointmentID,
            ref int TestTypeID,
            ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate,
            ref decimal PaidFees,
            ref int CreatedByUserID,
            ref bool IsLocked,
            ref int RetakeTestApplicationID) // ❗ NOT nullable
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM TestAppointments 
                  WHERE TestAppointmentID = @TestAppointmentID", connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = TestAppointmentID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            TestTypeID = (int)reader["TestTypeID"];
                            LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            AppointmentDate = (DateTime)reader["AppointmentDate"];
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsLocked = (bool)reader["IsLocked"];

                            // ✅ FIX: handle NULL properly
                            if (reader["RetakeTestApplicationID"] != DBNull.Value)
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                            else
                                RetakeTestApplicationID = -1; // NULL → -1
                        }
                    }
                }
                catch { }
            }

            return isFound;
        }

        public static int AddNewTestAppointment(
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked,
            int RetakeTestApplicationID) // ❗ NOT nullable
        {
            int TestAppointmentID = -1;
            

            using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(
                @"INSERT INTO TestAppointments
                (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                 PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)

                VALUES
                (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate,
                 @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);

                SELECT SCOPE_IDENTITY();", connection))
            {
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = AppointmentDate;
                command.Parameters.Add("@PaidFees", SqlDbType.Decimal).Value = PaidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = IsLocked;

                // ✅ FIX: convert -1 → NULL
                if (RetakeTestApplicationID == -1)
                    command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = DBNull.Value;
                else
                    command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = RetakeTestApplicationID;

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        TestAppointmentID = Convert.ToInt32(result);
                }
                catch { }
                finally
                {
                    connection.Dispose();
                }
            }

            return TestAppointmentID;
        }

        public static bool UpdateTestAppointment(
            int TestAppointmentID,
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked,
            int RetakeTestApplicationID) // ❗ NOT nullable
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(
                @"UPDATE TestAppointments SET
                    TestTypeID = @TestTypeID,
                    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                    AppointmentDate = @AppointmentDate,
                    PaidFees = @PaidFees,
                    CreatedByUserID = @CreatedByUserID,
                    IsLocked = @IsLocked,
                    RetakeTestApplicationID = @RetakeTestApplicationID
                  WHERE TestAppointmentID = @TestAppointmentID", connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = TestAppointmentID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                command.Parameters.Add("@AppointmentDate", SqlDbType.DateTime).Value = AppointmentDate;
                command.Parameters.Add("@PaidFees", SqlDbType.Decimal).Value = PaidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = IsLocked;

                // ✅ FIX: convert -1 → NULL
                if (RetakeTestApplicationID == -1)
                    command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = DBNull.Value;
                else
                    command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = RetakeTestApplicationID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch { }
            }

            return rowsAffected > 0;
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(AppSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(
                @"DELETE FROM TestAppointments
                  WHERE TestAppointmentID = @TestAppointmentID", connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = TestAppointmentID;

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch { }
            }

            return rowsAffected > 0;
        }
    }
}