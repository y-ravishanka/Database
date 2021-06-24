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
    public partial class Form10 : Form
    {
        SQLClass func1 = new SQLClass();
        Message msg = new Message();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string table = "overdue";
            string que = "select * from overdue";
            con.Open();
            SqlDataAdapter dta = new SqlDataAdapter(que, con);
            DataSet ds = new DataSet();
            dta.Fill(ds, table);
            fineData.DataSource = ds;
            fineData.DataMember = table;
            con.Close();
        }

        private void search()
        {
            string que = "SELECT DATEDIFF(day,(select top 1 duedate from overdue where borrowerid='"+bs.Text+"' order by duedate),GETDATE()) AS DateDiff";
            SqlCommand cmd = new SqlCommand(que, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                od.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();

        }

        private void calculate()
        {
            string que = "select dbo.calculate_fine("+int.Parse(od.Text)+","+double.Parse(pd.Text)+")";
            SqlCommand cmd = new SqlCommand(que, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cf.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
