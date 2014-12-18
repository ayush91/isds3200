using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZhangProject
{
    class NewClass234
    {
        public int converting(int number)
        {
            string convert = number.ToString();
            string another = "";
            int num = 0;


            for (int i = 0; i < convert.Length; i++)
            {
                another = another + i.ToString();
            }
            num = int.Parse(another);
            return num;



        }
       
        


    }
}

