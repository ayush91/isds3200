using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MembersData
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if ( radioAfter.Checked == true)
            {
                this.membersTableAdapter.GetMembersAfterDate(karateDataSet.Members, dateTimePicker1.Value);

            }
            else
            {
                this.membersTableAdapter.GetMemberBeforeDate(karateDataSet.Members, dateTimePicker1.Value);
            }
        }

        private void populateDataGrid()
        {
            if (radioAfter.Checked == true)
            {
                this.membersTableAdapter.GetMembersAfterDate(karateDataSet.Members, dateTimePicker1.Value);

            }
            else
            {
                this.membersTableAdapter.GetMemberBeforeDate(karateDataSet.Members, dateTimePicker1.Value);
            }
        }
        private void radioBefore_CheckedChanged(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        private void radioAfter_CheckedChanged(object sender, EventArgs e)
        {
            populateDataGrid();
        }
    }
}
