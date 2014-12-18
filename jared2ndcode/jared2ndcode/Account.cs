using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jared2ndcode
{
    class Account
    {
        public decimal total = 1000;
        public decimal number;
       

        public decimal google()
        {
            if ( number > 0 )
            {
                return number;
            }
            else
            {
                throw new ArgumentException("NO negative please");
            }
        }


    
        public void deposit()
        {
           total = total + number;
        }
        public decimal balance()
        {
            return total;
        }
        public void withdraw()
        { 
            if ( total > number)
            {
                total = total - number;
            }
}
    }
}
