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
    public partial class Form1 : Form
    {
        private string id = null;
        SQLClass s1 = new SQLClass();
        Message s2 = new Message();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");

        public Form1(string id)
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
            Form6 f6 = new Form6(2,id);
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int tmp = s1.delete_Borrower(dbbid.Text);
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
            int t1 = 0;
            if(ubselet.Checked == true) { t1 = 1; }
            else { t1 = 0; }
            
            if (t1 == 0)
            {
                int tmp = s1.update_Borrower(ubfn.Text, ubnv.Text, ubbid.Text);
                int tmp2 = s1.insert_ManageBorrower(id, ubbid.Text,"Update");
                if (tmp == 1)
                {
                    s2.succes_que();
                }
                else
                {
                    s2.invalid_data(null);
                }
            }
            else
            {
                int tmp3 = s1.update_BorrowerTelephone(ubbid.Text, int.Parse(ubnv.Text));
                int tmp2 = s1.insert_ManageBorrower(id, ubbid.Text, "Update");
                if (tmp3 == 1)
                {
                    s2.succes_que();
                }
                else
                {
                    s2.invalid_data(null);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = abdob.Value.ToString("yyyy-MM-dd");
            int t = 1;
            int[] t2 = { 0, 0 };
            t2[0] = int.Parse(abtp1.Text);
            if (abtselec.Checked == true)
            {
                t = 2;
                t2[1] = int.Parse(abtp2.Text);
            }
            int tmp = s1.insert_Borrower(abid.Text, abfn.Text, abmn.Text, abln.Text, abnic.Text, date, abal1.Text, abal2.Text, abal3.Text, abg.Text, abmln.Text, t2, t);
            int tmp2 = s1.insert_ManageBorrower(id, abid.Text, "Insert");
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
                abmln.Items.Add(DR[0]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}

/*
int tmp =;
if (tmp == 1)
{

}
else
{

}
*/
