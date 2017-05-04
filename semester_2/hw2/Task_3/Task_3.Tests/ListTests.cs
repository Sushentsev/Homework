using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_3.Tests
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
            list.Add("mm");
            Assert.AreEqual("mm", list.Peek());
        }

        [TestMethod]
        public void AddTwoElementsToListTest()
        {
            list.Add("mm");
            list.Add("mcm");
            Assert.AreEqual("mcm", list.Peek());
        }

        [TestMethod]
        public void EmptyListTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void ListWithOneElementIsEmptyTest()
        {
            list.Add("mcm");
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
            list.Add("mcm");
            list.Add("mcdam");
            list.Add("madcdam");
            Assert.AreEqual(3, list.GetLength());
        }

        [TestMethod]
        public void IsContainedInEmptyListTest()
        {
            Assert.IsFalse(list.IsContained("madcdam"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest1()
        {
            list.Add("madcdam");
            Assert.IsTrue(list.IsContained("madcdam"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest2()
        {
            list.Add("madcdam");
            Assert.IsFalse(list.IsContained("madsdscdam"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest3()
        {
            list.Add("madcdam");
            list.Add("madaascdam");
            list.Add("vacmadcdam");
            Assert.IsTrue(list.IsContained("madcdam"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest4()
        {
            list.Add("madcdam");
            list.Add("madaascdam");
            list.Add("vacmadcdam");
            Assert.IsTrue(list.IsContained("madaascdam"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest5()
        {
            list.Add("madcdam");
            list.Add("madaascdam");
            list.Add("vacmadcdam");
            Assert.IsTrue(list.IsContained("vacmadcdam"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyListTest6()
        {
            list.Add("madcdam");
            list.Add("madaascdam");
            list.Add("vacmadcdam");
            Assert.IsFalse(list.IsContained("vacmwefweadcdam"));
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void RemoveFromEmptyListTest()
        {
            list.RemoveElement("efe");
        }

        [TestMethod]
        public void RemoveFromNotEmptyList1()
        {
            list.Add("qwerty");
            list.RemoveElement("qwerty");
            Assert.IsFalse(list.IsContained("qwerty"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotContainedValueException))]
        public void RemoveFromNotEmptyList2()
        {
            list.Add("qwerty");
            list.RemoveElement("qwersdty");
        }

        [TestMethod]
        public void RemoveFromNotEmptyList3()
        {
            list.Add("qwert3y");
            list.Add("qwe2rty");
            list.Add("qwerty");
            list.RemoveElement("qwerty");
            Assert.IsFalse(list.IsContained("qwerty"));
        }

        [TestMethod]
        public void RemoveFromNotEmptyList4()
        {
            list.Add("qw234erty");
            list.Add("qwerty");
            list.Add("qwer324ty");
            list.RemoveElement("qwerty");
            Assert.IsFalse(list.IsContained("qwerty"));
        }

        [TestMethod]
        [ExpectedException(typeof(NotContainedValueException))]
        public void RemoveFromNotEmptyList5()
        {
            list.Add("qwerty");
            list.Add("qwrwwerty");
            list.Add("qwwrwwerty");
            list.RemoveElement("qw241erty");
        }
    }
}
