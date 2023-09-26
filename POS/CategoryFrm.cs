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

namespace POS
{
    public partial class CategoryFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin;");
        MySqlCommand cmd = new MySqlCommand();
        private BindingSource bsource = new BindingSource();
        DataTable dtset;
        public CategoryFrm()
        {
            InitializeComponent();
            getCategory();
        }

        private void CategoryFrm_Load(object sender, EventArgs e)
        {
            cmd.Connection = conn;
        }
        void getCategory()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbpos.tbl_category", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dtset = new DataTable();
            adapter.Fill(dtset);

            bsource.DataSource = dtset;
            DGVCategory.DataSource = bsource;
        }

        private void DGVCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVCategory.Rows[e.RowIndex];
                txtID.Text = row.Cells["cat_id"].Value.ToString();
                txtDescription.Text = row.Cells["product_desc"].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO dbpos.tbl_category (product_desc)VALUES('" + txtDescription.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product description successfully added!");
            getCategory();
            btnAdd.Visible = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            txtDescription.Enabled = false;
            txtDescription.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "UPDATE dbpos.tbl_category SET product_desc='" + txtDescription.Text + "' WHERE cat_id='" + txtID.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Employee record successfully updated!");
            getCategory();
            btnEdit.Visible = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            txtDescription.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM dbpos.tbl_category WHERE cat_id='" + txtID.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Product description successfully deleted!");
            getCategory();
            txtDescription.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtDescription.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Visible = false;
            btnDelete.Enabled = false;
            txtDescription.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bsource.Filter = string.Format("[product_desc] LIKE '%{0}%'", txtSearch.Text);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceFrm maintenancefrm = new MaintenanceFrm();
            maintenancefrm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
