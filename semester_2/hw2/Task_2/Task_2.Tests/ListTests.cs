using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        /// <summary>
        /// Add test with one element.
        /// The result is the only number in the list
        /// </summary>
        [TestMethod]
        public void AddOneElementToListTest()
        {
            list.Add(1);
            Assert.AreEqual(1, list.Peek());
        }

        /// <summary>
        /// Add test with two elements.
        /// The resut is the value which was added last
        /// </summary>
        [TestMethod]
        public void AddTwoElementsToListTest()
        {
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(2, list.Peek());
        }

        /// <summary>
        /// Empty test on empty list.
        /// The list should be empty
        /// </summary>
        [TestMethod]
        public void EmptyStackTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// Empty test on not empty list.
        /// The list should not be empty
        /// </summary>
        [TestMethod]
        public void ListWithOneElementIsEmptyTest()
        {
            list.Add(1);
            Assert.IsFalse(list.IsEmpty());
        }

        /// <summary>
        /// Length test on empty list.
        /// The length should be zero
        /// </summary>
        [TestMethod]
        public void LengthOfEmptyListTest()
        {
            Assert.AreEqual(0, list.GetLength());
        }

        /// <summary>
        /// Length test on not empty list.
        /// The length should be three
        /// </summary>
        [TestMethod]
        public void LengthOfNotEmptyListTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.GetLength());
        }

        /// <summary>
        /// IsContained test on empty list.
        /// The result should be false
        /// </summary>
        [TestMethod]
        public void IsContainedInEmptyListTest()
        {
            Assert.IsFalse(list.IsContained(0));
        }

        /// <summary>
        /// IsContained test on list with only one element. It is zero.
        /// Zero should be in the list
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest1()
        {
            list.Add(0);
            Assert.IsTrue(list.IsContained(0));
        }

        /// <summary>
        /// IsContained test on list with only one element. It is zero.
        /// One should not be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest2()
        {
            list.Add(0);
            Assert.IsFalse(list.IsContained(1));
        }

        /// <summary>
        /// IsContained test on list with only three element (1, 2, 3);
        /// One should be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest3()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.IsContained(1));
        }

        /// <summary>
        /// IsContained test on list with only three element (1, 2, 3);
        /// Two should be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest4()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.IsContained(2));
        }

        /// <summary>
        /// IsContained test on list with only three element (1, 2, 3);
        /// Three should be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest5()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsTrue(list.IsContained(3));
        }

        /// <summary>
        /// IsContained test on list with only three element (1, 2, 3);
        /// Ten should not be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest6()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.IsFalse(list.IsContained(10));
        }

        /// <summary>
        /// The list is empty
        /// </summary>
        [TestMethod]
        public void RemoveFromEmptyListTest()
        {
            try
            {
                list.RemoveElement(0);
                Assert.Fail();
            }
            catch(Exception) { }
        }

        /// <summary>
        /// The list consists of one element (0).
        /// The list should be empty in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList1()
        {
            list.Add(0);
            list.RemoveElement(0);
            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// The list consists of one element (0).
        /// The list should be the same in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList2()
        {
            list.Add(0);
            list.RemoveElement(1);
            Assert.AreEqual(1, list.GetLength());
        }

        /// <summary>
        /// The list consists of three elements (1, 2, 3).
        /// The list should have the length of two in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList3()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(3);
            Assert.AreEqual(2, list.GetLength());
        }

        /// <summary>
        /// The list consists of three elements (1, 2, 3).
        /// The list should have the length of two in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList4()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(2);
            Assert.AreEqual(2, list.GetLength());
        }

        /// <summary>
        /// The list consists of three elements (1, 2, 3).
        /// The list should be the same in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList5()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(5);
            Assert.AreEqual(3, list.GetLength());
        }

        private List list;
    }
}
