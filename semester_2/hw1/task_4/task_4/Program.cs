using System;

namespace Task_4
{
    public class Program
    {
        /// <summary>
        /// Spiral bypass
        /// </summary>
        /// <param name="matrix">Matrix for spiralizing</param>
        /// <param name="spiralArray">Spiral array for printing</param>
        public static void Spiralize(int[,] matrix, int[] spiralArray)
        {
            int spiralArrayIndex = 0;
            int currentSize = 1;
            int matrixSize = matrix.GetLength(0);
            int centraIndex = matrix.GetLength(0) / 2;
            int leftIndex = centraIndex;
            int rightIndex = leftIndex + 1;
            int bottomIndex = centraIndex;
            int topIndex = bottomIndex - 1;

            while (currentSize < matrixSize)
            {
                for (int i = leftIndex; i <= rightIndex; ++i)
                {
                    spiralArray[spiralArrayIndex] = matrix[bottomIndex, i];
                    ++spiralArrayIndex;
                }
                --leftIndex;
                --spiralArrayIndex;
                ++currentSize;

                for (int i = bottomIndex; i >= topIndex; --i)
                {
                    spiralArray[spiralArrayIndex] = matrix[i, rightIndex];
                    ++spiralArrayIndex;
                }
                --spiralArrayIndex;
                ++bottomIndex;

                for (int i = rightIndex; i >= leftIndex; --i)
                {
                    spiralArray[spiralArrayIndex] = matrix[topIndex, i];
                    ++spiralArrayIndex;
                }
                --spiralArrayIndex;
                ++rightIndex;
                ++currentSize;

                for (int i = topIndex; i <= bottomIndex; ++i)
                {
                    spiralArray[spiralArrayIndex] = matrix[i, leftIndex];
                    ++spiralArrayIndex;
                }
                --spiralArrayIndex;
                --topIndex;
            }

            for (int i = leftIndex; i < rightIndex; ++i)
            {
                spiralArray[spiralArrayIndex] = matrix[bottomIndex, i];
                ++spiralArrayIndex;
            }
        }

        /// <summary>
        /// Filling matrix by numbers from 1 to 9
        /// </summary>
        /// <param name="matrix">Matrix for filling</param>
        private static void InputMatrix(int[,] matrix)
        {
            Random ran = new Random();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = ran.Next(1, 10);
                }
            }
        }

        /// <summary>
        /// Printing spiral array
        /// </summary>
        /// <param name="spiralArray">Spiral array for printing</param>
        private static void PrintSpiralArray(int[] spiralArray)
        {
            for (int i = 0; i < spiralArray.Length; ++i)
            {
                Console.Write($"{spiralArray[i]} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Printing matrix
        /// </summary>
        /// <param name="matrix">Matrix for printing</param>
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

        static void Main(string[] args)
        {
            Console.WriteLine("Write matrix size (only odd numbers):");
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int[] spiralArray = new int[size * size];
            InputMatrix(matrix);
            Console.WriteLine("Initial matrix:");
            PrintMatrix(matrix);
            Spiralize(matrix, spiralArray);
            Console.WriteLine("Spiral array:");
            PrintSpiralArray(spiralArray);
        }
    }
}
