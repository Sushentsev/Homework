using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> id1 = new List<int>();
            id1.Add(0);
            id1.Add(2);
            List<int> id2 = new List<int>();
            id2.Add(3);
            id2.Add(5);
            IEnumerable<int> id3 = id1.Intersect(id2);
            Console.WriteLine($"length {id3.Count()}");
        }
    }
}
