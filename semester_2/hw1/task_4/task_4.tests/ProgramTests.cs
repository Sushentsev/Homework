using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_4.tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void MatrixSizeOf1()
        {
            int[,] matrix = new int[1, 1];
            matrix[0, 0] = 1;
            int[] spiralArray = new int[1];
            Program.Spiralize(matrix, spiralArray);
            Assert.AreEqual(1, spiralArray[0]);
        }

        [TestMethod]
        public void MatrixSizeOf3()
        {
            int[,] matrix = { { 5, 4, 3 }, { 6, 1, 2 }, { 7, 8, 9 } };
            int[] spiralArray = new int[9];
            Program.Spiralize(matrix, spiralArray);
            for (int i = 0; i < spiralArray.Length; ++i)
            {
                Assert.AreEqual(i + 1, spiralArray[i]);
            }
        }

        [TestMethod]
        public void MatrixSizeOf5()
        {
            int[,] matrix = { { 17, 16, 15, 14, 13 }, { 18, 5, 4, 3, 12 }, { 19, 6, 1, 2, 11 },
            {20, 7, 8, 9, 10 }, {21, 22, 23, 24, 25 } };
            int[] spiralArray = new int[25];
            Program.Spiralize(matrix, spiralArray);
            for (int i = 0; i < spiralArray.Length; ++i)
            {
                Assert.AreEqual(i + 1, spiralArray[i]);
            }
        }
    }
}
