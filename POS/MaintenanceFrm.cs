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
    public partial class MaintenanceFrm : Form
    {
        public MaintenanceFrm()
        {
            InitializeComponent();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeesFrm empFrm = new EmployeesFrm();
            empFrm.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategoryFrm catFrm = new CategoryFrm();
            catFrm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductsFrm prodFrm = new ProductsFrm();
            prodFrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm dshbrd = new DashboardFrm();
            dshbrd.Show();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm dshbrd = new DashboardFrm();
            dshbrd.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            StockFrm stckFrm = new StockFrm();
            stckFrm.Show();
        }

        private void MaintenanceFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
