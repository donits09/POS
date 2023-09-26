using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class DashboardFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin");
        MySqlCommand cmd = new MySqlCommand();
        public DashboardFrm()
        {
            InitializeComponent();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeesFrm empFrm = new EmployeesFrm();
            empFrm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductsFrm prodFrm = new ProductsFrm();
            prodFrm.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategoryFrm catFrm = new CategoryFrm();
            catFrm.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockFrm stcksFrm = new StockFrm();
            stcksFrm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            LogInFrm loginFrm = new LogInFrm();
            loginFrm.Show();
        }

        private void DashboardFrm_Load(object sender, EventArgs e)
        {
           
            getSumStocks();
            getTotalSold();
            getTotalItems();
            getTotalItemsSold();
            displayUser();
        }

        void displayUser()
        {
            string sqlQuery = "SELECT * FROM dbpos.users WHERE status = '1'";

                conn.Open();

                using (MySqlCommand command = new MySqlCommand(sqlQuery, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblUser.Text = reader["username"].ToString() + " | "+reader["user_level"].ToString();
                        }
                        else
                        {
                            lblUser.Text = "N/A";
                        }
                    }
                }
        }
        void getSumStocks()
        {
            string sqlQuery = "SELECT COUNT(*) AS TotalRows FROM dbpos.tbl_products";

            using (MySqlCommand command = new MySqlCommand(sqlQuery, conn))
            {
                conn.Open();
                int totalRows = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                lblItems.Text = Convert.ToString(totalRows);
            }
        }

        void getTotalSold()
        {
            string sqlQuery = "SELECT SUM(unit_price * qty) AS TotalSales FROM dbpos.orders_list";

            using (MySqlCommand command = new MySqlCommand(sqlQuery, conn))
            {
                conn.Open();
                double totalSales = Convert.ToDouble(command.ExecuteScalar());
                conn.Close();

                string formattedTotalSales = totalSales.ToString("C", new System.Globalization.CultureInfo("en-PH"));
                lblSales.Text = formattedTotalSales;
            }
        }

        void getTotalItems()
        {
            string sqlQuery = "SELECT SUM(prod_qty) AS TotalItems FROM dbpos.tbl_products";

            using (MySqlCommand command = new MySqlCommand(sqlQuery, conn))
            {
                conn.Open();
                int totalSales = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();

                lblItems.Text = Convert.ToString(totalSales);
            }
        }

        void getTotalItemsSold()
        {
            string sqlQuery = "SELECT SUM(qty) AS TotalItemsSold FROM dbpos.orders_list";

            using (MySqlCommand command = new MySqlCommand(sqlQuery, conn))
            {
                conn.Open();
                int totalItemsSold = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();

                lblSold.Text = Convert.ToString(totalItemsSold);
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceFrm maintenanceFrm = new MaintenanceFrm();
            maintenanceFrm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportFrm reportFrm = new ReportFrm();
            reportFrm.Show();
            this.Hide();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            POSFrm pos = new POSFrm();
            pos.Show();
            this.Hide();
        }
    }
}
