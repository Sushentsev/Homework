using System;

namespace task_2
{
    public class Program
    {
        /// <summary>
        /// Calculating the n-th Fibonacci number
        /// </summary>
        /// <returns>Fibonacci number</returns>
        public static int Fibonacci(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else
            {
                int previousNumber1 = 1;
                int previousNumber2 = 1;
                int currentNumber = 1;
                for (int i = 2; i <= n; ++i)
                {
                    currentNumber = previousNumber1 + previousNumber2;
                    previousNumber1 = previousNumber2;
                    previousNumber2 = currentNumber;
                }
                return currentNumber;
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Write a number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"The {n}th number is {Fibonacci(n)}");
        }
    }
}
