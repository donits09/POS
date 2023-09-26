using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class POSFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin");
        private BindingSource bsource = new BindingSource();
        private readonly Random random;
        private decimal total = 0;
        private decimal totalvat = 0;
        private decimal totalvatable = 0;
        private decimal mainTotal = 0;

        CultureInfo culture = new CultureInfo("en-PH");

        public string GetTransactionLabelValue()
        {
            return lblTransact.Text;
        }

        public string GetDiscountLabelValue()
        {
            return lblDiscount.Text;
        }

        public string GetVatLabelValue()
        {
            return lblVat.Text;
        }

        public POSFrm()
        {
            InitializeComponent();
            random = new Random();
            GenerateRandomNumberAndDisplay();
        }
        void getProducts()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbpos.tbl_products", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dtset = new DataTable();
            adapter.Fill(dtset);

            bsource.DataSource = dtset;
            DGVAddtoCart.DataSource = bsource;
        }

        private void AddButtonColumnToDataGridView()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Add to Cart",
                UseColumnTextForButtonValue = true
            };

            DGVAddtoCart.Columns.Add(buttonColumn);
        }

        public void UpdateProductQuantityAndTotal(string productCode, decimal newQuantity)
        {
            foreach (DataGridViewRow row in DGVStocks1.Rows)
            {
                if (row.Cells["colProductCode"].Value.ToString() == productCode)
                {
                    row.Cells["colProductQty"].Value = newQuantity;
                    break;
                }
            }

            UpdateTotal();
        }

        public DataTable GetDGVData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("product_code");
            dt.Columns.Add("prod_unit_price");
            dt.Columns.Add("prod_qty");

            foreach (DataGridViewRow row in DGVStocks1.Rows)
            {
                DataRow dRow = dt.NewRow();
                dRow["product_code"] = row.Cells["colProductCode"].Value;
                dRow["prod_unit_price"] = row.Cells["colProductPrice"].Value;
                dRow["prod_qty"] = row.Cells["colProductQty"].Value;

                dt.Rows.Add(dRow);
            }

            return dt;
        }

        void displayUser()
        {
            string sqlQuery = "SELECT * FROM dbpos.users";

            conn.Open();

            using (MySqlCommand command = new MySqlCommand(sqlQuery, conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblUser.Text = reader["username"].ToString() + " | " + reader["user_level"].ToString();
                    }
                    else
                    {
                        lblUser.Text = "N/A";
                    }
                }
            }
        }
        private void POSFrm_Load(object sender, EventArgs e)
        {
            displayUser();
            getProducts();
            AddButtonColumnToDataGridView();

            DGVStocks1.Columns.Add("colProductCode", "CODE");
            DGVStocks1.Columns["colProductCode"].Width = 100; 

            DGVStocks1.Columns.Add("colProductName", "DESCRIPTION");
            DGVStocks1.Columns["colProductName"].Width = 250; 

            DGVStocks1.Columns.Add("colProductPrice", "PRICE");
            DGVStocks1.Columns["colProductPrice"].Width = 80; 

            DGVStocks1.Columns.Add("colProductQty", "QUANTITY");
            DGVStocks1.Columns["colProductQty"].Width = 80; 

            DGVStocks1.Columns.Add("colSubtotal", "Subtotal");
            DGVStocks1.Columns["colSubtotal"].Width = 100; 

            DGVStocks1.CellContentClick += DGVStocks1_CellContentClick;
            AddDeleteButtonColumn();
        }


        private void UpdateTotal()
        {
            total = 0;
            totalvat = 0;
            totalvatable = 0;

            foreach (DataGridViewRow row in DGVStocks1.Rows)
            {
                if (row.Cells["colProductQty"].Value != null && row.Cells["colProductPrice"].Value != null)
                {
                    decimal quantity = Convert.ToDecimal(row.Cells["colProductQty"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["colProductPrice"].Value);
                    decimal subtotal = quantity * price;
                    decimal vat = subtotal * 0.12m;

                    total += subtotal;
                    totalvat += vat;
                    totalvatable = (total - totalvat);
                }
            }
            lblMainTotal.Text = total.ToString("F2");
            lblVat.Text = totalvat.ToString("F2");
            lblVatable.Text = totalvatable.ToString("F2");
        }

        private void AddDeleteButtonColumn()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Name = "colDelete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            DGVStocks1.Columns.Add(deleteButtonColumn);
        }

        private void GenerateRandomNumberAndDisplay()
        {
            Random random = new Random();
            long firstNineDigits = random.Next(100_000_000, 1_000_000_000);
            int lastThreeDigits = random.Next(0, 1_000);
            long twelveDigitNumber = (firstNineDigits * 1000) + lastThreeDigits;
            lblTransact.Text = twelveDigitNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateRandomNumberAndDisplay();
        }


        private void DGVStocks1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGVStocks1.Columns["colDelete"].Index)
            {
                int productID = Convert.ToInt32(DGVStocks1.Rows[e.RowIndex].Cells["colProductCode"].Value);

                DeleteRowByProductID(productID);
            }
        }

        private void DeleteRowByProductID(int productID)
        {
            DataGridViewRow rowToDelete = null;
            foreach (DataGridViewRow row in DGVStocks1.Rows)
            {
                int rowProductID = Convert.ToInt32(row.Cells["colProductCode"].Value);
                if (rowProductID == productID)
                {
                    rowToDelete = row;
                    break;
                }
            }

            if (rowToDelete != null)
            {
                DGVStocks1.Rows.Remove(rowToDelete);
                UpdateTotal();
            }
        }



        private void OnProductAddedToCart(string productCode, decimal originalQuantity, decimal updatedQuantity)
        {
            foreach (DataGridViewRow row in DGVAddtoCart.Rows)
            {
                if (row.Cells["prod_code"].Value.ToString() == productCode)
                {
                    row.Cells["prod_qty"].Value = updatedQuantity;
                    break;
                }
            }

            foreach (DataGridViewRow row in DGVStocks1.Rows)
            {
                if (row.Cells["colProductCode"].Value.ToString() == productCode)
                {
                    row.Cells["colProductQty"].Value = updatedQuantity;
                    break;
                }
            }

            UpdateTotal();
        }
        private void UpdateProductQuantityInGrid(string newProductCode, decimal newQuantity)
        {
            foreach (DataGridViewRow row in DGVStocks1.Rows)
            {
                if (row.Cells["colProductCode"].Value.ToString() == newProductCode)
                {
                    row.Cells["colProductQty"].Value = newQuantity;
                    break;
                }
            }

            UpdateTotal();
        }

        private void DGVAddtoCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVAddtoCart.Rows[e.RowIndex];
                txtProductCode.Text = row.Cells["prod_code"].Value.ToString();
                txtQty.Text = row.Cells["prod_qty"].Value.ToString();
                txtPrice.Text = row.Cells["prod_unit_price"].Value.ToString();
                txtDescription.Text = row.Cells["prod_desc"].Value.ToString();
            }

            string productCode = Convert.ToString(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_code"].Value);
            string productName = Convert.ToString(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_desc"].Value);
            string productPrice = Convert.ToString(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_unit_price"].Value);
            decimal productQty = Convert.ToDecimal(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_qty"].Value);

            CartFrm cartForm = new CartFrm(this, productCode, productName, productPrice, productQty);

            cartForm.ProductAdded += CartForm_ProductAdded;

            cartForm.ShowDialog();
        }
        private void CartForm_ProductAdded(string productCode, decimal originalQuantity, decimal quantityToSubtract)
        {
            DataGridViewRow selectedRow = null;
            foreach (DataGridViewRow row in DGVAddtoCart.Rows)
            {
                if (row.Cells["prod_code"].Value.ToString() == productCode)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow != null)
            {
                int qtyColumnIndex = DGVAddtoCart.Columns["prod_qty"].Index;
                selectedRow.Cells[qtyColumnIndex].Value = quantityToSubtract;
                int rowIndex = DGVStocks1.Rows.Add();
                DGVStocks1.Rows[rowIndex].Cells["colProductCode"].Value = selectedRow.Cells["prod_code"].Value;
                DGVStocks1.Rows[rowIndex].Cells["colProductName"].Value = selectedRow.Cells["prod_desc"].Value;
                DGVStocks1.Rows[rowIndex].Cells["colProductPrice"].Value = selectedRow.Cells["prod_unit_price"].Value;
                DGVStocks1.Rows[rowIndex].Cells["colProductQty"].Value = quantityToSubtract;

                decimal productPrice = Convert.ToDecimal(selectedRow.Cells["prod_unit_price"].Value);
                decimal subtotal = quantityToSubtract * productPrice;
                DGVStocks1.Rows[rowIndex].Cells["colSubtotal"].Value = subtotal;
                UpdateTotal();
            }
        }

        private void DGVStocks1_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVStocks1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVStocks1.SelectedRows[0];
                string productCode = selectedRow.Cells["colProductCode"].Value.ToString();
                string productName = selectedRow.Cells["colProductName"].Value.ToString();
                string productPrice = selectedRow.Cells["colProductPrice"].Value.ToString();
                string productQty = selectedRow.Cells["colProductQty"].Value.ToString();

                txtProductCode.Text = productCode;
                txtDescription.Text = productName;
                txtPrice.Text = productPrice;
                txtQty.Text = productQty;

                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal qty = Convert.ToDecimal(txtQty.Text);

                decimal res = price * qty;
            }
            else
            {
                txtProductCode.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtQty.Text = "";
            }
        }

        private void btnAddDisc_Click(object sender, EventArgs e)
        {
            DiscountFrm dscntfrm = new DiscountFrm(this);
            dscntfrm.ShowDialog();
        }

        public void ApplyDiscount(decimal discountPercentage)
        {
            var mainTotal = Convert.ToDecimal(lblMainTotal.Text);
            decimal discount = mainTotal * (discountPercentage / 100);
            decimal discountedTotal = mainTotal - discount;

            lblDiscount.Text = $"{discount:N2}";
            lblMainTotal.Text = $"{discountedTotal:N2}";
        }

        public void UpdateMainTotal(decimal total)
        {
            mainTotal = total;

            lblMainTotal.Text = $"Total: {mainTotal:N2}";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm dshbrd = new DashboardFrm();
            dshbrd.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentFrm paymentForm = new PaymentFrm(this);
            paymentForm.PaymentConfirmed += PaymentForm_PaymentConfirmed;
            paymentForm.ShowDialog();
        }

        private void PaymentForm_PaymentConfirmed()
        {

            lblMainTotal.Text = "0.00";
            lblDiscount.Text = "0.00";
            lblVat.Text = "0.00";
            lblVatable.Text = "0.00";
            lblTransact.Text = "";
            GenerateRandomNumberAndDisplay();
        }

        public decimal MainTotalValue
        {
            get
            {
                mainTotal = Convert.ToDecimal(lblMainTotal.Text);
                return mainTotal;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm dashboardFrm = new DashboardFrm();
            dashboardFrm.Show();    
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            DGVStocks1.Rows.Clear();
        }

        public void ClearDGVStocks1()
        {
            DGVStocks1.Rows.Clear();
        }

    }
}