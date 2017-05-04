using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{
    [TestClass]
    public class ListTests
    {
        private List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AddOneElementToListTest()
        {
            list.Add(1);
            Assert.AreEqual(1, list.Peek());
        }

        [TestMethod]
        public void AddTwoElementsToListTest()
        {
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(2, list.Peek());
        }

        [TestMethod]
        public void EmptyStackTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void ListWithOneElementIsEmptyTest()
        {
            list.Add(1);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void LengthOfEmptyListTest()
        {
            Assert.AreEqual(0, list.GetLength());
        }

        [TestMethod]
        public void LengthOfNotEmptyListTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.GetLength());
        }

        [TestMethod]
        public void IsContainedInEmptyListTest()
        {
            Assert.IsFalse(list.IsContained(0));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest1()
        {
            list.Add(0);
            Assert.IsTrue(list.IsContained(0));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest2()
        {
            list.Add(0);
            Assert.IsFalse(list.IsContained(1));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest3()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.IsContained(1));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest4()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.IsContained(2));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest5()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.IsContained(3));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest6()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsFalse(list.IsContained(10));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveFromEmptyListTest()
        {
            list.RemoveElement(0);
        }

        [TestMethod]
        public void RemoveFromNotEmptyList1()
        {
            list.Add(0);
            list.RemoveElement(0);
            Assert.IsFalse(list.IsContained(0));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveFromNotEmptyList2()
        {
            list.Add(0);
            list.RemoveElement(1);
        }

        [TestMethod]
        public void RemoveFromNotEmptyList3()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(3);
            Assert.IsFalse(list.IsContained(3));
        }

        [TestMethod]
        public void RemoveFromNotEmptyList4()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(2);
            Assert.IsFalse(list.IsContained(2));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveFromNotEmptyList5()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(5);
        }
    }
}
