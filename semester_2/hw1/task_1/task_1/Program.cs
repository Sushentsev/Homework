using System;

namespace task_1
{
    public class Program
    {
        /// <summary>
        /// Calculating the factorial
        /// </summary>
        /// <returns>The factorial of a number</returns>
        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; ++i)
            {
                result *= i;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write a number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: {0}", Factorial(n));
        }
    }
}
