using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryms
{
    class Message
    {

        public void invalid_data(string s1)
        {
            DialogResult d;
            d = MessageBox.Show("Invild Entry !!!\nPlease check your Entered Data\n"+s1,"Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (d == DialogResult.OK)
            {
            }
        }

        public void succes_que()
        {
            DialogResult d;
            d = MessageBox.Show("Succesful Query", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (d == DialogResult.OK)
            {
            }
        }

    }
}
