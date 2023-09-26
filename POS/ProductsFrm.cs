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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class ProductsFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin");
        private BindingSource bsource = new BindingSource();
        MySqlCommand cmd = new MySqlCommand();
        public ProductsFrm()
        {
            InitializeComponent();
            getProducts();
            PopulateComboBox();
        }

        private void DGVProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVProducts.Rows[e.RowIndex];
                txtID.Text = row.Cells["prod_id"].Value.ToString();
                txtProductCode.Text = row.Cells["prod_code"].Value.ToString();
                txtDescription.Text = row.Cells["prod_desc"].Value.ToString();
                txtCategory.Text = row.Cells["product_desc"].Value.ToString();
                txtPrice.Text = row.Cells["prod_unit_price"].Value.ToString();
                txtReorderLevel.Text = row.Cells["prod_reorder_level"].Value.ToString();
            }
        }

        private void ProductsFrm_Load(object sender, EventArgs e)
        {
            cmd.Connection = conn;
        }

        private void PopulateComboBox()
        {
            string columnName = "product_desc";

            try
            {
                conn.Open();
                string query = $"SELECT {columnName} FROM dbpos.tbl_category";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtCategory.Items.Add(reader[columnName].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        void getProducts()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT p.*, c.product_desc " +
                                    "FROM dbpos.tbl_products AS p " +
                                    "INNER JOIN dbpos.tbl_category AS c " +
                                    "ON p.prod_category = c.cat_id", conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dtset = new DataTable();
            adapter.Fill(dtset);

            bsource.DataSource = dtset;
            DGVProducts.DataSource = bsource;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO dbpos.tbl_products (prod_code,prod_desc,prod_category,prod_unit_price,prod_reorder_level)VALUES('" + txtProductCode.Text + "','" + txtDescription.Text + "','" + txtID.Text + "','" + txtPrice.Text + "','" + txtReorderLevel.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product information successfully added!");
            getProducts();
            clearTextBox();
            disableTextBox();
            btnEdit.Visible = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Visible = false;
            btnAdd.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM dbpos.tbl_products WHERE prod_id='" + txtID.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product information successfully deleted!");
            getProducts();
            clearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "UPDATE dbpos.tbl_products SET prod_code='" + txtProductCode.Text + "',prod_desc='" + txtDescription.Text + "',prod_category='" + txtID.Text + "',prod_unit_price='" + txtPrice.Text + "',prod_reorder_level='" + txtReorderLevel.Text + "' WHERE prod_id='"+txtID.Text+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product information successfully updated!");
            getProducts();
            clearTextBox();
            disableTextBox();
            btnEdit.Visible = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceFrm maintenancefrm = new MaintenanceFrm();
            maintenancefrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceFrm maintenancefrm = new MaintenanceFrm();
            maintenancefrm.Show();
        }

        void disableTextBox()
        {
            txtReorderLevel.Enabled = false;    
            txtCategory.Enabled = false;
            txtPrice.Enabled = false;
            txtProductCode.Enabled = false;
            txtDescription.Enabled = false;
        }
        void enableTextBox()
        {
            txtProductCode.Enabled = true;
            txtDescription.Enabled = true;
            txtCategory.Enabled = true; 
            txtPrice.Enabled = true;    
            txtReorderLevel.Enabled = true; 
        }

        void clearTextBox()
        {
            txtProductCode.Text = "";
            txtDescription.Text = "";
            txtCategory.Text = "";
            txtPrice.Text = "";
            txtReorderLevel.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Visible = true;
            enableTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            enableTextBox();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bsource.Filter = string.Format("[prod_desc] LIKE '%{0}%' OR [prod_code] LIKE '%{0}%'", txtSearch.Text);
        }

        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = txtCategory.SelectedItem.ToString();
            string columnName = "cat_id";

            try
            {
                conn.Open();
                string query = $"SELECT {columnName} FROM dbpos.tbl_category WHERE product_desc = @selectedCategory";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@selectedCategory", selectedCategory);
                    object catId = command.ExecuteScalar();

                    if (catId != null)
                    {
                        txtID.Text = catId.ToString();
                    }
                    else
                    {
                        txtID.Text = ""; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
