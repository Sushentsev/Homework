using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack();
        }

        /// <summary>
        /// Push test with one element.
        /// The stack should not be empty
        /// </summary>
        [TestMethod]
        public void PushOneValueTest()
        {
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Push test with two elements.
        /// The stack should not be empty
        /// </summary>
        [TestMethod]
        public void PushTwoValuesTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Pop test with one element.
        /// Pop() should return last pushed value
        /// </summary>
        [TestMethod]
        public void PopWithOnePushedValueTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
        }

        /// <summary>
        /// Pop test with two elements.
        /// Pop() should return last pushed value
        /// </summary>
        [TestMethod]
        public void PopWithTwoPushedValueTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
        }

        /// <summary>
        /// Pop test with empty stack.
        /// The exception should be thrown
        /// </summary>
        [TestMethod]
        public void EmptyStackPopTest()
        {
            try
            {
                stack.Pop();
                Assert.Fail();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Length test with three elements.
        /// The result should be three
        /// </summary>
        [TestMethod]
        public void TheLengthOfStackWithThreeElementsTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.GetLength());
        }

        private Stack stack;
    }
}
