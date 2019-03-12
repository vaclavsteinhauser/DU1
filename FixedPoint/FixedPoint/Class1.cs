using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    public abstract class num<T>
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
        public abstract T Add(T a);

    }
    public class Q24_8 : num<Q24_8>
    {
        public Q24_8() : base()
        {
            pred = new byte[3];
            za = new byte[1];
        }
        public override void prirad(int a)
        {
            for (int i = pred.Count() - 1; i >= 0; i--)
            {
                pred[i] = (byte)(a % 256);
                a=a >> 8;
            }
        }
        public override Q24_8 Add(Q24_8 a)
        {
            return new Q24_8();
        }
    }
    public class Fixed<T>
        where T : num<T>, new()
    {
        private T cislo { get; }
        public Fixed(int promenna)
        {
            //Console.WriteLine(T.ToString());
            cislo = new T();
            cislo.prirad(promenna);
        }
        public Fixed(T x)
        {
            cislo = x;
        }
        public override string ToString()
        {
            return cislo.ToString();
        }
        public Fixed<T> Add(Fixed<T> vstup)
        {
            return new Fixed<T>(cislo.Add(vstup.cislo));
        }
    }

}
