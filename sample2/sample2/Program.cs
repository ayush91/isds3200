using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample2
{
    class Program
    {

        public void getValue( out int x)
        {
            int temp = 5;
                x = temp;
        }
        static void Main(string[] args)
        {
            int a = 100;
            Console.WriteLine("Before method call. value is a: {0}", a);

            Program thisprogram = new Program();
            thisprogram.getValue(out a);

            Console.WriteLine("Before method call. value is a: {0}", a);

            Console.ReadLine();
        }
    }
}
