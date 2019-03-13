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
            var a = new Fixed<Q8_24>(255);
            var b = new Fixed<Q8_24>(255);
            var c = a.Add(b);
            Console.WriteLine(c);
            Console.Read();
        }
    }
}
