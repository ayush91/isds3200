using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usernameandpasswordlogin
{
    public partial class Form1 : Form
    {
        usernameandpassword practice = new usernameandpassword();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           practice.username = textBox1.Text;
           practice.password = textBox2.Text;

            if( practice.check())
            {
                MessageBox.Show("Username and password is correct");
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}
