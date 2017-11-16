namespace Task_1
{
    /// <summary>
    /// Stack on generics
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// Stack element
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Next stack element
            /// </summary>
            public StackElement Next { get; private set; }

            /// <summary>
            /// Element value
            /// </summary>
            public T Value { get; private set; }

            /// <summary>
            /// Constructor for stack element
            /// </summary>
            /// <param name="next">Next element</param>
            /// <param name="value">Element value</param>
            public StackElement(StackElement next, T value)
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
        /// Stack head
        /// </summary>
        private StackElement head;

        /// <summary>
        /// Adding new value to stack
        /// </summary>
        /// <param name="value">Value for adding</param>
        public void Push(T value)
        {
            var newElement = new StackElement(head, value);
            head = newElement;
            ++length;
        }

        /// <summary>
        /// Removing element from stack
        /// </summary>
        /// <returns>Value from stack head</returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new EmptyStackException("Stack is empty!");
            }

            var temp = head.Value;
            head = head.Next;
            --length;
            return temp;
        }

        /// <summary>
        /// Getting value from stack head
        /// </summary>
        /// <returns>Value from stack head</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new EmptyStackException("Stack is empty!");
            }

            return head.Value;
        }    

        /// <summary>
        /// Checking stack on emptiness
        /// </summary>
        /// <returns>True if stack is empty, otherwise false</returns>
        public bool IsEmpty() => length == 0;

        /// <summary>
        /// Getting stack length
        /// </summary>
        /// <returns>Stack length</returns>
        public int GetLength() => length;
    }
}