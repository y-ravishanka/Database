using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace libraryms
{
    public partial class Form3 : Form
    {
        private string id = null;
        private int n1 = 0, n2 = 0, n3 = 0;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");
        SQLClass func1 = new SQLClass();
        Message msg = new Message();

        public Form3(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 f7 = new Form7(id);
            f7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(4,id);
            f6.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s1 = ulselec.Text;
            n2 = check(s1);
            load(check(s1), 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string s1 = dlselec.Text;
            n3 = check(s1);
            load(check(s1), 3);

        }


        private void button4_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (n2 == 1)
            {
                tmp = func1.update_MLibrary(ulfn.Text, ulnv.Text, ulln.Text);
            }
            else if (n2 == 0)
            {
                tmp = func1.update_BLibrary(ulfn.Text, ulnv.Text, ulln.Text);
            }
            if (tmp == 1)
            {
                msg.succes_que();
            }
            else
            {
                msg.invalid_data(null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (n1 == 1)
            {
                tmp = func1.insert_MLibrary(alln.Text, alal1.Text, alal2.Text, alal3.Text, int.Parse(alt.Text));
            }
            else if (n1 == 0)
            {
                tmp = func1.insert_BLibrary(alln.Text, alal1.Text, alal2.Text, alal3.Text, int.Parse(alt.Text), almlselec.Text);
            }
            if (tmp == 1)
            {
                msg.succes_que();
            }
            else
            {
                msg.invalid_data(null);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string s1 = alselec.Text;
            n1 = check(s1);
            load(check(s1), 1);
        }

        private void load(int t1,int t2)
        {
            string que = null;
            if (t2 == 1)
            {
                if (t1 == 0)
                {
                    t1 = 1;
                }
            }
            if (t1 == 1)
            {
                que = "select mlname from mainlibrary";
            }
            else if (t1 == 0)
            {
                que = "select blname from branchlibrary";
            }

            con.Open();
            SqlCommand cmd = new SqlCommand(que, con);
            SqlDataReader DR = cmd.ExecuteReader();
            almlselec.Items.Clear();
            ulln.Items.Clear();
            dlln.Items.Clear();
            while (DR.Read())
            {
                if (t2 == 1)
                {
                    almlselec.Items.Add(DR[0]);
                }
                else if (t2 == 2)
                {
                    ulln.Items.Add(DR[0]);
                }
                else if (t2 == 3)
                {
                    dlln.Items.Add(DR[0]);
                }

            }

            con.Close();
        }

        private int check(string s1)
        {
            int t = 0;
            if (s1.Equals("Main Library") == true)
            {
                t = 1;
            }
            else if (s1.Equals("Branch Library") == true)
            {
                t = 0;
            }
            return t;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (n3 == 1)
            {
                tmp = func1.delete_MLibrary(dlln.Text);
            }
            else if (n3 == 0)
            {
                tmp = func1.delete_BLibrary(dlln.Text);
            }
            if (tmp == 1)
            {
                msg.succes_que();
            }
            else
            {
                msg.invalid_data(null);
            }
        }
    }
}

/*
int tmp =;
if (tmp == 1)
{
    msg.succes_que();
}
else
{
    msg.invalid_data(null);
}
*/