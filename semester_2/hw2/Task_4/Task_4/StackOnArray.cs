using System;

namespace Task_4
{
    /// <summary>
    /// Stack on array
    /// </summary>
    public class StackOnArray : IStack
    {
        /// <summary>
        /// The max length of stack
        /// </summary>
        private const int length = 100;

        /// <summary>
        /// The index of next added element
        /// </summary>
        private int head;

        /// <summary>
        /// Stack arrau
        /// </summary>
        private int[] arr;

        public StackOnArray() => this.arr = new int[length];

        /// <summary>
        /// Pushing value to stack
        /// </summary>
        /// <param name="value">Value for pushing</param>
        public void Push(int value)
        {
            if (head > length)
            {
                throw new Exception("The stack is full!");
            }
            arr[head] = value;
            ++head;
        }

        /// <summary>
        /// Popping value from stack
        /// </summary>
        /// <returns>Last pushed value</returns>
        public int Pop()
        {
            if (head == 0)
            {
                throw new Exception("The stack is empty!");
            }
            var temp = arr[head - 1];
            --head;
            return temp;
        }

        /// <summary>
        /// Getting value from head
        /// </summary>
        /// <returns>Value from head</returns>
        public int Peek()
        {
            if (head == 0)
            {
                throw new Exception("The stack is empty!");
            }
            return arr[head - 1];
        }

        /// <summary>
        /// Getting length of stack
        /// </summary>
        /// <returns>Length of stack</returns>
        public int GetLength() => head;

        /// <summary>
        /// Checking stack on emptiness
        /// </summary>
        /// <returns>True if stack is empty otherwise false</returns>
        public bool IsEmpty() => head == 0;

    }
}
