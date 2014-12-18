using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Ayush Gupta
// BAsically a class calculator  tried to simplify the code as i could
// no validation


namespace assignment5again
{
    public partial class Default : System.Web.UI.Page
    {
        private const int ClassA = 65;
        private const int ClassB = 55;
        private const int ClassC = 45;

        private int _classa;
        private int _classb;
        private int _classc;
        private int totalrevenue;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            formloadingloaderchecker();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _classa = int.Parse(TextBox1.Text);
            _classb = int.Parse(TextBox2.Text);
            _classc = int.Parse(TextBox3.Text);

            _classa = _classa * ClassA;
            _classb = _classb * ClassB;
            _classc = _classc * ClassC;
            totalrevenue = _classa + _classb + _classc;

            Label1.Text = _classa.ToString("C");
            Label2.Text = _classb.ToString("C");
            Label3.Text = _classc.ToString("C");

            Label4.Text = totalrevenue.ToString("C");
            
        }
        private void loading()
        {
            TextBox1.Text = "1";
            TextBox2.Text = "1";
            TextBox3.Text = "1";
        }
        private void formloadingloaderchecker()
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            { loading(); }
            else
            { }
            if (string.IsNullOrEmpty(TextBox2.Text))
            { loading(); }
            else
            { }
            if (string.IsNullOrEmpty(TextBox3.Text))
            { loading(); }
            else
            { }
        }
    }
}