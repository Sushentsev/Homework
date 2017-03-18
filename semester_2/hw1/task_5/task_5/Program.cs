using System;

namespace Task_5
{
    public class Program
    {
        /// <summary>
        /// Sorting matrix by the first columns elements
        /// </summary>
        /// <param name="matrix">not sorted matrix</param>
        public static void MatrixSort(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
            {
                for (int j = 0; j <  matrix.GetLength(1) - i - 1; ++j)
                {
                    if (matrix[0, j] > matrix[0, j + 1])
                    {
                        SwapColumn(matrix, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Swaping two columns elements
        /// </summary>
        /// <param name="column1">column index 1</param>
        /// <param name="column2">column index 2</param>
        private static void SwapColumn(int[,] matrix, int column1, int column2)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int temp = matrix[i, column1];
                matrix[i, column1] = matrix[i, column2];
                matrix[i, column2] = temp;
            }
        }

        /// <summary>
        /// Filing matrix by random elements from 1 to 10
        /// </summary>
        private static void InputMatrix(int[,] matrix)
        {
            Random ran = new Random();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = ran.Next(1, 11);
                }
            }
        }

        /// <summary>
        /// Printing the matrix
        /// </summary>
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix size:");
            int l = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int[,] matrix = new int[l, c];
            InputMatrix(matrix);
            Console.WriteLine("Initial matrix:");
            PrintMatrix(matrix);
            Console.WriteLine("Sorted matrix by columns first elements:");
            MatrixSort(matrix);
            PrintMatrix(matrix);
        }
    }
}
