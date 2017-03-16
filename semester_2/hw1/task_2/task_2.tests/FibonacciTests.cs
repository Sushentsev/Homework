using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task_2.tests
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void Calculating()
        {
            Assert.AreEqual(0, Program.Fibonacci(-1000));
            Assert.AreEqual(1, Program.Fibonacci(0));
            Assert.AreEqual(1, Program.Fibonacci(1));
            Assert.AreEqual(2, Program.Fibonacci(2));
            Assert.AreEqual(89, Program.Fibonacci(10));
        }

    }
}
