using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace POS
{
    public partial class LogInFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin;");
        MySqlCommand cmd = new MySqlCommand();
        public LogInFrm()
        {
            InitializeComponent();
        }

        private void LogInFrm_Load(object sender, EventArgs e)
        {
            cmd.Connection = conn;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT COUNT(*) FROM dbpos.users WHERE username = '"+txtUsername.Text+"' AND password = '"+txtPassword.Text+"' AND user_level = 'Administrator'",conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                DashboardFrm dshbrd = new DashboardFrm();
                dshbrd.Show();
                this.Hide() ;
            }
            else
            {
                POSFrm posfrm = new POSFrm();
                posfrm.Show();
                this.Hide();
            }
            conn.Open();
            cmd.CommandText = "UPDATE dbpos.users SET status='1' WHERE username='" + txtUsername.Text + "' AND password ='" + txtPassword.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
