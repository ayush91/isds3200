using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZhangProject
{
    class Reader
    {
        public int user_id { get; set; }
        public void NewReader()
        {


            try
            {
                StreamReader File1 = new StreamReader("u1.base");
                user_id = File1.Read();
                Console.WriteLine(user_id);

                



            }
            catch
            {
                throw new Exception();

                
            }
        }
    }
}

