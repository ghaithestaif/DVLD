using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationTypes
{
    public partial class frmApplicationTypeList : Form
    {
        public frmApplicationTypeList()
        {
            InitializeComponent();
        }
        void _ReloadDatagrid()
        {
            DataTable dt = DVLD_Business.clsApplicationType.GetAll();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 130;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 130;
            lRecordsNumber.Text = (dt.Rows.Count).ToString();

        }
        private void frmApplicationTypeList_Load(object sender, EventArgs e)
        {
            _ReloadDatagrid();



        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmEditApplicationType form = new frmEditApplicationType((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            form.ApplicationTypeChanged += _ReloadDatagrid;
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
