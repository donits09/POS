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
    public partial class PaymentFrm : Form
    {
        private POSFrm posForm;
        public delegate void PaymentConfirmedEventHandler();
        public event PaymentConfirmedEventHandler PaymentConfirmed;

        public PaymentFrm(POSFrm posForm)
        {
            InitializeComponent();
            this.posForm = posForm;

            txtTotal.Text = posForm.MainTotalValue.ToString("F2");

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DataTable dt = posForm.GetDGVData();

            string transactValue = posForm.GetTransactionLabelValue();
            string discountValue = posForm.GetDiscountLabelValue();
            string vatValue = posForm.GetVatLabelValue();

            string connectionString = @"datasource=localhost;port=3306;username=root;password=admin";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO dbpos.transactions_list (transact_no, discount_amount, tax_amount) VALUES (@Transact, @Discount, @Vat)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Transact", transactValue);
                command.Parameters.AddWithValue("@Discount", discountValue);
                command.Parameters.AddWithValue("@Vat", vatValue);

                command.ExecuteNonQuery();

                foreach (DataRow row in dt.Rows)
                {
                    string insertQuery2 = "INSERT INTO dbpos.orders_list (transact_id, product_id, unit_price, qty) VALUES (@Transact, @Product, @Price, @Qty)";
                    MySqlCommand command2 = new MySqlCommand(insertQuery2, connection);
                    command2.Parameters.AddWithValue("@Transact", transactValue);
                    command2.Parameters.AddWithValue("@Product", row["product_code"]);
                    command2.Parameters.AddWithValue("@Price", row["prod_unit_price"]);
                    command2.Parameters.AddWithValue("@Qty", row["prod_qty"]);


                    command2.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Payment was successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetControls();
            PaymentConfirmed?.Invoke();
        }

        private void ResetControls()
        {
            txtTotal.Text = "0.00";
            txtPayment.Text = "";
            txtChange.Text = "";
            posForm.ClearDGVStocks1();
            this.Hide();
        }
        private void PaymentFrm_Load(object sender, EventArgs e)
        {

        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPayment.Text, out decimal paymentAmount))
            {
                decimal totalAmount = decimal.Parse(txtTotal.Text);
                decimal changeAmount = paymentAmount - totalAmount;
                txtChange.Text = changeAmount.ToString("F2");
            }
            else
            {
                txtChange.Text = string.Empty;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
