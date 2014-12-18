using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            //rectangle myRectangle = new rectangle();
            rectangle myRectangle = new rectangle(500, 1000);

            Console.WriteLine(myRectangle.getArea());

            Console.ReadLine();
        }
    }
}
