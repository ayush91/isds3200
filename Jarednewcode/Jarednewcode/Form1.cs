using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jarednewcode
{
    public partial class Form1 : Form
    {
        private decimal sum;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

            decimal distance = decimal.Parse(textBox1.Text);
            string convertfrom = lstConvertFrom.SelectedItem.ToString();
            string convertto = lstConvertTo.SelectedItem.ToString();
           


            {
                if (convertfrom == "Yard")
                {
                    if (convertto == "Yard")
                    {
                        sum = distance;
                    }
                    if (convertto == "Foot")
                    {
                        sum = distance * 3;
                    }
                    if (convertto == "Inches")
                    {
                        sum = distance * 3;
                        sum = sum * 12;
                    }
                }
                if (convertfrom == "Foot")
                {
                    if (convertto == "Yard")
                    {

                        sum = distance / 3;
                    }
                    if (convertto == "Foot")
                    {
                        sum = distance;
                    }
                    if (convertto == "Inches")
                    {
                        sum = distance * 12;
                    }

                }
                if (convertfrom == "Inches")
                {
                    if (convertto == "Yard")
                    {
                        sum = distance / 3;
                        sum = sum / 12;
                    }
                    if (convertto == "Foot")
                    {
                        sum = distance / 12;
                    }
                    if (convertto == "Inches")
                    {
                        sum = distance;
                    }
                }

                lblSolution.Text = sum.ToString("N");
            }
        }

        }
    }

