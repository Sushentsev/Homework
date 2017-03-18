using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task_2.tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void FibonacciOfNegativeShouldBeZeroTest()
        {
            Assert.AreEqual(0, Program.Fibonacci(-100));
            Assert.AreEqual(0, Program.Fibonacci(-1));
        }

        [TestMethod]
        public void FibonacciOfZeroShouldBeOneTest()
        {
            Assert.AreEqual(1, Program.Fibonacci(0));
        }

        [TestMethod]
        public void FibonacciOfOneShouldBeOneTest()
        {
            Assert.AreEqual(1, Program.Fibonacci(1));
        }

        [TestMethod]
        public void FibonacciOfTwoShouldBeTwoTest()
        {
            Assert.AreEqual(2, Program.Fibonacci(2));
        }

        [TestMethod]
        public void FibonacciOfTenShouldBeEightyNineTest()
        {
            Assert.AreEqual(89, Program.Fibonacci(10));
        }
    }
}
