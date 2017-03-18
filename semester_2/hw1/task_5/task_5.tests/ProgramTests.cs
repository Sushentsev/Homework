using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_5.tests
{
    [TestClass]
    public class ProgramTests
    {
        /// <summary>
        /// Rectangular matrix with not sorted first line. 
        /// Test checks sorting of the fisrt line. 
        /// Numbers should be in ascending order.
        /// </summary>
        [TestMethod]
        public void NotSortedMatrixTest1()
        {
            int[,] matrix = { { 5, 4, 6, -8 }, { 3, 2, 4, 1 }, { 7, 6, 8, 5 } };
            Program.MatrixSort(matrix);
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
            {
                Assert.IsTrue(matrix[0, i] <= matrix[0, i + 1]);
            }
        }

        /// <summary>
        /// Rectangular matrix with not sorted first line. 
        /// Test checks the order of numbers in columns (saving columns structure).
        /// Numbers should be in ascending order (special matrix for this test).
        /// </summary>
        [TestMethod]
        public void NotSortedMatrixTest2()
        {
            int[,] matrix = { { 5, 4, 6, -8 }, { 3, 2, 4, 1 }, { 7, 6, 8, 5 } };
            Program.MatrixSort(matrix);
            for (int i = 1; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; ++j)
                {
                    Assert.IsTrue(matrix[i, j] <= matrix[i, j + 1]);
                }
            }
        }

        /// <summary>
        /// Square matrix with sorted first line. 
        /// Matrix should not be changed.
        /// </summary>
        [TestMethod]
        public void SortedMatrixTest()
        {
            int[,] matrix = { { 1, 5, 9 }, { 6, 9, 3 }, { 7, -1, -5 } };
            Program.MatrixSort(matrix);
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
            {
                Assert.IsTrue(matrix[0, i] <= matrix[0, i + 1]);
            }
        }

        /// <summary>
        /// Matrix consists of only one line (matrix-array).
        /// Matrix-array should be sorted.
        /// </summary>
        [TestMethod]
        public void MatrixWithOnlyOneLineTest()
        {
            int[,] matrix = { { 6, -4, 0, 0, 99, 11, 4} };
            Program.MatrixSort(matrix);
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
            {
                Assert.IsTrue(matrix[0, i] <= matrix[0, i + 1]);
            }
        }

        /// <summary>
        /// Matrix consists of only one element.
        /// Matrix should be the same.
        /// </summary>
        [TestMethod]
        public void MatrixOfOneElementTest()
        {
           int[,] matrix = { { 5 } };
           Program.MatrixSort(matrix);
           Assert.AreEqual(5, matrix[0, 0]);
        }
    }
}
