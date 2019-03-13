using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    public abstract class num<T>
        where T : num<T>, new()
    {
        protected int carka;
        protected byte[] data=new byte[4];
        public override string ToString()
        {
            StringBuilder a = new StringBuilder();
            double x = 0;
            if (data[0] / 128 == 1) // pokud je zaporne
            {
                a.Append("-");
                for(int i=0;i<3;i++)
                x += (256-data[i]) * Math.Pow(256, carka - i - 1);
                x += (257-data[3]) * Math.Pow(256, carka - 4);
            }
            else
            for (int i = 0; i < data.Count(); i++)
            {
                x += data[i] * Math.Pow(256, carka - i - 1);
                //x += b;
            }
            /*for(int i = 0; i < data.Count(); i++)
            {
                if(i==carka)
                    a.Append(".");
                a.Append(Convert.ToString(data[i], 2).PadLeft(8, '0'));
            }
            a.Append("\n");*/

            for (int i = 0;i < data.Count();i++)
            {
                x += data[i]*Math.Pow(256,carka-i-1);
                //x += b;
            }
            a.Append(x);
            return a.ToString();
        }
        public virtual void prirad(int a)
        {
            for (int i = carka - 1; i >= 0; i--)
            {
                data[i] = (byte)(a % 256);
                a = a >> 8;
            }
        }
        public virtual T Add(T a)
        {
            T novy = new T();
            byte preteceni = 0;
            for(int i = data.Count() - 1; i >= 0; i--)
            {
                novy.data[i] = (byte)(a.data[i] + this.data[i] + preteceni);// % 256;
                preteceni = (byte)((a.data[i] + this.data[i] + preteceni) / 256);
            }
            return novy;
        }


    }
    public class Q24_8 : num<Q24_8>
    {
        public Q24_8() : base()
        {
            carka = 3;
        }
    }
    public class Q16_16 : num<Q16_16>
    {
        public Q16_16() : base()
        {
            carka = 2;
        }
    }
    public class Q8_24 : num<Q8_24>
    {
        public Q8_24() : base()
        {
            carka = 1;
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
        /*public Fixed<T> Subtract(Fixed<T> vstup)
        {
            return new Fixed<T>(cislo.Subtract(vstup.cislo));
        }*/
    }

}
