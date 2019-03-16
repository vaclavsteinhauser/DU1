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

    [TestClass]
    public class Test24_8
    {
        [TestMethod]
        public void test1()
        {
            var f = new Fixed<Q24_8>(3);
            Assert.AreEqual(f.ToString(), "3");
        }
        [TestMethod]
        public void test2()
        {
            var f1 = new Fixed<Q24_8>(3);
            var f2 = new Fixed<Q24_8>(2);
            var f3 = f1.Add(f2);
            Assert.AreEqual(f3.ToString(), "5");
        }
        [TestMethod]
        public void test3()
        {
            var f1 = new Fixed<Q24_8>(3);
            var f2 = new Fixed<Q24_8>(2);
            var f3 = f1.Multiply(f2);
            Assert.AreEqual(f3.ToString(), "6");
        }
        [TestMethod]
        public void test4()
        {
            var f1 = new Fixed<Q24_8>(19);
            var f2 = new Fixed<Q24_8>(13);
            var f3 = f1.Multiply(f2);
            Assert.AreEqual(f3.ToString(), "247");
        }
        [TestMethod]
        public void test5()
        {
            var f1 = new Fixed<Q24_8>(3);
            var f2 = new Fixed<Q24_8>(2);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "1,5");
        }
        [TestMethod]
        public void test6()
        {
            var f1 = new Fixed<Q24_8>(248);
            var f2 = new Fixed<Q24_8>(10);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "24,796875");
        }
        [TestMethod]
        public void test7()
        {
            var f1 = new Fixed<Q24_8>(625);
            var f2 = new Fixed<Q24_8>(1000);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "0,625");
        }
    }

    [TestClass]
    public class Test16_16
    {
        [TestMethod]
        public void test1()
        {
            var f = new Fixed<Q16_16>(3);
            Assert.AreEqual(f.ToString(), "3");
        }
        [TestMethod]
        public void test2()
        {
            var f1 = new Fixed<Q16_16>(3);
            var f2 = new Fixed<Q16_16>(2);
            var f3 = f1.Add(f2);
            Assert.AreEqual(f3.ToString(), "5");
        }
        [TestMethod]
        public void test3()
        {
            var f1 = new Fixed<Q16_16>(3);
            var f2 = new Fixed<Q16_16>(2);
            var f3 = f1.Multiply(f2);
            Assert.AreEqual(f3.ToString(), "6");
        }
        [TestMethod]
        public void test4()
        {
            var f1 = new Fixed<Q16_16>(19);
            var f2 = new Fixed<Q16_16>(13);
            var f3 = f1.Multiply(f2);
            Assert.AreEqual(f3.ToString(), "247");
        }
        [TestMethod]
        public void test5()
        {
            var f1 = new Fixed<Q16_16>(3);
            var f2 = new Fixed<Q16_16>(2);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "1,5");
        }
        [TestMethod]
        public void test6()
        {
            var f1 = new Fixed<Q16_16>(248);
            var f2 = new Fixed<Q16_16>(10);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "24,7999877929688");
        }
        [TestMethod]
        public void test7()
        {
            var f1 = new Fixed<Q16_16>(625);
            var f2 = new Fixed<Q16_16>(1000);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "0,625");
        }
    }
    [TestClass]
    public class Test8_24
    {
        [TestMethod]
        public void test1()
        {
            var f = new Fixed<Q8_24>(3);
            Assert.AreEqual(f.ToString(), "3");
        }
        [TestMethod]
        public void test2()
        {
            var f1 = new Fixed<Q8_24>(3);
            var f2 = new Fixed<Q8_24>(2);
            var f3 = f1.Add(f2);
            Assert.AreEqual(f3.ToString(), "5");
        }
        [TestMethod]
        public void test3()
        {
            var f1 = new Fixed<Q8_24>(3);
            var f2 = new Fixed<Q8_24>(2);
            var f3 = f1.Multiply(f2);
            Assert.AreEqual(f3.ToString(), "6");
        }
        [TestMethod]
        public void test4()
        {
            var f1 = new Fixed<Q8_24>(19);
            var f2 = new Fixed<Q8_24>(13);
            var f3 = f1.Multiply(f2);
            Assert.AreEqual(f3.ToString(), "-9");
        }
        [TestMethod]
        public void test5()
        {
            var f1 = new Fixed<Q8_24>(3);
            var f2 = new Fixed<Q8_24>(2);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "1,5");
        }
        [TestMethod]
        public void test6()
        {
            var f1 = new Fixed<Q8_24>(248);
            var f2 = new Fixed<Q8_24>(10);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "-0,799999952316284");
        }
        [TestMethod]
        public void test7()
        {
            var f1 = new Fixed<Q8_24>(625);
            var f2 = new Fixed<Q8_24>(1000);
            var f3 = f1.Divide(f2);
            Assert.AreEqual(f3.ToString(), "-4,70833331346512");
        }
    }
}
