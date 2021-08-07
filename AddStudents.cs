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
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }

        private void AddStudents_Load(object sender, EventArgs e)
        {

        }
        private void empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Kindly Kill all the Data", "Error");
            }
            else {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
                string sname = textBox1.Text;
                string sfather = textBox2.Text;
                string scnic = textBox3.Text;
                string sgender = comboBox1.Text;
                string sreligion = textBox4.Text;
                string sdateofadmission = dateTimePicker1.Text;
                string saddress = textBox5.Text;
                string snationality = textBox6.Text;
                string sfathercontact = textBox7.Text;
                string scontact = textBox8.Text;
                string sdob = dateTimePicker2.Text;
                string sclass = comboBox2.Text;
                string ssection = comboBox3.Text;

                connection.Open();

                SqlCommand com = new SqlCommand("insert into studentinfo(s_Name, s_FatherName, s_CNIC, s_Gender,s_Religion, s_DateOfAdmission, s_HomeAddress, s_Nationality, s_FatherContactNo, s_StudentContactNo,s_DOB, s_Class, s_Section) values (@stname, @stfathername, @stcnic, @stgender, @streligion, @stdoa, @sthomeaddress, @stnationality, @stfatherno, @stno, @stdob, @sclass, @stsection)",connection);
                com.Parameters.AddWithValue("@stname", sname);
                com.Parameters.AddWithValue("@stfathername", sfather);
                com.Parameters.AddWithValue("@stcnic", scnic);
                com.Parameters.AddWithValue("@stgender", sgender);
                com.Parameters.AddWithValue("@streligion", sreligion);
                com.Parameters.AddWithValue("@stdoa", sdateofadmission);
                com.Parameters.AddWithValue("@sthomeaddress", saddress);
                com.Parameters.AddWithValue("@stnationality", snationality);
                com.Parameters.AddWithValue("@stfatherno", sfathercontact);
                com.Parameters.AddWithValue("@stno", scontact);
                com.Parameters.AddWithValue("@stdob", sdob);
                com.Parameters.AddWithValue("@sclass", sclass);
                com.Parameters.AddWithValue("@stsection", ssection);
                com.ExecuteNonQuery();
                connection.Close();
                Console.Beep();
                MessageBox.Show("Student Record has been Added", "Congratulations");
                empty();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adpan = new AdminPanel();
            adpan.Show();
        }
    }
}
