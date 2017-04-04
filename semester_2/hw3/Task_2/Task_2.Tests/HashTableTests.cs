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

        /// <summary>
        /// IsContained test in empty table.
        /// The word should not contained in the table
        /// </summary>
        [TestMethod]
        public void IsContainedInEmptyTableTest()
        {
            Assert.IsFalse(table.IsContained("dfd"));
        }

        /// <summary>
        /// IsContained test in not empty table.
        /// The word should contained in the table
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyTableTest1()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            Assert.IsTrue(table.IsContained("first"));
        }

        /// <summary>
        /// IsContained test in not empty table.
        /// The word should contained in the table
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyTableTest2()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            Assert.IsTrue(table.IsContained("third"));
        }

        /// <summary>
        /// IsContained test in not empty table.
        /// The word should not contained in the table
        /// </summary>
        [TestMethod]
        public void IsContainedInNotEmptyTableTest3()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            Assert.IsFalse(table.IsContained("bored"));
        }

        /// <summary>
        /// Removing from empty table.
        /// The exception should be thrown 
        /// </summary>
        [TestMethod]
        public void RemoveFromEmptyTableTest()
        {
            try
            {
                table.Remove("memchik");
                Assert.Fail();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Removing from table of three elements.
        /// The word should not be contained
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyTableTest1()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            table.Remove("second");
            Assert.IsFalse(table.IsContained("second"));
        }

        /// <summary>
        /// Removing from table of three elements.
        /// The word should be contained
        /// </summary>
        [TestMethod]
        public void RemoveFromNotEmptyTableTest2()
        {
            table.Add("first");
            table.Add("second");
            table.Add("third");
            table.Remove("drink");
            Assert.IsTrue(table.IsContained("second"));
        }
    }
}

