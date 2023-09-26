using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace POS
{
    public partial class SearchProductFrm : Form
    {
        public delegate void ProductAddedEventHandler(string productCode, string productName, string productPrice);
        public event ProductAddedEventHandler ProductAdded;
        private void DGVAddtoCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGVAddtoCart.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string productCode = Convert.ToString(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_code"].Value);
                string productName = Convert.ToString(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_desc"].Value);
                string productPrice = Convert.ToString(DGVAddtoCart.Rows[e.RowIndex].Cells["prod_unit_price"].Value);

                // Open the CartFrm window and pass the selected product data
                CartFrm cartForm = new CartFrm(productCode, productName, productPrice);
                cartForm.ProductAdded += OnProductAddedToCart; // Subscribe to the ProductAdded event
                cartForm.ShowDialog();
            }
        }

        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin");
        private BindingSource bsource = new BindingSource();
        public SearchProductFrm()
        {
            InitializeComponent();
        }
        private void SearchProductFrm_Load(object sender, EventArgs e)
        {
            getProducts();
            AddButtonColumnToDataGridView();
        }
        public void OpenCartFormWithSelectedProduct(string productCode, string productName, string productPrice)
        {
            CartFrm cartForm = new CartFrm(productCode, productName, productPrice);
            cartForm.ProductAdded += OnProductAddedToCart; // Subscribe to the ProductAdded event
            cartForm.ShowDialog();
        }

        private void OnProductAddedToCart(string productCode, string productName, string productPrice)
        {
            POSFrm mainForm = Application.OpenForms.OfType<POSFrm>().FirstOrDefault();
            mainForm?.OnProductAddedToCart(productCode, productName, productPrice);

            // Close the SearchProductFrm after adding to cart
            this.Close();
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
    }
}
