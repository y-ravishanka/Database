using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryms
{
    public partial class Form7 : Form
    {
        private string id = null;
        SQLClass s1 = new SQLClass();
        Message msg = new Message();

        public Form7(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(1,id);
            f6.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(2,id);
            f6.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(3,id);
            f6.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(4,id);
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(8,id);
            f6.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            s1.insert_LogoutTime(id);
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1(id);
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2(id);
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3(id);
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4(id);
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8(id);
            f8.Show();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (id.Equals("SID000") == true)
            {
                Form9 f9 = new Form9();
                f9.Show();
            }
            else
            {
                msg.invalid_data("you don't have accsess for this function !!!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }
    }
}
