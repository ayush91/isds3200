using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Calculator
{
    public partial class Form1 : Form
    {
        NumberinScreen practice = new NumberinScreen();
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            practice.textboxdigits += "2";
            textboxupdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "1";
            textboxupdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "3";
            textboxupdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "4";
            textboxupdate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "5";
            textboxupdate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "6";
            textboxupdate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "7";
            textboxupdate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "8";
            textboxupdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "9";
            textboxupdate();
        }

        private void textboxupdate()
        {
            textBox1.Text = practice.textboxdigits.ToString();
            textBox1.Update();
        }

        private void add_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "+";
            textboxupdate();
        }

        private void leftpar_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += "(";
            textboxupdate();
        }

        private void rightpar_Click(object sender, EventArgs e)
        {
            practice.textboxdigits += ")";
            textboxupdate();
        }
    }
}
