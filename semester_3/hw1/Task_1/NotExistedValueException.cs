using System;

namespace Task_1
{
    /// <summary>
    /// The value does not exist in the tree
    /// </summary>
    [Serializable]
    public class NotExistedValueException : Exception
    {
        public NotExistedValueException() { }
        public NotExistedValueException(string message) : base(message) { }
        public NotExistedValueException(string message, Exception inner) : base(message, inner) { }
        protected NotExistedValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
