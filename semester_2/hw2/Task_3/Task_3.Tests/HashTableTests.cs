using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_3.Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestInitialize]
        public void Initialize()
        {
            table = new HashTable(); 
        }

        [TestMethod]
        public void GetHashCodeOfWordsTest()
        {
            Assert.AreEqual(111, table.GetHash("abcde"));
            Assert.AreEqual(84, table.GetHash("abracadabra"));
            Assert.AreEqual(0, table.GetHash(""));
        }

        [TestMethod]
        public void RemovingSomeValuesTest()
        {
            table.Add("abcde");
            table.Add("abracadabra");
            table.Add("346gre");
            table.Remove("abcde");
            table.Remove("abracadabra");
            Assert.IsFalse(table.IsContained("abcde"));
            Assert.IsFalse(table.IsContained("abracadabra"));
            Assert.IsTrue(table.IsContained("346gre"));
        }

        [TestMethod]
        public void IsContainedTest()
        {
            table.Add("abcde");
            table.Add("abracadabra");
            table.Add("");
            Assert.IsTrue(table.IsContained("abcde"));
            Assert.IsTrue(table.IsContained("abracadabra"));
            Assert.IsTrue(table.IsContained(""));
            Assert.IsFalse(table.IsContained("abcd"));
            Assert.IsFalse(table.IsContained("bracadabra"));
            Assert.IsFalse(table.IsContained("ere"));
        }

        private HashTable table;
    }
}
