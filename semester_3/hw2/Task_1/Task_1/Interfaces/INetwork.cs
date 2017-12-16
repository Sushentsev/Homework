namespace Task_1.Interfaces
{
    /// <summary>
    /// Network interface.
    /// </summary>
    interface INetwork
    {
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
