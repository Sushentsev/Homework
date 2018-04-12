namespace Task_1
{
    using System;

    /// <summary>
    /// Computer of local network.
    /// </summary>
    public class Computer : IComputer
    {
        /// <summary>
        /// Generating random number.
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// Probability of infection.
        /// Integer number from [0; 100].
        /// </summary>
        private readonly int probabitityOfInfection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Computer"/> class.
        /// </summary>
        /// <param name="os">Operation system.</param>
        public Computer(OS os, Random random)
        {
            this.OS = os;
            this.random = random;
            this.probabitityOfInfection = this.GetProbabitityOfInfection();
        }

        /// <summary>
        /// Gets a value indicating whether a computer is infected.
        /// </summary>
        public bool IsInfected { get; private set; }

        /// <summary>
        /// Gets an operation system.
        /// </summary>
        public OS OS { get; private set; }

        /// <summary>
        /// Trying to infect a computer.
        /// </summary>
        public void TryToInfect()
        {
            if (this.random.Next(1, 100) <= this.probabitityOfInfection)
            {
                this.IsInfected = true;
            }
        }

        /// <summary>
        /// Getting random probability of infection which depends on file system.
        /// The number represents the vulnerability of the system in percentage.
        /// </summary>
        /// <returns>Probability of infection.</returns>
        private int GetProbabitityOfInfection()
        {
            switch (OS)
            {
                case OS.Windows:
                    return this.random.Next(50, 70);
                case OS.Linux:
                    return this.random.Next(10, 25);
                case OS.MacOs:
                    return this.random.Next(25, 40);
                case OS.Embox:
                    return this.random.Next(0, 10);
                case OS.SafeOS:
                    return 0;
                default:
                    return 100;
            }
        }
    }
}
