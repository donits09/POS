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
    public partial class CartFrm : Form
    {
        private POSFrm posForm;
        public delegate void ProductAddedEventHandler(string productCode, decimal originalQuantity, decimal updatedQuantity);
        public event ProductAddedEventHandler ProductAdded;
        public decimal Quantity { get; private set; }
        private string productCode;
        private string productName;
        private string productPrice;
        private decimal quantity;

        public CartFrm(POSFrm posForm, string productCode, string productName, string productPrice, decimal quantity)
        {
            InitializeComponent();
            this.posForm = posForm;
            SetProductCode(productCode, productName);
            this.productPrice = productPrice;
            Quantity = quantity;
        }


        public void SetProductCode(string productCode, string productName)
        {
            lblCode.Text = productCode;
            lblDesc.Text = productName;
        }

        private void CartFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productCode = lblCode.Text;
            decimal originalQuantity = Quantity;
            decimal quantityToSubtract = Convert.ToDecimal(txtQty.Text);

            decimal updatedQuantity = originalQuantity - quantityToSubtract;
            ProductAdded?.Invoke(productCode, originalQuantity, quantityToSubtract);
            DataGridViewRow selectedRow = null;
            foreach (DataGridViewRow row in posForm.DGVAddtoCart.Rows)
            {
                if (row.Cells["prod_code"].Value.ToString() == productCode)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow != null)
            {
                int qtyColumnIndex = posForm.DGVAddtoCart.Columns["prod_qty"].Index;
                selectedRow.Cells[qtyColumnIndex].Value = updatedQuantity;
            }
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}