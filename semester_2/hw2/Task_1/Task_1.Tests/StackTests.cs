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
        /// Push test with one element
        /// </summary>
        [TestMethod]
        public void PushTest1()
        {
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Push test with two elements
        /// </summary>
        [TestMethod]
        public void PushTest2()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Pop test with one element
        /// </summary>
        [TestMethod]
        public void PopTest1()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
        }

        /// <summary>
        /// Pop test with two elements
        /// </summary>
        [TestMethod]
        public void PopTest2()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
        }

        /// <summary>
        /// Pop test with empty stack
        /// </summary>
        [TestMethod]
        public void PopTest3()
        {
            try
            {
                stack.Pop();
            }
            catch(Exception)
            {

            };
        }

        /// <summary>
        /// Pop test with three elements
        /// </summary>
        [TestMethod]
        public void LengthTest1()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.GetLength());
        }

        private Stack stack;
    }
}
