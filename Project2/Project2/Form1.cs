using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Ayush Gupta
// Assignment 2
// Creating a bank which doesn't accet sting or negative number but you can input as much amount as you want

namespace Project2
{
    public partial class Form1 : Form
    {
        Account newaccount = new Account();
        
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            
            try
            {
                newaccount.num = decimal.Parse(textBox1.Text);
                
                
                newaccount.withdraw();
                  
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Money.Text = newaccount.balance().ToString("C");
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                newaccount.num = decimal.Parse(textBox1.Text);
                              
                newaccount.newdeposit();
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Money.Text = newaccount.balance().ToString("C");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        
    
    }
}
