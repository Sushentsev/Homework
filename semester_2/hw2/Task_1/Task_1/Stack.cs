using System;

namespace Task_1
{
    public class Stack
    {
        /// <summary>
        /// The element of stack
        /// </summary>
        private class StackElement
        {
            public StackElement Next;
            public int Value;

            public StackElement(StackElement next, int value)
            {
                Next = next;
                Value = value;
            }
        }

        /// <summary>
        /// Stack length
        /// </summary>
        private int length;

        /// <summary>
        /// The first element of stack
        /// </summary>
        private StackElement head = null;

        /// <summary>
        /// Pushing new value to stack
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value)
        {
            var newElement = new StackElement(head, value);
            head = newElement;
            ++length;
        }

        /// <summary>
        /// Removing element from stack
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (length == 0)
            {
                throw new Exception("Check is empty!");
            }
            var temp = head.Value;
            head = head.Next;
            --length;
            return temp;
        }

        /// <summary>
        /// Checking stack on emptiness
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => length == 0;

        /// <summary>
        /// Getting the length of stack
        /// </summary>
        /// <returns></returns>
        public int GetLength() => length;
    }

}
