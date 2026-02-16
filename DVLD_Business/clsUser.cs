using DVLD_DataAccess;
using DVLD_General;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace DVLD_Business
{
    public class clsUser
    {
        // Data Members (same as table, no nulls)
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        // This is what you asked for
        public DVLD_Business.People Person { get; set; }
        enum enMode { Addnew, Update }
        enMode _Mode;
        public clsUser()
        {
            UserID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            Person = new DVLD_Business.People();
            _Mode = enMode.Addnew;
        }

        private clsUser(int UserID, int PersonID,
        string UserName,
        string Password,
        bool IsActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Person = DVLD_Business.People.Find(PersonID);
            _Mode = enMode.Update;
        }
        // ---------- FIND ----------
        static public clsUser Find(int userID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            if (clsUserData.Find(
                    userID,
                    ref PersonID,
                    ref UserName,
                    ref Password,
                    ref IsActive
                ))
            {
                return new clsUser(userID,
                     PersonID,
                     UserName,
                     Password,
                     IsActive);
            }
            return null;

        }

        static public clsUser Find(string UserName)
        {
            int PersonID = -1
            , UserID = -1;
            string Password = "";
            bool IsActive = false;
            if (clsUserData.Find(
                    UserName,
                    ref PersonID,
                    ref UserID,
                    ref Password,
                    ref IsActive
                ))
            {
                return new clsUser(UserID,
                     PersonID,
                     UserName,
                     Password,
                     IsActive);
            }
            return null;

        }
        // ---------- ADD NEW ----------
        private int _AddNew()
        {

            int UserID = clsUserData.AddNew(
                  Person.PersonID,
                  UserName,
                  Password,
                  IsActive
              );

            return UserID;

        }
        private bool _Update()
        {

            return clsUserData.Update(
                UserID,
                Person.PersonID,
                UserName,
                Password,
                IsActive
            );

        }
        // ---------- DELETE ----------
        public static bool Delete(int userID)
        {

            return clsUserData.Delete(userID);

        }

        // ---------- IS EXIST ----------
        public static bool IsExist(int userID)
        {

            return clsUserData.IsExist(userID);


        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public bool Save()
        {

            if (_Mode == enMode.Addnew)
            {
                int UserID = _AddNew();
                this.UserID = UserID;
                _Mode = enMode.Update;
                return UserID > 0;
            }
            else
            {
                return _Update();
            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static DataTable GetUsersByFilter(Common.UsersFilter filter, string FilterExpression)
        {
            return clsUserData.FilterUsers(filter, FilterExpression);
        }
        public static bool IsPersonLinkedToUser(int PersonID)
        {
            return clsUserData.IsPersonLinkedToUser(PersonID);
        }
    }
}
