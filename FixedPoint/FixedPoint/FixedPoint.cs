using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuni.Arithmetics.FixedPoint
{
    public abstract class Num<T>
        where T : Num<T>, new()
    {
        static protected int exp;
        //Cislo x reprezentuju jako data=x*2^exp
        protected UInt32 data;
        public override string ToString()
        {
            UInt32 absolutni = data;
            int znamenko = 1;
            if (absolutni >> 31 == 1)
            {
                znamenko = -1;
                absolutni = ~data + 1;
            }
            //Mantisa ma 52 bitu, tekze nedojde ke ztrátě dat
            return ((znamenko*(Double)absolutni)/Math.Pow(2,exp)).ToString();
        }
        public virtual void Prirad(int a)
        {
             data = (UInt32)(a << exp);

        }
        public virtual T Add(T a)
        {
            //a*2^exp+b*2^exp=(a+b)*2^exp
            T novy = new T
            {
                data = a.data + this.data
            };
            return novy;
        }
        public virtual T Subtract(T a)
        {
            //a*2^exp-b*2^exp=(a-b)*2^exp
            T novy = new T();
            UInt64 mezi = (UInt64)((UInt64)this.data - (UInt64)a.data);
            novy.data = (UInt32)mezi;
            return novy;
        }
        public virtual T Multiply(T a)
        {
            //u nasobení nejdřív převedu na kladné číslo a zapamatuju si znaménko, a pokud je soucin zaporny tak na konci prevedu na zaporne
            UInt32 absa = a.data, absthis = this.data;
            int za = 1, zthis = 1;
            if (absa >> 31 == 1)
            {
                za = -1;
                absa = ~absa + 1;
            }
            if (absthis >> 31 == 1)
            {
                zthis = -1;
                absthis = ~absthis + 1;
            }
            T novy = new T();
            UInt64 mezi= (UInt64)((UInt64)absa * (UInt64)absthis) >> exp;
            novy.data = (UInt32)mezi;
            if (za * zthis == -1)
            {
                novy.data = ~(novy.data - 1);
            }
            return novy;
        }
        public virtual T Divide(T a)
        {
            //stejne jako u nasobeni pravuju s absolutníma hodnotama
            UInt32 absa = a.data,absthis=this.data;
            int za = 1,zthis=1;
            if (absa >> 31 == 1)
            {
                za = -1;
                absa = ~absa + 1;
            }
            if (absthis >> 31 == 1)
            {
                zthis = -1;
                absthis = ~absthis + 1;
            }
            T novy = new T();
            UInt64 mezi = (UInt64)absthis << 32;
            novy.data = (UInt32)((mezi / (UInt64)absa)>> (32-exp));
            if(za*zthis==-1)
            {
                novy.data = ~(novy.data - 1);
            }
            return novy;
        }
    }
    public class Q24_8 : Num<Q24_8>
    {
        static Q24_8()
        {
            exp = 8;
        }
    }
    public class Q16_16 : Num<Q16_16>
    {
        static Q16_16()
        {
            exp = 16;
        }
    }
    public class Q8_24 : Num<Q8_24>
    {
        static Q8_24()
        {
            exp = 24;
        }
    }
    public class Fixed<T>
        where T : Num<T>, new()
    {
        private T Cislo { get; }
        public Fixed(int promenna)
        {
            Cislo = new T();
            Cislo.Prirad(promenna);
        }
        public Fixed(T x)
        {
            Cislo = x;
        }
        public override string ToString()
        {
            return Cislo.ToString();
        }
        public Fixed<T> Add(Fixed<T> vstup)
        {
            return new Fixed<T>(Cislo.Add(vstup.Cislo));
        }
        public Fixed<T> Multiply(Fixed<T> vstup)
        {
            return new Fixed<T>(Cislo.Multiply(vstup.Cislo));
        }
        public Fixed<T> Subtract(Fixed<T> vstup)
        {
            return new Fixed<T>(Cislo.Subtract(vstup.Cislo));
        }
        public Fixed<T> Divide(Fixed<T> vstup)
        {
            return new Fixed<T>(Cislo.Divide(vstup.Cislo));
        }
    }

}
