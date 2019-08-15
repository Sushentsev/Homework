﻿namespace Task_1
{
    /// <summary>
    /// Interface for manager.
    /// </summary>
    public interface IRobotsManager
    {
        /// <summary>
        /// Is there a sequence in which all the robots will be destroyed.
        /// </summary>
        /// <returns>True — exist, false — otherwise.</returns>
        bool IsSequenceExists();
    }
}
