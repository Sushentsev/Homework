using System;

namespace task_2
{
    class Program
    {
        /// <summary>
        /// Calculating the n-th Fibonacci number
        /// </summary>
        /// <returns>Fibonacci number</returns>
        private static int Fibonacci(int n)
        {
            if (n < 1)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write a number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("The {0}th number is {1}", n, Fibonacci(n));
        }
    }
}
