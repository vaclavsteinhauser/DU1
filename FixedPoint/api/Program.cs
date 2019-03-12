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
            Fixed<Q24_8> t = new Fixed<Q24_8>(512);
            Console.WriteLine(t);
            Console.WriteLine(t.Add(new Fixed<Q24_8>(512)));
        }
    }
}
