using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jared2ndcode
{
    public partial class Form1 : Form
    {
        Account myaccount = new Account();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                myaccount.number = decimal.Parse(textBox1.Text);
                myaccount.google();
                myaccount.withdraw();

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            label2.Text = myaccount.balance().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            { 
                myaccount.number = decimal.Parse(textBox1.Text);
                myaccount.google();
                myaccount.deposit();
                
            }
            catch(FormatException ex)
            {
                MessageBox.Show( ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            label2.Text = myaccount.balance().ToString();
        }
    }
}
