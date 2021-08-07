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
    public partial class Teacherrecords : Form
    {
        public Teacherrecords()
        {
            InitializeComponent();
            showdata();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }
        private void showdata()
        {
            con.Open();
            DataTable d = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select t_id as 'Teacher ID' , t_name as 'Name' , t_cnic as 'CNIC' , t_gender as 'Gender', t_religion as 'Religion', t_dateofjoining as 'Date of Joining', t_homeaddress as 'Home Address', t_nationality as 'Nationality' , t_contact as 'Contact', t_dob as 'DOB' , t_class as 'Class' , t_section as 'Section' from teacherinfo", con);
            sda.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel a = new AdminPanel();
            a.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void searchbyid()
        {
            string searchid = textBox7.Text;
            con.Open();
            DataTable d = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select t_id as 'Teacher ID' , t_name as 'Name' , t_cnic as 'CNIC' , t_gender as 'Gender', t_religion as 'Religion', t_dateofjoining as 'Date of Joining', t_homeaddress as 'Home Address', t_nationality as 'Nationality' , t_contact as 'Contact', t_dob as 'DOB' , t_class as 'Class' , t_section as 'Section' from teacherinfo where t_id Like '%" + searchid + "%'", con);
            sda.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();
        }
        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            searchbyid();
        }
        private void searchbyname()
        {
            string searchname = textBox9.Text;
            con.Open();
            DataTable d = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select t_id as 'Teacher ID' , t_name as 'Name' , t_cnic as 'CNIC' , t_gender as 'Gender', t_religion as 'Religion', t_dateofjoining as 'Date of Joining', t_homeaddress as 'Home Address', t_nationality as 'Nationality' , t_contact as 'Contact', t_dob as 'DOB' , t_class as 'Class' , t_section as 'Section' from teacherinfo where t_name Like '%" + searchname + "%'", con);
            sda.Fill(d);
            dataGridView1.DataSource = d;
            con.Close();

        }
        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            searchbyname();
        }
        private void empty()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            dateTimePicker2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            empty();
            textBox2.Text=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker1.Text= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text= dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text= dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text= dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            dateTimePicker2.Text= dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            comboBox2.Text= dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            comboBox3.Text= dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tid = textBox2.Text;
            string tname = textBox1.Text;
            string tcnic = textBox3.Text;
            string tgender = comboBox1.Text;
            string treligion = textBox4.Text;
            string tdateofjoining = dateTimePicker1.Text;
            string taddress = textBox5.Text;
            string tnationality = textBox6.Text;
            string tcontact = textBox8.Text;
            string tdob = dateTimePicker2.Text;
            string tclass = comboBox2.Text;
            string tsection = comboBox3.Text;
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox8.Text == "" || dateTimePicker2.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Kindly Kill all the Data", "Error");
            }
            else
            {

                con.Open();
                SqlCommand com = new SqlCommand("Update teacherinfo set t_name=@tname,t_cnic=@tcnic,t_gender=@tgender,t_religion=@treligion,t_dateofjoining=@tdateofjoining,t_homeaddress=@taddress,t_nationality=@tnationality,t_contact=@tcontact,t_dob=@tdob,t_class=@tclass,t_section=@tsection where t_id=@tid", con);
                com.Parameters.AddWithValue("@tid", tid);
                com.Parameters.AddWithValue("@tname", tname);
                com.Parameters.AddWithValue("@tcnic", tcnic);
                com.Parameters.AddWithValue("@tgender", tgender);
                com.Parameters.AddWithValue("@treligion", treligion);
                com.Parameters.AddWithValue("@tdateofjoining", tdateofjoining);
                com.Parameters.AddWithValue("@taddress", taddress);
                com.Parameters.AddWithValue("@tnationality", tnationality);
                com.Parameters.AddWithValue("@tcontact", tcontact);
                com.Parameters.AddWithValue("@tdob", tdob);
                com.Parameters.AddWithValue("@tclass", tclass);
                com.Parameters.AddWithValue("@tsection", tsection);
                com.ExecuteNonQuery();
                con.Close();
                Console.Beep();
                MessageBox.Show("Teacher Record has been Updated", "Congratulations");
                showdata();
                empty();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tid = textBox2.Text;
            string tcnic = textBox3.Text;
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox8.Text == "" || dateTimePicker2.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Kindly Kill all the Data", "Error");
            }
            else
            {

                con.Open();
                SqlCommand com = new SqlCommand("Delete from teacherinfo where t_id=@tid and t_cnic=@tcnic", con);
                com.Parameters.AddWithValue("@tid", tid);
                com.Parameters.AddWithValue("@tcnic", tcnic);
                com.ExecuteNonQuery();
                con.Close();
                Console.Beep();
                MessageBox.Show("Teacher Record has been Deleted ", "Congratulations");
                showdata();
                empty();
            }
            }
    }
}
