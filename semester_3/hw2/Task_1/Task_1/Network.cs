namespace Task_1
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Local network.
    /// </summary>
    public class Network : INetwork
    {
        /// <summary>
        /// Field for generating random values.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Network"/> class.
        /// </summary>
        /// <param name="filepath">Path of file.</param>
        public Network(string filepath) => this.LoadInformationFromFile(filepath);

        /// <summary>
        /// Gets the list of computers.
        /// </summary>
        public IComputer[] Computers { get; private set; }

        /// <summary>
        /// Gets the graph of computers dependencies.
        /// </summary>
        public bool[,] Graph { get; private set; }

        /// <summary>
        /// Getting number of infected computers.
        /// </summary>
        /// <returns>Number of infected computers.</returns>
        public int NumberOfInfectedComputers() => this.Computers.Count(computer => computer.IsInfected);

        /// <summary>
        /// Making move.
        /// </summary>
        public void MakeMove()
        {
            if (this.AreAllNotInfected())
            {
                this.TryToInfectRandomComputer();
                return;
            }

            if (this.AreAllInfected())
            {
                return;
            }

            // New bool array which shows if computer with index i is infected.
            var infectedComputers = new bool[this.Computers.Length];

            for (var i = 0; i < this.Computers.Length; ++i)
            {
                if (this.Computers[i].IsInfected)
                {
                    infectedComputers[i] = true;
                }
            }

            // Trying to infect computers.
            for (var i = 0; i < this.Computers.Length; ++i)
            {
                if (infectedComputers[i])
                {
                    for (var j = 0; j < this.Graph.GetLongLength(0); ++j)
                    {
                        if (this.Graph[i, j])
                        {
                            this.Computers[j].TryToInfect();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Printing information about all computers in the network.
        /// </summary>
        public void PrintInformation()
        {
            for (var i = 0; i < this.Computers.Length; ++i)
            {
                Console.WriteLine($"Computer {i + 1} on {this.Computers[i].OS} infection: {this.Computers[i].IsInfected}");
            }

            Console.WriteLine();
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

                    this.Computers = new IComputer[size];
                    this.Graph = new bool[size, size];
            
                    var text = sr.ReadLine();
                    string[] bits = text.Split(' ');

                    for (var i = 0; i < size; ++i)
                    {
                        this.Computers[i] = new Computer((OS)int.Parse(bits[i]), random);
                    }

                    for (var i = 0; i < size; ++i)
                    {
                        text = sr.ReadLine();
                        bits = text.Split(' ');
                        for (var j = 0; j < size; ++j)
                        {
                            this.Graph[i, j] = Convert.ToBoolean(int.Parse(bits[j]));
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Checking all computers on infecting.
        /// </summary>
        /// <returns>True – all infected, false – otherwise.</returns>
        private bool AreAllInfected() => this.NumberOfInfectedComputers() == this.Computers.Length;

        /// <summary>
        /// Checking all computers on infection.
        /// </summary>
        /// <returns>True – all not infected, false – otherwise.</returns>
        private bool AreAllNotInfected() => this.NumberOfInfectedComputers() == 0;

        /// <summary>
        /// Trying to infect random computer.
        /// </summary>
        private void TryToInfectRandomComputer()
        {
            var index = this.random.Next(0, this.Computers.Length);
            this.Computers[index].TryToInfect();
        }
    }
}
