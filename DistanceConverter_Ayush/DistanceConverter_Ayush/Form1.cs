using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanceConverter_Ayush
{
    public partial class Form1 : Form
    {
        private string item1;
        private string item2;
        private decimal number;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show(" Please enter something in textbox");
            }
            else if (( number = decimal.Parse(textBox1.Text)) <= 0)
            {
                MessageBox.Show("Please select a Positive number and a number greater than 0");

            }
            else
            {
                number = decimal.Parse(textBox1.Text);

                //string item1 = listBox1.GetItemText(listBox1.SelectedItem);
                //string item2 = listBox2.GetItemText(listBox2.SelectedItem);


                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select an item from Convert from first");
                }

                if (listBox2.SelectedIndex == -1)
                {

                    MessageBox.Show("Please Select an item from Convert to first");
                }
                string item1 = listBox1.GetItemText(listBox1.SelectedItem);
                string item2 = listBox2.GetItemText(listBox2.SelectedItem);


                {
                    if (item1 == "Yard")
                    {
                        if (item2 == "Yard")
                        {
                            total = number;
                        }
                        if (item2 == "Foot")
                        {

                            total = number * 3;
                        }
                        if (item2 == "Inch")
                        {
                            total = number * 36;

                        }
                    }
                    if (item1 == "Foot")
                    {
                        if (item2 == "Yard")
                        {
                            total = number / 3;
                        }
                        if (item2 == "Foot")
                        {

                            total = number;
                        }
                        if (item2 == "Inch")
                        {
                            total = number * 12;

                        }

                    }
                    if (item1 == "Inch")
                    {
                        if (item2 == "Yard")
                        {
                            total = number / 36;
                        }
                        if (item2 == "Foot")
                        {

                            total = number / 12;
                        }
                        if (item2 == "Inch")
                        {
                            total = number;

                        }
                    }


                    label4.Text = total.ToString("N");

                }
            }

        }
    }
           
            }


 
          

        
 
