using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal balance;
            int month;
            int count = 1;
            const decimal INTEREST_RATE = 0.005m;

            if(int.TryParse(textBox2.Text, out month))
            {
                if (decimal.TryParse(textBox1.Text, out balance))
                {
                    while ( count <= month)
                    {
                        balance = balance + (INTEREST_RATE * balance);
                        listBox1.Items.Add(" The ending balance for month" + count + " is " + balance);
                        count++;
                    }
                    label4.Text = balance.ToString("C");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number for months");
            }

        }
    }
}
