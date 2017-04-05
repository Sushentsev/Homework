using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_2.Tests
{
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        [ExpectedException(typeof(AddContainedValueException))]
        public void AddExistingValueTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(2);
        }

        [TestMethod]
        public void RemoveFromNotEmptyListTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(2);
            Assert.IsFalse(list.IsContained(2));
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveNotContainedValueException))]
        public void RemoveNotExistingValueTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(4);
        }
    }
}
