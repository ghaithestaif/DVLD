using DVLD_DataAccess;
using System.Xml.Linq;

public class clsUser
{
    // Data Members (same as table, no nulls)
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }

    // This is what you asked for
    public DVLD_Business.People Person { get; set; }
    enum enMode { Addnew, Update}
    enMode _Mode;
    public clsUser()
    {
        UserID = -1;
        UserName = "";
        Password = "";
        IsActive = false;
        Person = new DVLD_Business.People();
        _Mode=enMode.Addnew;
    }

    private clsUser(int UserID,int PersonID,
    string UserName,
    string Password ,
    bool IsActive)
    {
       this.UserID = UserID;
        this.UserName = "";
        this.Password = "";
        this.IsActive = false;
        this.Person = DVLD_Business.People.Find(PersonID);
        _Mode=enMode.Update;
    }
    // ---------- FIND ----------
    public clsUser Find(int userID)
    {
      int PersonID = -1;
        string UserName = "";
        string Password = "";
        bool IsActive = false;
        if(clsUserData.Find(
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


    public  bool Save()
    {

        if (_Mode==enMode.Addnew)
        {
           int Person= _AddNew();
            _Mode = enMode.Update;
            return Person > 0;
        }
        else
        {
            return _Update();
        }
    }
}
