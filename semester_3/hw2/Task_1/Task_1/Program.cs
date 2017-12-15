using Task_1.Classes;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var net = new Network(@"D:\Homework\semester_3\hw2\Task_1\Task_1\test.txt");
            for (var i = 0; i <= 50; ++i)
            {
                net.MakeMove();
                net.PrintInformation();
            }
        }
    }
}
