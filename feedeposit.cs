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

namespace CMS
{
    public partial class feedeposit : Form
    {
        public feedeposit()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        private void feedeposit_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Kindly Kill all the Data", "Error");
            }
            else {
                con.Open();
                string s_id = textBox1.Text;
                string s_fee = textBox2.Text;
                string s_arrears = textBox3.Text;
                string s_dateofdeposit = dateTimePicker1.Text;
                SqlCommand c = new SqlCommand("Insert into feedeposit values(@sid,@sfee,@sarrears,@sdate)", con);
                c.Parameters.AddWithValue("@sid", s_id);
                c.Parameters.AddWithValue("@sfee", s_fee);
                c.Parameters.AddWithValue("@sarrears", s_arrears);
                c.Parameters.AddWithValue("@sdate", s_dateofdeposit);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Fee Have been Deposited", "Congratulations");
                Empty();
            }
        }

        private void Empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel ap = new AdminPanel();
            ap.Show();
        }
    }
}
