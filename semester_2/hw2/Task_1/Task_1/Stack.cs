using System;

namespace Task_1
{
    /// <summary>
    /// Stack on list
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// The element of stack
        /// </summary>
        private class StackElement
        {
            public StackElement Next { get; private set; }
            public int Value { get; private set; }

            public StackElement(StackElement next, int value)
            {
                this.Next = next;
                this.Value = value;
            }
        }

        /// <summary>
        /// Stack length
        /// </summary>
        private int length;

        /// <summary>
        /// The first element of stack
        /// </summary>
        private StackElement head;

        /// <summary>
        /// Pushing new value to stack
        /// </summary>
        /// <param name="value">Value for pushing</param>
        public void Push(int value)
        {
            var newElement = new StackElement(head, value);
            head = newElement;
            ++length;
        }

        /// <summary>
        /// Removing element from stack
        /// </summary>
        /// <returns>Last pushed value</returns>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            var temp = head.Value;
            head = head.Next;
            --length;
            return temp;
        }

        /// <summary>
        /// Checking stack on emptiness
        /// </summary>
        /// <returns>True if stack is empty otherwise false</returns>
        public bool IsEmpty() => length == 0;

        /// <summary>
        /// Getting the length of stack
        /// </summary>
        /// <returns>Stack length</returns>
        public int GetLength() => length;
    }

}
