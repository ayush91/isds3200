using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment7.App_Code;




namespace Assignment7
{
    public partial class Confirmation : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Pageloading();
        }

        public void Pageloading()
        {
            //Label1.Text = Session["everything"].ToString();
            Allinitiallizing awesome2 = (Allinitiallizing)Session["everything"];
            Label1.Text = awesome2.Fullname();
            Label2.Text = awesome2.email;
            Label3.Text = awesome2.MF;
            
        }
      
    }
}