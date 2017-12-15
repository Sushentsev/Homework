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
        /// Checking all computers on infection.
        /// </summary>
        /// <returns>True — all infected, false — otherwise.</returns>
        bool AreAllInfected();

        /// <summary>
        /// Checking all computers on infection.
        /// </summary>
        /// <returns>True - all not infected, false - otherwise.</returns>
        bool AreAllNotInfected();
    }
}
