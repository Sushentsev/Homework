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
        public void AddOneValueToCorrectPositionTest()
        {
            list.AddValueByPosition(5, 0);
            Assert.AreEqual(5, list.GetValueByPosition(0));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void AddOneValueToIncorrectPositionTest()
        {
            list.AddValueByPosition(5, 1);
        }

        [TestMethod]
        public void AddTwoValuesToCorrectPositionsTest()
        {
            list.AddValueByPosition(5, 0);
            list.AddValueByPosition(3, 0);
            Assert.AreEqual(3, list.GetValueByPosition(0));
            Assert.AreEqual(5, list.GetValueByPosition(1));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void AddTwoValuesToIncorrectPositionsTest()
        {
            list.AddValueByPosition(5, 0);
            list.AddValueByPosition(5, -1);
        }

        [TestMethod]
        public void AddSomeValuesToCorrectPositionsTest1()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.AddValueByPosition(i, i);
            }

            for (var i = 0; i < 10; ++i)
            {
                Assert.AreEqual(i, list.GetValueByPosition(i));
            }
        }

        [TestMethod]
        public void AddSomeValuesToCorrectPositionsTest2()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.AddValueByPosition(i, 0);
            }

            for (var i = 0; i < 10; ++i)
            {
                Assert.AreEqual(9 - i, list.GetValueByPosition(i));
            }
        }

        [TestMethod]
        public void EmptinessOfEmptyListTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void EmptinessOfNotEmptyListTest()
        {
            list.AddValueByPosition(5, 0);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void GetValueFromEmptyListTest()
        {
            list.GetValueByPosition(0);
        }

        [TestMethod]
        public void GetValueByCorrectPositionFromNotEmptyListTest()
        {
            list.AddValueByPosition(10, 0);
            Assert.AreEqual(10, list.GetValueByPosition(0));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void GetValueByIncorrectPositionFromNotEmptyListTest()
        {
            list.AddValueByPosition(10, 0);
            Assert.AreEqual(10, list.GetValueByPosition(-10));
        }

        [TestMethod]
        public void GetValueByCorrectPositionFromListOfFiveElementsTest()
        {
            list.AddValueByPosition(3, 0);
            list.AddValueByPosition(4, 1);
            list.AddValueByPosition(2, 0);
            list.AddValueByPosition(0, 0);
            list.AddValueByPosition(1, 1);

            for (var i = 0; i < 5; ++i)
            {
                Assert.AreEqual(i, list.GetValueByPosition(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void GetValueByIncorrectPositionFromListOfFiveElementsTest()
        {
            list.AddValueByPosition(3, 0);
            list.AddValueByPosition(4, 1);
            list.AddValueByPosition(2, 0);
            list.AddValueByPosition(0, 0);
            list.AddValueByPosition(1, 1);

            for (var i = 0; i < 8; ++i)
            {
                Assert.AreEqual(i, list.GetValueByPosition(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void ChangeValueInEmptyList()
        {
            list.ChangeValueByPosition(9, 0);
        }

        [TestMethod]
        public void ChangeValueByCorrectPositionInNotEmptyTest()
        {
            list.AddValueByPosition(0, 0);
            list.ChangeValueByPosition(9, 0);
            Assert.AreEqual(9, list.GetValueByPosition(0));
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void ChangeValueByIncorrectPositionInNotEmptyTest()
        {
            list.AddValueByPosition(0, 0);
            list.ChangeValueByPosition(9, -2);
        }

        [TestMethod]
        public void ChangeValuesByCorrectPositionsInListOfSomeElementsTest()
        {
            list.AddValueByPosition(3, 0);
            list.AddValueByPosition(4, 1);
            list.AddValueByPosition(2, 0);
            list.AddValueByPosition(0, 0);
            list.AddValueByPosition(1, 1);

            for (var i = 0; i < 5; ++i)
            {
                list.ChangeValueByPosition(i + 5, i);
                Assert.AreEqual(i + 5, list.GetValueByPosition(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void RemoveFromEmptyListTest()
        {
            list.RemoveElementByPosition(0);
        }

        [TestMethod]
        public void RemoveByCorrectPositionFromNotEmptyListTest()
        {
            list.AddValueByPosition(5, 0);
            list.RemoveElementByPosition(0);
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfIndexException))]
        public void RemoveByIncorrectPositionFromNotEmptyListTest()
        {
            list.AddValueByPosition(5, 0);
            list.RemoveElementByPosition(-1);
        }

        [TestMethod]
        public void RemoveByCorrectPositionFromListOfFiveElementsTest()
        {
            list.AddValueByPosition(0, 0);
            list.AddValueByPosition(1, 1);
            list.AddValueByPosition(2, 2);
            list.AddValueByPosition(3, 3);
            list.AddValueByPosition(4, 4);

            list.RemoveElementByPosition(1);
            list.RemoveElementByPosition(2);

            for (var i = 0; i < 3; ++i)
            {
                Assert.AreEqual(i * 2, list.GetValueByPosition(i));
            }
        }
    }
}
