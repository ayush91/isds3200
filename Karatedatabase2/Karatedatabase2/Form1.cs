using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karatedatabase2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'karateDataSet.Members' table. You can move, or remove it, as needed.
            this.membersTableAdapter.Fill(this.karateDataSet.Members);

        }

        private void yahoo()
        {
            if ( radioafter.Checked)
            {
                this.membersTableAdapter.radioafter(karateDataSet.Members, dateTimePicker1.Value);
            }
            else
            {
                this.membersTableAdapter.radiobefore(karateDataSet.Members, dateTimePicker1.Value);
            }
        }
        private void radiobefore_CheckedChanged(object sender, EventArgs e)
        {
            yahoo();
        }

        private void radioafter_CheckedChanged(object sender, EventArgs e)
        {
            yahoo();
        }
    }
}
