using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    public abstract class Num<T>
        where T : Num<T>, new()
    {
        static protected int carka;
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
            /*int poziceprvnijedna;
            for (poziceprvnijedna = 30; absolutni >> poziceprvnijedna == 0 && poziceprvnijedna >= 0; poziceprvnijedna--) ;
            //Console.WriteLine(Convert.ToString(absolutni, 2).PadLeft(32,'0')+" pozice "+poziceprvnijedna.ToString());
            UInt16 exponent = (UInt16)((0x3FF) + (poziceprvnijedna-(32-(8*carka))));
            //Console.WriteLine(Convert.ToString(absolutni, 2).PadLeft(32, '0') + " exponent " + exponent.ToString());
            vystup[7] = (byte)(vystup[7] | (exponent >>4));
            vystup[6] = (byte)((exponent << 4)+(absolutni<<(32-poziceprvnijedna)>>28));
            for(int i = 0;i<3 ;i++)
                vystup[5-i] = (byte)(((absolutni >> (poziceprvnijedna - 12-(8*i))))%256);
            vystup[2] = (byte)(((absolutni >> (poziceprvnijedna - 15))) % 256);/*
            /*for (int i=7;i>=0;i--)
            Console.Write(Convert.ToString(vystup[i], 2).PadLeft(8,'0'));
            Console.WriteLine(" bity "+(data >> (8*(4-carka))).ToString());*/
            //return BitConverter.ToDouble(vystup, 0).ToString();
            return ((znamenko*(Double)absolutni)/Math.Pow(2,(4-carka)*8)).ToString();
        }
        public virtual void Prirad(int a)
        {
            if (a >= 0)
            {
                data = (uint)a << 8 * (4 - carka);
                return;
            }
        }
        public virtual T Add(T a)
        {
            T novy = new T
            {
                data = a.data + this.data
            };
            return novy;
        }
        public virtual T Multiply(T a)
        {
            T novy = new T();
            UInt64 mezi= (UInt64)((UInt64)a.data * (UInt64)this.data) >> (8 * (4 - carka));
            novy.data = (UInt32)mezi;
            return novy;
        }
        public virtual T Subtract(T a)
        {
            T novy = new T();
            UInt64 mezi = (UInt64)((UInt64)this.data - (UInt64)a.data);
            novy.data = (UInt32)mezi;
            return novy;
        }
        public virtual T Divide(T a)
        {
            T novy = new T();
            UInt64 mezi = (UInt64)this.data << 32;
            novy.data = (UInt32)((mezi / (UInt64)a.data)>> (8 * (carka)));
            Console.WriteLine(Convert.ToString(novy.data,2).PadLeft(32,'0'));
            return novy;
        }
    }
    public class Q24_8 : Num<Q24_8>
    {
        static Q24_8()
        {
            carka = 3;
        }
    }
    public class Q16_16 : Num<Q16_16>
    {
        static Q16_16()
        {
            carka = 2;
        }
    }
    public class Q8_24 : Num<Q8_24>
    {
        static Q8_24()
        {
            carka = 1;
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
