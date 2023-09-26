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
    public partial class ReportFrm : Form
    {
        public ReportFrm()
        {
            InitializeComponent();
        }

        private void ReportFrm_Load(object sender, EventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm dshbrd = new DashboardFrm();
            dshbrd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemsListRptFrm ItemsListRpt = new ItemsListRptFrm();
            ItemsListRpt.Show();
        }

        private void btnSoldItems_Click(object sender, EventArgs e)
        {
            SoldItemsReportFrm soldItemsRpt = new SoldItemsReportFrm();
            soldItemsRpt.Show();
        }

        private void btnCritical_Click(object sender, EventArgs e)
        {

        }
    }
}
