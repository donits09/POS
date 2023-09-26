using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class DiscountFrm : Form
    {
        private POSFrm posForm;
        public DiscountFrm(POSFrm posForm)
        {
            InitializeComponent();
            this.posForm = posForm;
        }


        private void DiscountFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDiscount.Text, out decimal discountPercentage))
            {
                posForm.ApplyDiscount(discountPercentage);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid discount percentage. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
