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
    public partial class Librarybooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        public Librarybooks()
        {
            InitializeComponent();
        }
        private void Display()
        {
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from books",con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        
        }
        private void Librarybooks_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel a = new AdminPanel();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string b_isbn = textBox6.Text;
            string b_title = textBox7.Text;
            string b_author = textBox8.Text;
            string b_publisher = textBox1.Text;
            string b_date = dateTimePicker2.Text;
            if (b_isbn == "" || b_title == "" || b_author == "" || b_publisher == "" || b_date == "")
            {
                MessageBox.Show("Please Fill All the Data", "Error");
            }
            else {

                try
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("insert into librarybooks values(@b_isbn,@b_title,@b_author,@b_publisher,@b_date)", con);
                    s.Parameters.AddWithValue("@b_isbn", b_isbn);
                    s.Parameters.AddWithValue("@b_title", b_title);
                    s.Parameters.AddWithValue("@b_author", b_author);
                    s.Parameters.AddWithValue("@b_publisher", b_publisher);
                    s.Parameters.AddWithValue("@b_date", b_date);
                    s.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("Book has been Added", "Congratualtions");
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                    con.Close();
                }
              
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string b_isbn = textBox6.Text;
            string b_title = textBox7.Text;
            string b_author = textBox8.Text;
            string b_publisher = textBox1.Text;
            string b_date = dateTimePicker2.Text;
            if (b_isbn == "" || b_title == "" || b_author == "" || b_publisher == "" || b_date == "")
            {
                MessageBox.Show("Please Fill All the Data", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("update librarybooks set b_isbn=@b_isbn , b_title=@b_title,b_author=@b_author,b_publishers=@b_publisher,b_publishingyear=@b_date where b_isbn=@b_isbn", con);
                    s.Parameters.AddWithValue("@b_isbn", b_isbn);
                    s.Parameters.AddWithValue("@b_title", b_title);
                    s.Parameters.AddWithValue("@b_author", b_author);
                    s.Parameters.AddWithValue("@b_publisher", b_publisher);
                    s.Parameters.AddWithValue("@b_date", b_date);
                    s.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("Book has been Updated", "Congratualtions");
                }
                catch (Exception ae)
                {
                    MessageBox.Show(ae.Message);
                    con.Close();
                }

            }
           
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string b_isbn = textBox6.Text;
            string b_title = textBox7.Text;
            string b_author = textBox8.Text;
            string b_publisher = textBox1.Text;
            string b_date = dateTimePicker2.Text;
            if (b_isbn == "")
            {
                MessageBox.Show("Please Enter ISBN to Delete Book", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("delete from librarybooks where b_isbn=@b_isbn", con);
                    s.Parameters.AddWithValue("@b_isbn", b_isbn);
                    s.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("Book has been Deleted", "Congratualtions");
                }
                catch (Exception ae)
                {
                    MessageBox.Show(ae.Message);
                    con.Close();
                }

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            string b_isbn = textBox4.Text;
            SqlDataAdapter s = new SqlDataAdapter("select * from books where [ISBN] Like "+"'%" +b_isbn+ "%'" , con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            string b_name = textBox5.Text;
            SqlDataAdapter s = new SqlDataAdapter("select * from books where [Book Title] Like " + "'%" + b_name + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }
    }
}
