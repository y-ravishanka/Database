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
    public partial class Form2 : Form
    {
        private string id = null;
        SQLClass s1 = new SQLClass();
        Message s2 = new Message();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");

        public Form2(string id)
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
            Form6 f6 = new Form6(3,id);
            f6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 
            int tmp = s1.insert_Staff(sid.Text, sfn.Text, smn.Text, sln.Text, sa1.Text, sa2.Text, sa3.Text, su.Text, sp.Text, sg.Text, mln.Text, smid.Text, int.Parse(stp.Text), spc.Text);
            if (tmp == 1)
            {
                s2.succes_que();
            }
            else
            {
                s2.invalid_data(null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int tmp = s1.update_Staff(sidu.Text, sfu.Text, snu.Text);
            if (tmp == 1)
            {
                s2.succes_que();
            }
            else
            {
                s2.invalid_data(null);
            }
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int tmp = s1.delete_Staff(sidd.Text);
            if (tmp == 1)
            {
                s2.succes_que();
            }
            else
            {
                s2.invalid_data(null);
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
                mln.Items.Add(DR[0]);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}

/*
 *  int tmp =
    if (tmp == 1)
    {

    }
    else
    {

    }
*/