using System;
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
        private IComputer[] computers;

        /// <summary>
        /// Graph of computers dependencies.
        /// </summary>
        private int[,] graph;

        /// <summary>
        /// Field for generating random values.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Checking all computers on infecting.
        /// </summary>
        /// <returns>True – all infected, false – otherwise.</returns>
        public bool AreAllInfected() => computers.Count(computer => computer.IsInfected) == computers.Length;

        /// <summary>
        /// Checking all computers on infection.
        /// </summary>
        /// <returns>True – all not infected, false – otherwise.</returns>
        public bool AreAllNotInfected() => computers.Count(computer => !computer.IsInfected) == computers.Length;

        public Network(string filename)
        {
            LoadInformationFromFile(filename);
        }

        /// <summary>
        /// Infecting random computers.
        /// </summary>
        private void InfectRandomComputer()
        {
            var index = random.Next(0, computers.Length);
            computers[index].IsInfected = true;
        }

        /// <summary>
        /// Loading some information from file: number of computers, OS, dependencies.
        /// </summary>
        /// <param name="filename">Name of file</param>
        private void LoadInformationFromFile(string filename)
        {

        }

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

            var infectedComputers = new Boolean[computers.Length];

            for (var i = 0; i < computers.Length; ++i)
            {
                if (computers[i].IsInfected)
                {
                    infectedComputers[i] = true;
                }
            }

            for (var i = 0; i < computers.Length; ++i)
            {
                if (infectedComputers[i])
                {
                    for (var j = 0; j < graph.GetLongLength(0); ++j)
                    {
                        if (graph[i,j].Equals(1))
                        {
                            computers[j].TryToInfect();
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
            for (var i = 0; i < computers.Length; ++i)
            {
                Console.WriteLine($"Computer {i + 1} on {computers[i].oS} infection: {computers[i].IsInfected}");
            }
        }
    }
}
