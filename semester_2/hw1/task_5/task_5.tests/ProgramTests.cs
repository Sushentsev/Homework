using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task_5.tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void NotSortedMatrix()
        {
            int[,] matrix = { { 3, 5, 4 }, { 2, 1, 1 }, { 9, 8, 7 } };
            Program.MatrixSort(matrix);
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
                Assert.IsTrue(matrix[0, i] <= matrix[0, i + 1]);
        }

        [TestMethod]
        public void SortedMatrix()
        {
            int[,] matrix = { { 1, 2, 2 }, { 2, 1, 1 }, { 2, 8, 7 } };
            Program.MatrixSort(matrix);
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
                Assert.IsTrue(matrix[0, i] <= matrix[0, i + 1]);
        }

        [TestMethod]
        public void MatrixWithTheSameElements()
        {
            int[,] matrix = { { 5, 5, 5 }, { -1, 1, 1 }, { -42, 8, 7 } };
            Program.MatrixSort(matrix);
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
                Assert.IsTrue(matrix[0, i] <= matrix[0, i + 1]);
        }
    }
}
