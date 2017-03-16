using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task_3.tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void NotSortedArray()
        {
            int[] array = { 5, 3, 2, 1, 10, 11, 9, 3, 0, -5 };
            Program.BubbleSort(array);
            for (int i = 0; i < array.Length - 1; ++i)
            {
                Assert.IsTrue(array[i] <= array[i + 1]);
            }
        }

        [TestMethod]
        public void SortedArray()
        {
            int[] array = { -1, 2, 2, 3, 4, 5, 6, 6, 8, 15, 16, 32, 1424 };
            Program.BubbleSort(array);
            for (int i = 0; i < array.Length - 1; ++i)
            {
                Assert.IsTrue(array[i] <= array[i + 1]);
            }
        }

        [TestMethod]
        public void ArrayWithTheSameELements()
        {
            int[] array = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Program.BubbleSort(array);
            for (int i = 0; i < array.Length - 1; ++i)
            {
                Assert.IsTrue(array[i] <= array[i + 1]);
            }
        }
    }
}
