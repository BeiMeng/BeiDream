using BeiDream.Utils.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeiDream.Utils.Tests.Reflection
{
    [TestClass]
    public class TypeHelperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(TypeHelper.GetType<int>().ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine(TypeHelper.GetType<int?>().ToString());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("33", ConvertHelper.To<string>(33));
            Console.WriteLine(ConvertHelper.To<string>(33));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(33, ConvertHelper.To<int>("33"));
            Console.WriteLine(ConvertHelper.To<int>("33"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(333, ConvertHelper.To<int?>("333"));
            Console.WriteLine(ConvertHelper.To<int?>("333").ToString());
        }
    }
}