using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    private class Q24_8
    {

        public
    }
    public class Fixed<T>
    {

        T cislo;
        public Fixed(T promenna)
        {
            //Console.WriteLine(T.ToString());
            cislo = promenna;
        }
        public void Write()
        {
            Console.WriteLine(cislo);
        }
        public override string ToString()
        {
            return cislo.ToString();
        }
    }

}
