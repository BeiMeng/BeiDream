using BeiDream.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeiDream.Utils.Tests.Extensions
{
    [TestClass]
    public class NullableExtensionsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime? dt = null;
            var dtt = dt.SafeValue();
            Console.WriteLine(dtt);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int? dt = null;
            var dtt = dt.SafeValue();
            Console.WriteLine(dtt);
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool? dt = null;
            var dtt = dt.SafeValue();
            Console.WriteLine(dtt);
        }
    }
}