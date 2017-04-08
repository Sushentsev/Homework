using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Tests
{
    [TestClass]
    public class FunctionsTests
    {
        private List<int> list;
        private List<int> returningList;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int> { 1, 2, 3 };
        }

        [TestMethod]
        public void MapTest1()
        {
            returningList = Functions.Map(list, x => x * 2);

            for (var i = 0; i <= 2; ++i)
            {
                Assert.AreEqual(list[i] * 2, returningList[i]);
            }
        }

        [TestMethod]
        public void MapTest2()
        {
            returningList = Functions.Map(list, x => x - 2);

            for (var i = 0; i <= 2; ++i)
            {
                Assert.AreEqual(list[i] - 2, returningList[i]);
            }
        }

        [TestMethod]
        public void FilterTest1()
        {
            returningList = Functions.Filter(list, x => (x % 2) == 0);
            Assert.AreEqual(2, returningList[0]);
        }

        [TestMethod]
        public void FilterTest2()
        {
            returningList = Functions.Filter(list, x => x != 2);
            Assert.AreEqual(1, returningList[0]);
            Assert.AreEqual(3, returningList[1]);
        }

        [TestMethod]
        public void FoldTest1()
        {
            var value = Functions.Fold(list, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(6, value);
        }

        [TestMethod]
        public void FoldTest2()
        {
            var value = Functions.Fold(list, 4, (acc, elem) => acc + elem);
            Assert.AreEqual(10, value);
        }
    }
}
