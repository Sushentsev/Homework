using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{
    [TestClass]
    public class HashTableTests
    {
        private HashTable table;

        [TestInitialize]
        public void Initialize()
        {
            table = new HashTable(new HashFunction1());
        }

        [TestMethod]
        public void IsContainedInEmptyTableTest()
        {
            Assert.IsFalse(table.IsContained("dfd"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyTableTest1()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            Assert.IsTrue(table.IsContained("first"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyTableTest2()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            Assert.IsTrue(table.IsContained("third"));
        }

        [TestMethod]
        public void IsContainedInNotEmptyTableTest3()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            Assert.IsFalse(table.IsContained("bored"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveFromEmptyTableTest()
        {
            table.Remove("memchik");
        }

        [TestMethod]
        public void RemoveFromNotEmptyTableTest1()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            table.Remove("second");
            Assert.IsFalse(table.IsContained("second"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveFromNotEmptyTableTest2()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            table.Remove("drink");
        }
    }
}

