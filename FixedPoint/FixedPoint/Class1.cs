using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    public abstract class num
    {
        protected byte[] pred, za;
        public override string ToString()
        {
            StringBuilder a = new StringBuilder();
            foreach (byte b in pred)
                a.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            a.Append(".");
            foreach (byte b in za)
                a.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            return a.ToString();
        }
        public abstract void prirad(int a);
    }
    public class Q24_8 : num
    {
        public Q24_8() : base()
        {
            pred = new byte[3];
            za = new byte[1];
        }
        public override void prirad(int a)
        {
            //
        }
        
    }
    public class Fixed<T>
        where T : num, new()
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
