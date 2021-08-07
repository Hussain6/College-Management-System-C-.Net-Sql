using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
            
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label4.Text = DateTime.Now.ToLongTimeString();
            label6.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStudents addstudent = new AddStudents();
            addstudent.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            studentrecords stdrec = new studentrecords();
            stdrec.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Addteacher at = new Addteacher();
            at.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            feedeposit f = new feedeposit();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacherrecords t = new Teacherrecords();
            t.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            feerecords f = new feerecords();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sections s = new Sections();
            s.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Librarybooks l = new Librarybooks();
            l.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            bookissue b = new bookissue();
            b.Show();
        }
    }
}
