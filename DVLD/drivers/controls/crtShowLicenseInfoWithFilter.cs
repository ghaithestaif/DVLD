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

namespace DVLD.drivers.controls
{
    public partial class crtShowLicenseInfoWithFilter : UserControl
    {

        public bool DisableFilter { 
            get {
                return gbFilters.Enabled;
            }
            set  {
                gbFilters.Enabled = value;
            }
        }
        public clsLicense LicenseInfo {
            get { return crtShowLicenseInfo1.License; }
        }
       public event Action OnLicesneFound;
        public crtShowLicenseInfoWithFilter()
        {
            InitializeComponent();
        }













        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) {

                e.Handled = true;

            }
            if (char.IsControl(e.KeyChar)) {

                e.Handled = false;
            
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtFilterValue.Text);
            clsLicense license = clsLicense.Find(ID);
            if (license == null)
            {
                MessageBox.Show("cannot load form");
                return;

            }

            crtShowLicenseInfo1.LoadData(ID);
            OnLicesneFound?.Invoke();
        }

        private void crtShowLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            
        }
    }
}
