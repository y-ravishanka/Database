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
    public partial class Form9 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");

        public Form9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string table = ss.Text;
            string que = "select * from "+table;
            SqlDataAdapter dta = new SqlDataAdapter(que, con);
            DataSet ds = new DataSet();
            dta.Fill(ds, table);
            smView.DataSource = ds;
            smView.DataMember = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
