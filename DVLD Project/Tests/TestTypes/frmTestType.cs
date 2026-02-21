using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.TestTypes
{
    public partial class frmTestType : Form
    {
        public frmTestType()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _Refreshgrid()
        {
            DataTable dt = clsTestType.GetAllTypes();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 80;

            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[1].Width = 140;

            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[2].Width = 350;

            dataGridView1.Columns[3].HeaderText = "Fees";
            dataGridView1.Columns[3].Width = 70;


            lRecordsNumber.Text=dt.Rows.Count.ToString();
        }

        private void frmTestType_Load(object sender, EventArgs e)
        {
            _Refreshgrid();

        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.TestTypeSaved += _Refreshgrid;
            frm.ShowDialog();
        }

        
    }
}
