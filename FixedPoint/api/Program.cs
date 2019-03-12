using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedPoint;

namespace api
{
    class Program
    {
        static void Main(string[] args)
        {
            Fixed<int> t = new Fixed<int>(4);
            t.Write();
            Console.WriteLine(t);
        }
    }
}
