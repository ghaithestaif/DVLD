using DVLD.People;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }


        private void MainForm_Load_1(object sender, EventArgs e)
        {




        }


        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_People frmManage_People=new Manage_People();
            frmManage_People.ShowDialog();
        }


        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm=new frmLogin();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frmUsersList=new frmUsersList();
            frmUsersList.ShowDialog();
        }

        private void changPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmChangePassword form = new frmChangePassword(Global_Classes.General.CurrentUser.UserID);
            form.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserCard form = new frmUserCard(Global_Classes.General.CurrentUser.UserID);
            form.ShowDialog();
        }
    }
}
