using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Tests
{
    [TestClass]
    public class StackTests
    {
        private Stack<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<int>();
        }

        [TestMethod]
        public void LengthStackTest1()
        {
            Assert.AreEqual(0, stack.GetLength());
        }

        [TestMethod]
        public void LengthStackTest2()
        {
            stack.Push(2);
            Assert.AreEqual(1, stack.GetLength());
        }

        [TestMethod]
        public void LengthStackTest3()
        {
            for (var i = 1; i <= 3; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(3, stack.GetLength());
        }

        [TestMethod]
        public void LengthStackTest4()
        {
            for (var i = 1; i <= 5; ++i)
            {
                stack.Push(i);
            }

            for (var i = 1; i <= 3; ++i)
            {
                stack.Pop();
            }

            Assert.AreEqual(2, stack.GetLength());
        }

        [TestMethod]
        public void LengthStackTest5()
        {
            for (var i = 1; i <= 5; ++i)
            {
                stack.Push(i);
            }

            for (var i = 1; i <= 5; ++i)
            {
                stack.Pop();
            }

            Assert.AreEqual(0, stack.GetLength());
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void PopFromEmptyStackTest()
        {
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void PeekFromEmptyStackTest()
        {
            stack.Peek();
        }

        [TestMethod]
        public void PeekFromNotEmptyStackTest()
        {
            for (var i = 10; i >= 1; --i)
            {
                stack.Push(i);
            }

            for (var i = 1; i <= 4; ++i)
            {
                stack.Pop();
            }

            Assert.AreEqual(5, stack.Peek());
        }
    }
}