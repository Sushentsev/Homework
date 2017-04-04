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
            list.Add("ololo");
            Assert.AreEqual("ololo", list.Peek());
        }

        /// <summary>
        /// Add test with two elements.
        /// The resut is the value which was added last
        /// </summary>
        [TestMethod]
        public void AddTwoElementsToListTest()
        {
            list.Add("ololo");
            list.Add("azaza");
            Assert.AreEqual("azaza", list.Peek());
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
            list.Add("lalka");
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
            list.Add("azaza");
            list.Add("ololo");
            list.Add("lalka");
            Assert.AreEqual(3, list.GetLength());
        }

        /// <summary>
        /// IsContained test on empty list.
        /// The result should be false
        /// </summary>
        [TestMethod]
        public void IsContainedInEmptyListTest()
        {
            Assert.IsFalse(list.IsContained("lol"));
        }

        /// <summary>
        /// IsContained test on list with only one element. 
        /// Word should be in the list
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest1()
        {
            list.Add("cockroach");
            Assert.IsTrue(list.IsContained("cockroach"));
        }

        /// <summary>
        /// IsContained test on list with only one element. 
        /// Word should not be in the list
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest2()
        {
            list.Add("cockroach");
            Assert.IsFalse(list.IsContained("tiger"));
        }

        /// <summary>
        /// IsContained test on list with only three elements.
        /// "Sister" should be in the list
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest3()
        {
            list.Add("mother");
            list.Add("father");
            list.Add("sister");
            Assert.IsTrue(list.IsContained("sister"));
        }

        /// <summary>
        /// IsContained test on list with only three element.
        /// "Father" should be in the list
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest4()
        {
            list.Add("mother");
            list.Add("father");
            list.Add("sister");
            Assert.IsTrue(list.IsContained("father"));
        }

        /// <summary>
        /// IsContained test on list with only three element.
        /// "Mother" should be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest5()
        {
            list.Add("mother");
            list.Add("father");
            list.Add("sister");
            Assert.IsTrue(list.IsContained("mother"));
        }

        /// <summary>
        /// IsContained test on list with only three element.
        /// "Brother" should not be in the list.
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyListTest6()
        {
            list.Add("mother");
            list.Add("father");
            list.Add("sister");
            Assert.IsFalse(list.IsContained("brother"));
        }

        /// <summary>
        /// The list is empty
        /// </summary>
        [TestMethod]
        public void RemoveFromEmptyListTest()
        {
            try
            {
                list.RemoveElement("task");
                Assert.Fail();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// The list consists of one element.
        /// The list should be empty in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList1()
        {
            list.Add("brother");
            list.RemoveElement("brother");
            Assert.IsTrue(list.IsEmpty());
        }

        /// <summary>
        /// The list consists of one element.
        /// The list should be the same in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList2()
        {
            list.Add("brother");
            list.RemoveElement("sister");
            Assert.AreEqual(1, list.GetLength());
        }

        /// <summary>
        /// The list consists of three elements.
        /// The list should have the length of two in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList3()
        {
            list.Add("hindu");
            list.Add("german");
            list.Add("frenchman");
            list.RemoveElement("hindu");
            Assert.AreEqual(2, list.GetLength());
        }

        /// <summary>
        /// The list consists of three elements.
        /// The list should have the length of two in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList4()
        {
            list.Add("hindu");
            list.Add("german");
            list.Add("frenchman");
            list.RemoveElement("german");
            Assert.AreEqual(2, list.GetLength());
        }

        /// <summary>
        /// The list consists of three elements (1, 2, 3).
        /// The list should be the same in the end
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyList5()
        {
            list.Add("hindu");
            list.Add("german");
            list.Add("frenchman");
            list.RemoveElement("russian");
            Assert.AreEqual(3, list.GetLength());
        }

        /// <summary>
        /// Peek in empty list.
        /// The exception should be thrown
        /// </summary>
        [TestMethod]
        public void PeekInEmptyList()
        {
            try
            {
                list.Peek();
                Assert.Fail();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Peek in list of one element.
        /// The element should be returned
        /// </summary>
        [TestMethod]
        public void PeekInListOfOneElement()
        {
            list.Add("brrr");
            Assert.AreEqual("brrr", list.Peek());
            Assert.AreEqual(1, list.GetLength());
        }

        /// <summary>
        /// Peek in list of two elements.
        /// The last added element should be returned
        /// </summary>
        [TestMethod]
        public void PeekInListOfTwoElements()
        {
            list.Add("brrr");
            list.Add("mrrr");
            Assert.AreEqual("mrrr", list.Peek());
            Assert.AreEqual(2, list.GetLength());
        }

        private List list;
    }
}

