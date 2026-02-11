using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace DVLD.Users.Controls
{
    public partial class crtUserCard : UserControl
    {
        int _UserID = -1;
        public int UserID { get { return _UserID; } }
        clsUser _User=new clsUser();
       public clsUser User  { get{ return _User; } }
        public crtUserCard()
        {
            InitializeComponent();
        }
       public void loadUserInformation(int UserID)
        {
            _User = clsUser.Find(UserID);
            _UserID=_User.UserID;
            personCard1.LoadPersonInfo(_User.Person.PersonID);
            if (_User.IsActive == true)
            {
                lIsActive.Text = "Yes";
            }
            else
            {
                lIsActive.Text = "No";
            }
            lUserName.Text = _User.UserName;
            lUserID.Text = _User.UserID.ToString();

        }

        public void ResetInfo()
        {
            personCard1.ResetPersonInfo();
            lIsActive.Text = "??";
            lUserID.Text = "??";
            lUserName.Text = "??";
        }

        private void crtUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
