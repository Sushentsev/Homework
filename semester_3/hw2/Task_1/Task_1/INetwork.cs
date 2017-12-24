namespace Task_1
{
    /// <summary>
    /// Network interface.
    /// </summary>
    public interface INetwork
    {
        /// <summary>
        /// Gets the list of computers.
        /// </summary>
        IComputer[] Computers { get; }

        /// <summary>
        /// Gets the graph of computers dependencies.
        /// </summary>
        bool[,] Graph { get; }

        /// <summary>
        /// Making moving.
        /// </summary>
        void MakeMove();

        /// <summary>
        /// Printing some information about local network.
        /// </summary>
        void PrintInformation();

        /// <summary>
        /// Getting number of infected computers.
        /// </summary>
        /// <returns>Number of infected computers.</returns>
        int NumberOfInfectedComputers();
    }
}
