using System;

namespace task_3
{
    public class Program
    {
        /// <summary>
        /// Bubble sorting
        /// </summary>
        /// <returns>sorted array</returns>
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
        }

        /// <summary>
        /// Printing array
        /// </summary>
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                Console.Write("{0} ", array[i]);
            Console.WriteLine();
        }

        /// <summary>
        /// Filling an array by random numbers from 1 to 10
        /// </summary>
        private static void InputArray(int[] array)
        {
            Random ran = new Random();
            for (int i = 0; i < array.Length; ++i)
                array[i] = ran.Next(1, 11);
        }

        static void Main(string[] args)
        {
            const int length = 10;
            int[] array = new int[length];

            InputArray(array);
            Console.WriteLine("Initial array:");
            PrintArray(array);
            Console.WriteLine("Sorted array:");
            BubbleSort(array);
            PrintArray(array);
        }
    }
}
