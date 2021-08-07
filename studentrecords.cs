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
    public partial class studentrecords : Form
    {
        public studentrecords()
        {
            InitializeComponent();
            Datashow();
            
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        private void Datashow()
        {
            
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select s_ID as 'Student ID' , s_Name as 'Name' , s_FatherName as 'Father Name' , s_CNIC as 'CNIC' , s_Gender as 'Gender' , s_Religion as 'Religion' , s_DateOfAdmission as 'Date of Admission' , s_HomeAddress as 'Home Address' , s_Nationality as 'Nationality', s_FatherContactNo as 'Father Contact' , s_StudentContactNo as 'Student Contact' , s_DOB as 'DOB' , s_Class as Class , s_Section as 'Section'  from studentinfo", connection);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
;        }
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
            textBox11.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel ad = new AdminPanel();
            ad.Show();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void searchbyid()
        {
            connection.Open();
            string searchbyid = textBox9.Text;
            DataTable d1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select s_ID as 'Student ID' , s_Name as 'Name' , s_FatherName as 'Father Name' , s_CNIC as 'CNIC' , s_Gender as 'Gender' , s_Religion as 'Religion' , s_DateOfAdmission as 'Date of Admission' , s_HomeAddress as 'Home Address' , s_Nationality as 'Nationality', s_FatherContactNo as 'Father Contact' , s_StudentContactNo as 'Student Contact' , s_DOB as 'DOB' , s_Class as Class , s_Section as 'Section'  from studentinfo where s_ID Like '%"+ searchbyid+ "%'", connection);
            sda.Fill(d1);
            dataGridView1.DataSource = d1;
            connection.Close();
        }
        private void searchbyname()
        {
            connection.Open();
            string searchbyname = textBox10.Text;
            DataTable d1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select s_ID as 'Student ID' , s_Name as 'Name' , s_FatherName as 'Father Name' , s_CNIC as 'CNIC' , s_Gender as 'Gender' , s_Religion as 'Religion' , s_DateOfAdmission as 'Date of Admission' , s_HomeAddress as 'Home Address' , s_Nationality as 'Nationality', s_FatherContactNo as 'Father Contact' , s_StudentContactNo as 'Student Contact' , s_DOB as 'DOB' , s_Class as Class , s_Section as 'Section'  from studentinfo where s_Name Like '%"+ searchbyname+ "%'", connection);
            sda.Fill(d1);
            dataGridView1.DataSource = d1;
            connection.Close();
        }
        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            searchbyid();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox10_KeyUp_1(object sender, KeyEventArgs e)
        {
            searchbyname();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox11.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //Student Id
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string stcnic = textBox3.Text;
            string stid = textBox11.Text;
            connection.Open();
            SqlCommand com = new SqlCommand("Delete from studentinfo where s_ID=@sid and s_CNIC=@scnic", connection);
            com.Parameters.AddWithValue("@sid",stid);
            com.Parameters.AddWithValue("@scnic", stcnic);
            com.ExecuteNonQuery();
            connection.Close();
            Console.Beep();
            MessageBox.Show("Student Has been Deleted Sucessfully !!", "Info");
            empty();
            Datashow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sid = textBox11.Text;
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

            SqlCommand com = new SqlCommand("Update studentinfo set s_Name=@stname, s_FatherName=@stfathername, s_CNIC= @stcnic, s_Gender=@stgender,s_Religion=@streligion, s_DateOfAdmission=@stdoa, s_HomeAddress=@sthomeaddress, s_Nationality= @stnationality, s_FatherContactNo=@stfatherno, s_StudentContactNo=@stno,s_DOB=@stdob, s_Class=@sclass, s_Section=@stsection where s_ID= @sid", connection);
            com.Parameters.AddWithValue("sid", sid);
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
            Datashow();
        }

        private void studentrecords_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
