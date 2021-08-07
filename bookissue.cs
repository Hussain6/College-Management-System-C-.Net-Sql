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
    public partial class bookissue : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        public bookissue()
        {
            InitializeComponent();
        }
        private void Displaybasicbookinfo()
        {
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from basicbooksinfo", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();

        }
        private void Displaybasicstudentinfo()
        {
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from basicstudentinfo", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView2.DataSource = d;
            con.Close();
        }
        private void Displaybookissueview()
        {
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from bookissueview", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView3.DataSource = d;
            con.Close();
        }
        private void bookissue_Load(object sender, EventArgs e)
        {
            Displaybasicbookinfo();
            Displaybasicstudentinfo();
            Displaybookissueview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel a = new AdminPanel();
            a.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            textBox6.Text = ""; //Student Id
            textBox3.Text = "";   //Student Name
            comboBox2.Text = "";   //Class
            comboBox3.Text = "";   //Section
            textBox8.Text = "";   //Book ID
            textBox7.Text = "";  //ISBN
            textBox9.Text = "";   //Book Title
            dateTimePicker2.Text = "";  //Issue Date
            dateTimePicker1.Text = "";  //Return 
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            string searchbyisbn = textBox4.Text;
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from basicbooksinfo where [ISBN] Like " + "'%" + searchbyisbn + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            string searchbytitle = textBox5.Text;
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from basicbooksinfo where [Book Title] Like " + "'%" + searchbytitle + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string s_id = textBox2.Text;
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from basicstudentinfo where [Student ID] Like " + "'%" + s_id + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView2.DataSource = d;
            con.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string s_name = textBox1.Text;
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("select * from basicstudentinfo where [Student Name] Like " + "'%" + s_name + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView2.DataSource = d;
            con.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox3.Text= dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                comboBox2.Text= dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox6.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString(); //Student Id
                textBox3.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString(); //Student Name
                comboBox2.Text = dataGridView3.SelectedRows[0].Cells[6].Value.ToString();  //Class
                comboBox3.Text = dataGridView3.SelectedRows[0].Cells[7].Value.ToString();  //Section
                textBox8.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();  //Book ID
                textBox7.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();  //ISBN
                textBox9.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();  //Book Title
                dateTimePicker2.Text= dataGridView3.SelectedRows[0].Cells[8].Value.ToString(); //Issue Date
                dateTimePicker1.Text= dataGridView3.SelectedRows[0].Cells[9].Value.ToString(); //Return Date

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           string s_id= textBox6.Text ; //Student Id
           string s_name=textBox3.Text ; //Student Name
           string s_class= comboBox2.Text ;  //Class
           string s_section= comboBox3.Text ;  //Section
           string b_id= textBox8.Text ;  //Book ID
           string b_isbn= textBox7.Text ;  //ISBN
           string b_title= textBox9.Text ;  //Book Title
           string b_issuedate= dateTimePicker2.Text ; //Issue Date
           string b_returndate= dateTimePicker1.Text ; //Return Date

            if (s_id == "" || s_name == "" || s_class == "" || s_section == "" || b_id == "" || b_isbn == "" || b_title == "" || b_issuedate == "" || b_returndate == "")
            {
                MessageBox.Show("Kindly Fill All the Data", "Error");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand s = new SqlCommand("insert into bookissue values(@b_id,@b_title,@b_isbn,@s_id,@s_name,@s_class,@s_section, @b_issuedate, @b_returndate)", con);
                    s.Parameters.AddWithValue("@b_id", b_id);
                    s.Parameters.AddWithValue("@b_title", b_title);
                    s.Parameters.AddWithValue("@b_isbn", b_isbn);
                    s.Parameters.AddWithValue("@s_id", s_id);
                    s.Parameters.AddWithValue("@s_name", s_name);
                    s.Parameters.AddWithValue("@s_class", s_class);
                    s.Parameters.AddWithValue("@s_section", s_section);
                    s.Parameters.AddWithValue("@b_issuedate", b_issuedate);
                    s.Parameters.AddWithValue("@b_returndate", b_returndate);
                    s.ExecuteNonQuery();
                    con.Close();
                    clear();
                    Displaybookissueview();
                    MessageBox.Show("Book has been Issued !!!", "Congratulations");
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
            string s_id = textBox6.Text; //Student Id
            string s_name = textBox3.Text; //Student Name
            string s_class = comboBox2.Text;  //Class
            string s_section = comboBox3.Text;  //Section
            string b_id = textBox8.Text;  //Book ID
            string b_isbn = textBox7.Text;  //ISBN
            string b_title = textBox9.Text;  //Book Title
            string b_issuedate = dateTimePicker2.Text; //Issue Date
            string b_returndate = dateTimePicker1.Text; //Return Date

            if (s_id == "" || s_name == "" || s_class == "" || s_section == "" || b_id == "" || b_isbn == "" || b_title == "" || b_issuedate == "" || b_returndate == "")
            {
                MessageBox.Show("Kindly Fill All the Data", "Error");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand s = new SqlCommand("update bookissue set b_id= @b_id,b_title=@b_title,b_isbn=@b_isbn,s_ID=@s_id,s_Name=@s_name,s_Class=@s_class,s_Section=@s_section,issue_date=@b_issuedate,return_date=@b_returndate where b_id=@b_id and s_ID=@s_id", con);
                    s.Parameters.AddWithValue("@b_id", b_id);
                    s.Parameters.AddWithValue("@b_title", b_title);
                    s.Parameters.AddWithValue("@b_isbn", b_isbn);
                    s.Parameters.AddWithValue("@s_id", s_id);
                    s.Parameters.AddWithValue("@s_name", s_name);
                    s.Parameters.AddWithValue("@s_class", s_class);
                    s.Parameters.AddWithValue("@s_section", s_section);
                    s.Parameters.AddWithValue("@b_issuedate", b_issuedate);
                    s.Parameters.AddWithValue("@b_returndate", b_returndate);
                    s.ExecuteNonQuery();
                    con.Close();
                    clear();
                    Displaybookissueview();
                    MessageBox.Show("Record Has Been Updated !!!", "Congratulations");
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                    con.Close();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string s_id = textBox6.Text; //Student Id
            string b_id = textBox8.Text;  //Book ID

            if (s_id == "" || b_id == "")
            {
                MessageBox.Show("Kindly Fill All the Data", "Error");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand s = new SqlCommand("delete from bookissue  where b_id=@b_id and s_ID=@s_id", con);
                    s.Parameters.AddWithValue("@b_id", b_id);
                    s.Parameters.AddWithValue("@s_id", s_id);
                    s.ExecuteNonQuery();
                    con.Close();
                    Displaybookissueview();
                    clear();
                    MessageBox.Show("Record Has Been Deleted !!!", "Congratulations");
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                    con.Close();
                }

            }
        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            string searchbyissueid = textBox11.Text;
            SqlDataAdapter s = new SqlDataAdapter("select * from bookissueview where [Issue ID] Like " + "'%" + searchbyissueid + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView3.DataSource = d;
            con.Close();
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            string searchbystudentname = textBox10.Text;
            SqlDataAdapter s = new SqlDataAdapter("select * from bookissueview where [Student Name] Like " + "'%" + searchbystudentname + "%'", con);
            DataTable d = new DataTable();
            s.Fill(d);
            dataGridView3.DataSource = d;
            con.Close();
        }
    }
}
