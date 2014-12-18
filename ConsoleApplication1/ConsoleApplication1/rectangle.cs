using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class rectangle
    {
        double length;
        double width;

        public rectangle ( double pLength, double pwidth)
        {
            length = pLength;
            width = pwidth;
        }
        public rectangle()
        {
            length = 100;
            width = 50;
        }
        public double getArea()
        {
            return length * width;
        }

    }

}