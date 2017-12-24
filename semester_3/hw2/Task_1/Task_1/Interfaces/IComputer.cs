namespace Task_1.Interfaces
{
    using Task_1.Classes;

    /// <summary>
    /// Computer interface.
    /// </summary>
    public interface IComputer
    {
        /// <summary>
        /// Gets a value indicating whether a computer is infected.
        /// </summary>
        bool IsInfected { get; }

        /// <summary>
        /// Gets a computer operation system.
        /// </summary>
        OS OS { get; }

        /// <summary>
        /// Trying to infect a computer.
        /// </summary>
        void TryToInfect();
    }
}
