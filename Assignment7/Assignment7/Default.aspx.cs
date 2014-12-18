using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment7.App_Code;

// Ayush Gupta
// This program was okay. Its just a page redirect while showing the confirmation


namespace Assignment7
{
    public partial class Default : System.Web.UI.Page
    {

        Allinitiallizing awesome = new Allinitiallizing();

        protected void Page_Load(object sender, EventArgs e)
        {
                     
        }
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        awesome.FirstName = TextBox1.Text.ToString();
        awesome.LastName = TextBox2.Text.ToString();
        awesome.MF = RadioButtonList1.SelectedValue.ToString();
        awesome.email = TextBox3.Text.ToString();
        //Session["Name"] = awesome.Fullname();
        //Session["Email"] = awesome.email;
        //Session["Gender"] = awesome.MF;
        Session["everything"] = awesome;
        Response.Redirect("Confirmation.aspx");
        

       
    }
    }

}