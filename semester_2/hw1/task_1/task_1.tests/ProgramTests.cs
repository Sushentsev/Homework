using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task_1.tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, Program.Factorial(1));
            Assert.AreEqual(2, Program.Factorial(2));
            Assert.AreEqual(1, Program.Factorial(0));
            Assert.AreEqual(3628800, Program.Factorial(10));
        }
    }
}
