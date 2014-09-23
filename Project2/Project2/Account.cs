using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{

    class Account
    {
        public decimal totalbalance = 1000;
        public decimal yahoo;
        public decimal num
        {
            get { return yahoo; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException(" No negative number in TextBox");
                }
                else
                {
                    yahoo = value;
                }
            }
        }

        public void newdeposit()
        {
            totalbalance = totalbalance + yahoo;
            

        }
        public void withdraw()
        {
            if (totalbalance >= yahoo)
            {
                totalbalance = totalbalance - yahoo;
            }
            else
            {
                throw new ArgumentException(" Can't pick up more than the money you have in account");
            }
            
        }
        public decimal balance()
        {
            return totalbalance;
        }
    }
}
