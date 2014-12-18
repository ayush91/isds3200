using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Studyforisds3200
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAll.aspx");
        }

        protected void CreateNewBug_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewBug.aspx");
        }
    }
}