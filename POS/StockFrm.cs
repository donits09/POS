using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class StockFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin");
        MySqlCommand cmd = new MySqlCommand();
        private DataTable dtset = new DataTable();
        string id;
        public StockFrm()
        {
            InitializeComponent();
            getProducts();
            getAddedStocks();
        }

        private void StockFrm_Load(object sender, EventArgs e)
        {
            cmd.Connection = conn;
        }

        void getProducts()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbpos.tbl_products", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dtset = new DataTable();
            adapter.Fill(dtset);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dtset;
            DGVStocks1.DataSource = bsource;
            adapter.Update(dtset);
        }

        void getAddedStocks()
        {
            string query = "SELECT x.prod_code, x.prod_desc, x.prod_category, x.prod_unit_price, y.prod_id, y.prod_qty AS prod_qty " +
                          "FROM dbpos.tbl_products AS x " +
                          "INNER JOIN dbpos.tbl_added_product AS y ON x.prod_code = y.prod_code";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dtset = new DataTable();
            adapter.Fill(dtset);

            dtset.Columns["prod_qty"].ColumnName = "prod_qty";
            dtset.Columns["prod_id"].ColumnName = "prod_id";

            DGVStocks2.DataSource = dtset;
        }


        private void DGVStocks1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVStocks1.Rows[e.RowIndex];
                txtProductCode.Text = row.Cells["prod_code"].Value.ToString();
                txtDescription.Text = row.Cells["prod_desc"].Value.ToString();
                txtCategory.Text = row.Cells["prod_category"].Value.ToString();
                txtPrice.Text = row.Cells["prod_unit_price"].Value.ToString();
                //txtQty.Text = row.Cells["prod_qty"].Value.ToString();
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO dbpos.tbl_added_product (prod_code,prod_desc,prod_category,prod_unit_price,prod_qty)VALUES('" + txtProductCode.Text + "','" + txtDescription.Text + "','" + txtCategory.Text + "','" + txtPrice.Text + "', '"+txtQty.Text+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product information successfully added!");
            getAddedStocks();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = (DataTable)DGVStocks2.DataSource;
                using (conn)
                {
                    conn.Open();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string id = Convert.ToString(row["prod_code"]);

                        string query = "UPDATE dbpos.tbl_products " +
                                       "SET prod_qty = prod_qty + @prod_qty " +
                                       "WHERE prod_code = @prod_code";

                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@prod_qty", row["prod_qty"]);
                            command.Parameters.AddWithValue("@prod_code", id);
                            command.ExecuteNonQuery();
                        }
                    }

                    conn.Close();
                }
                deleteAddedStocks();
                MessageBox.Show("Data updated successfully.");

                getProducts();
                getAddedStocks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void deleteAddedStocks()
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM dbpos.tbl_added_product;";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM dbpos.tbl_added_product WHERE prod_code='" + txtProductCode.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product information successfully deleted!");
            getProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm dshbrd = new DashboardFrm();
            dshbrd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM dbpos.tbl_added_product WHERE prod_id OR prod_category OR prod_code='"+id+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            getAddedStocks();
        }

        private void DGVStocks2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.DGVStocks2.Rows[e.RowIndex];
                object value = row.Cells[e.ColumnIndex].Value;

                id = value.ToString();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
