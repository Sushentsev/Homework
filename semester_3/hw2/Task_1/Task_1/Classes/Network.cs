using System;
using System.IO;
using System.Linq;
using Task_1.Interfaces;

namespace Task_1.Classes
{
    /// <summary>
    /// Local network.
    /// </summary>
    public class Network : INetwork
    {
        /// <summary>
        /// List of computers.
        /// </summary>
        public IComputer[] Computers { get; set; }

        /// <summary>
        /// Graph of computers dependencies.
        /// </summary>
        public bool[,] graph { get; }

        /// <summary>
        /// Field for generating random values.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Getting number of infected computers.
        /// </summary>
        /// <returns>Number of infected computers.</returns>
        public int NumberOfInfectedComputers() => Computers.Count(computer => computer.IsInfected);

        /// <summary>
        /// Checking all computers on infecting.
        /// </summary>
        /// <returns>True – all infected, false – otherwise.</returns>
        private bool AreAllInfected() => NumberOfInfectedComputers() == Computers.Length;

        /// <summary>
        /// Checking all computers on infection.
        /// </summary>
        /// <returns>True – all not infected, false – otherwise.</returns>
        private bool AreAllNotInfected() => NumberOfInfectedComputers() == 0;

        /// <summary>
        /// Constructor for network.
        /// </summary>
        /// <param name="filepath">Path of file.</param>
        public Network(string filepath) => LoadInformationFromFile(filepath);

        /// <summary>
        /// Infecting random computers.
        /// </summary>
        private void InfectRandomComputer()
        {
            var index = random.Next(0, Computers.Length);
            Computers[index].IsInfected = true;
        }

        /// <summary>
        /// Loading some information from file: number of computers, OS, dependencies.
        /// </summary>
        /// <param name="filepath">Path of file.</param>
        private void LoadInformationFromFile(string filepath)
        {
            try
            {   
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(filepath))
                {
                    int size = int.Parse(sr.ReadLine());
                        
                    computers = new IComputer[size];
                    graph = new Boolean[size, size];

                    var text = sr.ReadLine();
                    string[] bits = text.Split(' ');
                    for (var i = 0; i < size; ++i)
                    {
                        Computers[i] = new Computer((OS)int.Parse(bits[i]));
                    }

                    for (var i = 0; i < size; ++i)
                    {
                        text = sr.ReadLine();
                        bits = text.Split(' ');
                        for (var j = 0; j < size; ++j)
                        {
                            graph[i, j] = int.Parse(bits[j]) == 1  ? true : false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Making move.
        /// </summary>
        public void MakeMove()
        {
            if (AreAllNotInfected())
            {
                InfectRandomComputer();
                return;
            }

            if (AreAllInfected())
            {
                return;
            }

            // New bool array which shows if computer with index i is infected.
            var infectedComputers = new Boolean[Computers.Length];

            for (var i = 0; i < Computers.Length; ++i)
            {
                if (Computers[i].IsInfected)
                {
                    infectedComputers[i] = true;
                }
            }

            // Trying to infect computers.
            for (var i = 0; i < Computers.Length; ++i)
            {
                if (infectedComputers[i])
                {
                    for (var j = 0; j < graph.GetLongLength(0); ++j)
                    {
                        if (graph[i,j])
                        {
                            Computers[j].TryToInfect();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Printing information to console about all computers.
        /// </summary>
        public void PrintInformation()
        {
            for (var i = 0; i < Computers.Length; ++i)
            {
                Console.WriteLine($"Computer {i + 1} on {Computers[i].oS} infection: {Computers[i].IsInfected}");
            }

            Console.WriteLine();
        }
    }
}
