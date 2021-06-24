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
    public partial class Form6 : Form
    {

        private int i, j;
        private int t=0;
        private string que = null;
        private string id = null;
        SQLClass func1 = new SQLClass();

        public Form6(int t,string id)
        {
            InitializeComponent();
            this.t = t;
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string table1 = null;
            string que1 = null;
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");
            con1.Open();
            if (t == 5)
            {
                table1 = "loans";
                tname.Text = table1;
                que1 = "SELECT * FROM Loans WHERE BorrowerID = '" + sh.Text + "'";
            }
            else if (t == 6)
            {
                table1 = "returns";
                tname.Text = table1;
                que1 = "SELECT * FROM RETURNS WHERE BorrowerID = '" + sh.Text + "'";
            }
            else if (t == 7)
            {
                table1 = "overdue";
                tname.Text = table1;
                que1 = "SELECT * FROM OVERDUE WHERE BorrowerID = '" + sh.Text + "';";
            }
            else if (t == 8)
            {
                table1 = "activitylog";
                tname.Text = table1;
                que1 = "SELECT * FROM ACTIVITYLOG WHERE StaffID = '" + sh.Text + "';";
            }
            else if (t == 3)
            {
                int t5 = func1.check_manager(id);
                if (t5 == 1)
                {
                    table1 = "view_headlibrarian";
                    tname.Text = table1;
                    que1 = "SELECT * FROM view_headlibrarian where managerid = '" + id + "' and  StaffID = '" + sh.Text + "';";
                }
                else
                {
                    string s5 = func1.get_MLname(id);
                    table1 = "view_librarian";
                    tname.Text = table1;
                    que1 = "SELECT * FROM from view_librarian where mlname='" + s5 + "' AND StaffID = '" + sh.Text + "';";
                }

            }
            else if (t == 1)
            {
                table1 = "Book_and_Copy_Details";
                tname.Text = table1;
                que1 = "SELECT * FROM COPY WHERE ISBN = " + sh.Text ;
            }
            else if (t == 2)
            {
                table1 = "borrower_details";
                tname.Text = table1;
                que1 = "    SELECT * FROM Borrower WHERE BorrowerID = '"+sh.Text+"'";
            }

            if (table1 != null)
            {
                SqlDataAdapter dta1 = new SqlDataAdapter(que1, con1);
                DataSet ds1 = new DataSet();
                dta1.Fill(ds1, table1);
                dataTable1.DataSource = ds1;
                dataTable1.DataMember = table1;
                table1 = null;
                con1.Close();
            }
        }

        private void loadTable()
        {
            string table=null;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");
            con.Open();
            if (t == 5)
            {
                table = "loans";
                tname.Text = table;
                sh.Text = "Enter Borrower ID";
                que = "select * from loans";
            }
            else if (t == 6)
            {
                table = "returns";
                tname.Text = table;
                sh.Text = "Enter Borrower ID";
                que = "select * from returns";
            }
            else if (t == 7)
            {
                table = "overdue";
                tname.Text = table;
                sh.Text = "Enter Borrower ID";
                que = "select * from overdue";
            }
            else if (t == 8)
            {
                table = "activitylog";
                tname.Text = table;
                sh.Text = "Enter Staff ID";
                que = "select * from activitylog";
            }
            else if (t == 3)
            {
                int t5 = func1.check_manager(id);
                if (t5 == 1)
                {
                    table = "view_headlibrarian";
                    tname.Text = table;
                    sh.Text = "Enter Staff ID";
                    que = "select StaffID,FName,MName,LName,Position,SAdLine1,SAdLine2,SAdLine3,Telephone,Gender,Head_Librarian_Name " +
                        "from view_headlibrarian where managerid='" + id + "'";
                }
                else
                {
                    string s5 = func1.get_MLname(id);
                    table = "view_librarian";
                    tname.Text = table;
                    sh.Text = "Enter Staff ID";
                    que = "select StaffID,FName,LName,Position,Gender,Telephone,Head_Librarian_Name " +
                        "from view_librarian where mlname='"+s5+"'";
                }

            }
            else if (t == 1)
            {
                table = "Book_and_Copy_Details";
                tname.Text = table;
                sh.Text = "Enter ISBN";
                que = "SELECT * FROM Book_and_Copy_Details order by title"; 
            }
            else if (t == 2)
            {
                table = "borrower_details";
                tname.Text = table;
                sh.Text = "Enter Borrower ID";
                que = "select * from borrower_details order by MLName asc";
            }
            else if (t == 4)
            {
                table = "library_details";
                tname.Text = table;
                que = "select * from library_details order by main_library_name,branch_library_name";
            }
            if (table != null)
            {
                SqlDataAdapter dta = new SqlDataAdapter(que, con);
                DataSet ds = new DataSet();
                dta.Fill(ds,table);
                dataTable1.DataSource = ds;
                dataTable1.DataMember = table;
                table = null;
                con.Close();
            }
        }
    }
}
