using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    public class Q24_8
    {
        char C;
        public Q24_8() { }
        public void prirad(int a)
        {
            x = (char)(a+97);
        }
        public override string ToString()
        {
            return x.ToString();
        }
    }
    public class Fixed<T>
        where T : Q24_8, new()
    {
        public T cislo;
        public Fixed(int promenna)
        {
            //Console.WriteLine(T.ToString());
            cislo = new T();
            cislo.prirad(promenna);
        }
        public override string ToString()
        {
            return cislo.ToString();
        }
    }

}
