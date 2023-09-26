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
    public partial class EmployeesFrm : Form
    {
        MySqlConnection conn = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=admin;");
        private BindingSource bsource = new BindingSource();
        MySqlCommand cmd = new MySqlCommand();
        DataTable dtset;
        public EmployeesFrm()
        {
            InitializeComponent();
            GetStaff();
        }

        private void EmployeesFrm_Load(object sender, EventArgs e)
        {
            cmd.Connection = conn;
        }

        void GetStaff()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbpos.users", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            dtset = new DataTable();
            adapter.Fill(dtset);

            bsource.DataSource = dtset;
            DGVStaff.DataSource = bsource;
        }


        private void DGVStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVStaff.Rows[e.RowIndex];
                txtID.Text = row.Cells["id"].Value.ToString();
                txtUsername.Text = row.Cells["username"].Value.ToString();
                txtPassword.Text = row.Cells["password"].Value.ToString();
                txtLastName.Text = row.Cells["last_name"].Value.ToString();
                txtFirstName.Text = row.Cells["first_name"].Value.ToString();
                txtMiddleName.Text = row.Cells["middle_name"].Value.ToString();
                DTPBirthDate.Text = row.Cells["birthdate"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
                txtAge.Text = row.Cells["age"].Value.ToString();
                txtContactNo.Text = row.Cells["contact_no"].Value.ToString();
                txtStatus.Text = row.Cells["status"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
                txtUserLevel.Text = row.Cells["user_level"].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO dbpos.users (username,password,last_name,first_name,middle_name,contact_no,birthdate,address,age,status,user_level)VALUES('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtLastName.Text + "','" + txtFirstName.Text + "','" + txtMiddleName.Text + "','"+txtContactNo.Text+"','" + DTPBirthDate.Text + "','" + txtAddress.Text + "','" + txtAge.Text + "','0','"+txtUserLevel.Text+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Employee record successfully added!");
            GetStaff();
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            clearTextBox();
            disableTextBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "DELETE FROM dbpos.users WHERE id='"+txtID.Text+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Employee record successfully deleted!");
            GetStaff();
            clearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "UPDATE dbpos.users SET username='" + txtUsername.Text + "',password='" + txtPassword.Text + "',last_name='" + txtLastName.Text + "',first_name='" + txtFirstName.Text + "',middle_name='" + txtMiddleName.Text + "',contact_no='"+txtContactNo.Text+"',birthdate='" + DTPBirthDate.Text + "',age='" + txtAge.Text + "',address='" + txtAddress.Text + "',user_level='"+txtUserLevel.Text+"' WHERE id='"+txtID.Text+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Employee record successfully updated!");
            GetStaff();
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            clearTextBox();
            disableTextBox();   
        }

        void enableTextBox()
        {
            txtLastName.Enabled = true;
            txtFirstName.Enabled = true ;
            txtMiddleName.Enabled = true ;
            txtContactNo.Enabled = true ;   
            txtAge.Enabled = true ; 
            txtAddress.Enabled = true ; 
            txtUserLevel.Enabled = true ;   
            DTPBirthDate.Enabled = true ;
            txtUsername.Enabled = true ;
            txtPassword.Enabled = true ;    
        }

        void disableTextBox()
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false ;   
            txtLastName.Enabled = false ;       
            txtFirstName.Enabled = false ;
            txtMiddleName.Enabled = false ; 
            txtContactNo.Enabled = false ;  
            txtAge.Enabled = false ;
            txtAddress.Enabled = false ;
            txtUserLevel.Enabled = false ;
            DTPBirthDate.Enabled = false ;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            enableTextBox();
        }

        void clearTextBox()
        {
            txtID.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtAge.Text = "";
            DTPBirthDate.Value = DateTime.Now;
            txtAddress.Text = "";
            txtStatus.Text = "";
            txtUserLevel.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtContactNo.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Enabled = false;
            enableTextBox();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bsource.Filter = string.Format("[last_name] LIKE '%{0}%' OR [first_name] LIKE '%{0}%'", txtSearch.Text);

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceFrm maintenancefrm = new MaintenanceFrm();
            maintenancefrm.Show();
        }
    }
}
