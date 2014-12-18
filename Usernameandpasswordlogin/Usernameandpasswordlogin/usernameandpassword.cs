using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usernameandpasswordlogin
{
    class usernameandpassword
    {
        public string username;
        public string password;

        public bool check()
        {
            if (username == "jared")
            {
                if (password == "cowboys")
                {

                    return true;
                }
            }
            return false;
        }
        
        
        
    }
}
