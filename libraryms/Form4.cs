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
    public partial class Form4 : Form
    {
        private string id = null;
        SQLClass func1 = new SQLClass();
        Message msg = new Message();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");

        public Form4(string id)
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
            Form6 f6 = new Form6(1,id);
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (dselec.Text.Equals("BOOK") == true)
            {
                tmp = func1.delete_Book(did.Text);
            }
            else if(dselec.Text.Equals("COPY") == true)
            {
                tmp = func1.delete_Copy(did.Text);
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

        private void button4_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (uselec.Text.Equals("BOOK") == true)
            {
                tmp = func1.update_Book(ufn.Text, unv.Text, uid.Text);
            }
            else if (uselec.Text.Equals("COPY") == true)
            {
                tmp = func1.update_Copy(ufn.Text, unv.Text, uid.Text);
                int tmp10 = func1.insert_ManageCopy(id, uid.Text, "Update");
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
            int tmp = 0,tmp1 = 0;
            if (aselec.Text.Equals("BOOK") == true)
            {
                tmp = func1.insert_Book(aid.Text, at.Text, ap.Text, ag.Text);

                string[] s1 = { null, null, null, null };
                int t1 = 0;
                if (aa1c.Checked == true)
                {
                    t1 = 1;
                    if (aa2c.Checked == true)
                    {
                        t1 = 2;
                        if (aa3c.Checked == true)
                        {
                            t1 = 3;
                            if (aa4c.Checked == true)
                            {
                                t1 = 4;
                            }
                        }
                    }
                }
                s1[0] = aa1.Text;
                s1[1] = aa2.Text;
                s1[2] = aa3.Text;
                s1[3] = aa4.Text;

                tmp1 = func1.insert_Author(s1, aid.Text, t1);
            }
            else if (aselec.Text.Equals("COPY") == true)
            {
                tmp = func1.insert_Copy(acid.Text, double.Parse(apr.Text), aln.Text, aid.Text);
                int tmp10 = func1.insert_ManageCopy(id, acid.Text, "Insert");
            }
            if (tmp == 1 || tmp1 == 1)
            {
                msg.succes_que();
            }
            else
            {
                msg.invalid_data(null);
            }
        }

        private void load()
        {
            string que = null;
            que = "select mlname from mainlibrary";
            con.Open();
            SqlCommand cmd = new SqlCommand(que, con);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                aln.Items.Add(DR[0]);
            }
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            load();
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