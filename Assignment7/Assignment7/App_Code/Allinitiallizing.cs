using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment7.App_Code
{
    public class Allinitiallizing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string MF { get; set; }
        public string Fullname()
        {
            return this.FirstName + " " + this.LastName;
             
        }

        public override string ToString()
        {
            return everythingtogether().ToString();
        }
        public string everythingtogether()
        {
            return "Name:" + "\t" + Fullname() + "<br /> <br />" + "Email Address:" + "\t" + this.email + "<br /> <br />" + "Gender:" + "\t" + MF;
        }
        
        
    }
    }
