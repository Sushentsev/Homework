using System;

namespace Task_4
{
    /// <summary>
    /// The interface of stack
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Pushing value to stack
        /// </summary>
        /// <param name="value">Value for pushing</param>
        void Push(int value);

        /// <summary>
        /// Popping value from stack
        /// </summary>
        /// <returns>Last pushed value</returns>
        int Pop();

        /// <summary>
        /// Getting value from head
        /// </summary>
        /// <returns>Value from head</returns>
        int Peek();

        /// <summary>
        /// Getting length of stack
        /// </summary>
        /// <returns>Length of stack</returns>
        int GetLength();

        /// <summary>
        /// Checking stack on emptiness
        /// </summary>
        /// <returns>True if stack is empty otherwise false</returns>
        bool IsEmpty();
    }
}
