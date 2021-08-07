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
    public partial class Sections : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-U0A9B3M;Initial Catalog=CMS1;Integrated Security=True");
        public Sections()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel a = new AdminPanel();
            a.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s_class =comboBox2.Text;
            string s_section = comboBox3.Text;
            if (s_class == "" || s_section == "")
            {
                MessageBox.Show("Kindly Fill Both Combo Boxes", "Error");
            }
            else {
                try
                {
                    connection.Open();
                    SqlDataAdapter s = new SqlDataAdapter("exec sectionalview " + "'" + s_class + "'" + " , " + "'" + s_section + "'", connection);
                    DataTable a = new DataTable();
                    s.Fill(a);
                    dataGridView1.DataSource = a;
                    connection.Close();
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
               
            }
         
        }
    }
}
