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
    public partial class feerecords : Form
    {
        public feerecords()
        {
            InitializeComponent();
            display();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        private void display()
        {
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from feerecords", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel a = new AdminPanel();
            a.Show();
        }

        private void feerecords_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //Fee Id
                textBox11.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            }
        }
        private void Empty()
        {
            textBox2.Text = "";
            textBox11.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string f_id = textBox2.Text;
            string s_id = textBox11.Text;
            string s_fee = textBox7.Text;
            string s_arrears = textBox8.Text;
            string s_dateofdeposit = dateTimePicker2.Text;
            SqlCommand c = new SqlCommand("update feedeposit set s_ID=@sid,s_submittedfee=@sfee,s_arrears=@sarrears,s_Dateofsubmission=@sdate where f_id=@fid and s_ID=@sid ", con);
            c.Parameters.AddWithValue("@fid", f_id);
            c.Parameters.AddWithValue("@sid", s_id);
            c.Parameters.AddWithValue("@sfee", s_fee);
            c.Parameters.AddWithValue("@sarrears", s_arrears);
            c.Parameters.AddWithValue("@sdate", s_dateofdeposit);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Fee Record Have been Updated", "Congratulations");
            display();
            Empty();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string f_id = textBox2.Text;
            string s_id = textBox11.Text;
            SqlCommand c = new SqlCommand("delete from feedeposit where f_id=@fid and s_ID=@sid", con);
            c.Parameters.AddWithValue("@fid", f_id);
            c.Parameters.AddWithValue("@sid", s_id);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Fee Record Have been Deleted", "Congratulations");
            display();
            Empty();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string s_id = textBox4.Text;
            SqlDataAdapter s = new SqlDataAdapter("exec feesearchbyid " + s_id, con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string s_name = textBox5.Text;
            SqlDataAdapter s = new SqlDataAdapter("exec feesearchbyname " + s_name, con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }
    }
}
