using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment6
{
   
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return this.AccountId.ToString() + ", " + this.Name + ", " + this.Balance.ToString();
        }

    }
 
}