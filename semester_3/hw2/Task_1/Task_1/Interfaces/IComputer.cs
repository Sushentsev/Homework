using Task_1.Classes;

namespace Task_1.Interfaces
{
    /// <summary>
    /// Computer interface.
    /// </summary>
    public interface IComputer
    {
        /// <summary>
        /// Computer infecting.
        /// </summary>
        bool IsInfected { get; }

        /// <summary>
        /// Computer operation system.
        /// </summary>
        OS oS { get; }

        /// <summary>
        /// Trying to infect a computer.
        /// </summary>
        void TryToInfect();
    }
}
