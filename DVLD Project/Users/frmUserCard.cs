using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Users
{
    public partial class frmUserCard : Form
    {
        int _UserID = -1;
        public int UserID { get { return _UserID; } }
        clsUser _User = new clsUser();
        public clsUser User { get { return _User; } }
        public frmUserCard(int ID)
        {
            _UserID = ID;
            _User=clsUser.Find(ID);
            InitializeComponent();
        }

        private void frmUserCard_Load(object sender, EventArgs e)
        {
            crtUserCard1.loadUserInformation(_UserID);
        }
    }
}
