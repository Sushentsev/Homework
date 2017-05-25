using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{
    [TestClass]
    public class SetTests
    {
        private Set<int> resultSet;
        private Set<int> set1;
        private Set<int> set2;

        [TestInitialize]
        public void Initialize()
        {
            resultSet = new Set<int>();
            set1 = new Set<int>();
            set2 = new Set<int>();
        }

        [TestMethod]
        public void AddSomeValuesTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                resultSet.Add(i);
            }

            Assert.AreEqual(10, resultSet.GetSize());
        }

        [TestMethod]
        public void IsBelongInEmptySetTest()
        {
            Assert.IsFalse(resultSet.IsBelong(0));
        }

        [TestMethod]
        public void IsBelongInSetOfOneElementTest()
        {
            resultSet.Add(1);
            Assert.IsTrue(resultSet.IsBelong(1));
        }

        [TestMethod]
        public void IsBelongInSetOfSomeElementsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                resultSet.Add(i);
            }

            for (var i = 1; i <= 10; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveNotContainedValueException))]
        public void RemoveFromEmptySetTest()
        {
            resultSet.Remove(0);
        }

        [TestMethod]
        public void RemoveCorrectValueFromSetOfOneElementTest()
        {
            resultSet.Add(1);
            resultSet.Remove(1);
            Assert.AreEqual(0, resultSet.GetSize());
            Assert.IsFalse(resultSet.IsBelong(1));
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveNotContainedValueException))]
        public void RemoveIncorrectValueFromSetOfOneElementTest()
        {
            resultSet.Add(1);
            resultSet.Remove(2);
        }

        [TestMethod]
        public void RemoveSomeValuesFromSetTest()
        {
            for (var i = 1; i <= 20; ++i)
            {
                resultSet.Add(i);
            }

            for (var i = 1; i <= 20; ++i)
            {
                if (i % 2 == 0)
                {
                    resultSet.Remove(i);
                }
            }

            for (var i = 1; i <= 20; ++i)
            {
                if (i % 2 == 0)
                {
                    Assert.IsFalse(resultSet.IsBelong(i));
                }
            }

            Assert.AreEqual(10, resultSet.GetSize());
        }

        [TestMethod]
        public void UnionOfEmptySetsTest()
        {
            resultSet = Set<int>.SetOperations.Union(set1, set2);
            Assert.AreEqual(0, resultSet.GetSize());
        }

        [TestMethod]
        public void UnionOfEmptyAndNotEmptySetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
            }

            resultSet = Set<int>.SetOperations.Union(set1, set2);

            for (var i = 1; i <= 10; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }

            Assert.AreEqual(10, resultSet.GetSize());
        }

        [TestMethod]
        public void UnionOfNotIntersectingSetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
                set2.Add(i + 10);
            }

            resultSet = Set<int>.SetOperations.Union(set1, set2);

            for (var i = 1; i <= 20; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }

            Assert.AreEqual(20, resultSet.GetSize());
        }

        [TestMethod]
        public void UnionOfIntersectingSetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
                set2.Add(i + 5);
            }

            resultSet = Set<int>.SetOperations.Union(set1, set2);

            for (var i = 1; i <= 15; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }

            Assert.AreEqual(15, resultSet.GetSize());
        }

        [TestMethod]
        public void UnionOfEqualSetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
                set2.Add(i);
            }

            resultSet = Set<int>.SetOperations.Union(set1, set2);

            for (var i = 1; i <= 10; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }

            Assert.AreEqual(10, resultSet.GetSize());
        }

        [TestMethod]
        public void IntersectionOfEmptySetsTest()
        {
            resultSet = Set<int>.SetOperations.Intersection(set1, set2);
            Assert.AreEqual(0, resultSet.GetSize());
        }

        [TestMethod]
        public void IntersectionOfEmptyAndNotEmptySetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
            }

            resultSet = Set<int>.SetOperations.Intersection(set1, set2);
            Assert.AreEqual(0, resultSet.GetSize());
        }

        [TestMethod]
        public void IntersectionOfNotIntersectingSetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
                set2.Add(i + 10);
            }

            resultSet = Set<int>.SetOperations.Intersection(set1, set2);
            Assert.AreEqual(0, resultSet.GetSize());
        }

        [TestMethod]
        public void IntersectionOfIntersectingSetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
                set2.Add(i + 5);
            }

            resultSet = Set<int>.SetOperations.Intersection(set1, set2);

            for (var i = 6; i <= 10; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }

            Assert.AreEqual(5, resultSet.GetSize());
        }

        [TestMethod]
        public void InterSectionOfEqualSetsTest()
        {
            for (var i = 1; i <= 10; ++i)
            {
                set1.Add(i);
                set2.Add(i);
            }

            resultSet = Set<int>.SetOperations.Intersection(set1, set2);

            for (var i = 1; i <= 10; ++i)
            {
                Assert.IsTrue(resultSet.IsBelong(i));
            }

            Assert.AreEqual(10, resultSet.GetSize());
        }
    }
}
