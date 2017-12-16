namespace Task_1.Interfaces
{
    /// <summary>
    /// Interface for maker.
    /// </summary>
    interface IRobotsMaker
    {
        /// <summary>
        /// Is there a sequence in which all the robots will be destroyed.
        /// </summary>
        /// <returns>True — exist, false — otherwise.</returns>
        bool IsSequenceExists();
    }
}
