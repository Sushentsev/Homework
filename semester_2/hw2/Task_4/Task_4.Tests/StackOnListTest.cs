using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_4.Tests
{
    [TestClass]
    public class StackOnListTest
    {
        /// <summary>
        /// Initialize stack
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            stack = new StackOnList();
        }

        /// <summary>
        /// Push test with one element.
        /// The stack should not be empty
        /// </summary>
        [TestMethod]
        public void PushOneElementTest()
        {
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Push test with two elements.
        /// The stack should not be empty
        /// </summary>
        [TestMethod]
        public void PushTwoElementsTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Pop test with one element.
        /// Pop() should return last added element
        /// </summary>
        [TestMethod]
        public void PopFromStackWithOneElementTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
        }

        /// <summary>
        /// Pop test with two elements.
        /// Pop() should return last added element
        /// </summary>
        [TestMethod]
        public void PopFromStackWithTwoElementsTest()
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
        public void PopFromEmptyStackTest()
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
        /// Stack length should be three
        /// </summary>
        [TestMethod]
        public void LengthOfStackWithThreeElementsTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.GetLength());
        }

        /// <summary>
        /// Length test with zero elements.
        /// Stack length should be zero
        /// </summary>
        [TestMethod]
        public void LengthOfEmptyStackTest()
        {
            Assert.AreEqual(0, stack.GetLength());
        }

        private StackOnList stack;
    }
}
