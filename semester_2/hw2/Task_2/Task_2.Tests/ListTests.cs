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
        public void AddElementsToCorrectPosition()
        {
            list.AddValueByPosition(1, 0);
            list.AddValueByPosition(2, 1);
            list.AddValueByPosition()
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveFromNotEmptyList5()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveElement(5);
        }
    }
}
