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
    public partial class Form8 : Form
    {
        private string id = null;
        SQLClass func1 = new SQLClass();
        Message msg = new Message();

        public Form8(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(5,id);
            f6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(6,id);
            f6.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(7,id);
            f6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 f7 = new Form7(id);
            f7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int tmp = func1.delete_Loan(dbcid.Text, dbbid.Text, dbsid.Text);
            if (tmp == 1)
            {
                msg.succes_que();
            }
            else
            {
                msg.invalid_data(null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int tmp = func1.delete_Return(rmdbid.Text, rmdcid.Text);
            if (tmp == 1)
            {
                msg.succes_que();
            }
            else
            {
                msg.invalid_data(null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int tmp = func1.insert_OrverDue(id,aobid.Text, aocid.Text, aod.Value.ToString("yyyy-MM-dd"));
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
            int tmp = func1.insert_Return(ard.Value.ToString("yyyy-MM-dd"), arbid.Text, arcid.Text);
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
            int tmp = func1.insert_Loan(abbd.Value.ToString("yyyy-MM-dd"), abbid.Text, abcid.Text, id);
            if (tmp == 1)
            {
                msg.succes_que();
                MessageBox.Show("The due date for the copy bearing the Copy ID " + abcid.Text + " borrowed by " + abbid.Text + " is " + DateTime.Today.AddDays(14));
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