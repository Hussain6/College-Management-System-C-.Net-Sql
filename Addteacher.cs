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
    public partial class Addteacher : Form
    {
        public Addteacher()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        private void empty()
        {
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
        private void button2_Click(object sender, EventArgs e)
        {
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
            else {

                con.Open();
                SqlCommand com = new SqlCommand("insert into teacherinfo values(@tname,@tcnic,@tgender,@treligion,@tdateofjoining,@taddress,@tnationality,@tcontact,@tdob,@tclass,@tsection)", con);
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
                Console.Beep();
                MessageBox.Show("Teacher Record has been Added", "Congratulations");
                empty();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel ad = new AdminPanel();
            ad.Show();
        }
    }
}
