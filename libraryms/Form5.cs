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
    public partial class Form5 : Form
    {
        private string[] tmp = new string[2];
        private string uname = null;
        private string pword = null;
        private int t = 0;
        SQLClass s1 = new SQLClass();
        Message s2 = new Message();

        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_varible();
            if (t == 1)
            {
                tmp = s1.check_login(uname,pword);
                int t = int.Parse(tmp[0]);
                if (t==1)
                {
                    this.Hide();
                    s1.insert_LoginTime(tmp[1]);
                    Form7 f7 = new Form7(tmp[1]);
                    f7.Show();
                }
                else
                {
                    s2.invalid_data(null);
                }

            }
            else
            {
                s2.invalid_data(null);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void get_varible()
        {
            if (un.Text != null)
            {
                if (pw.Text != null)
                {
                    uname = un.Text;
                    pword = pw.Text;
                    t = 1;
                }
                else
                {
                    t = 0;
                }
            }
            else
            {
                t = 0;
            }
        }
    }
}
