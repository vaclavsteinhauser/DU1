using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FixedPoint;

namespace FixedPointMSTests
{
    [TestClass]
    public class TestIO
    {
        static Random num = new Random();
        static int a = Math.Abs(num.Next());
        [TestMethod]
        public void testIO8_24()
        {
            var f = new Fixed<Q8_24>(a);
            string x = f.ToString();

            Double y = 0;
            if ((a & 0x80) == 0X80)
                y = -(double)(~(UInt32)(((UInt32)a << 24) - 1))/ Math.Pow(2, 24);
            else
                y = (double)(a & 0xFF);
            Assert.AreEqual(x, y.ToString());
        }
        [TestMethod]
        public void testIO16_16()
        {
            var f = new Fixed<Q16_16>(a);
            string x = f.ToString();

            Double y = 0;
            if ((a & 0x8000) == 0X8000)
                y = -(double)(~(UInt32)(((UInt32)a << 16) - 1)) / Math.Pow(2, 16);
            else
                y = (double)(a & 0xFFFF);
            Assert.AreEqual(x, y.ToString());
        }
        [TestMethod]
        public void testIO24_8()
        {
            var f = new Fixed<Q24_8>(a);
            string x = f.ToString();

            Double y = 0;
            if ((a & 0x800000) == 0x800000)
                y = -(double)(~(UInt32)(((UInt32)a << 8) - 1)) / Math.Pow(2, 8);
            else
                y = (double)(a & 0xFFFFFF);
            Assert.AreEqual(x, y.ToString());
        }
    }
}
