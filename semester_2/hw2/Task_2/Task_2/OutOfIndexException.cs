using System;

namespace Task_2
{
    /// <summary>
    /// Исключение, которое бросается, если индекс позиции не принадлжежит доупстимым значениям
    /// </summary>
    [Serializable]
    public class OutOfIndexException : Exception
    {
        public OutOfIndexException() { }
        public OutOfIndexException(string message) : base(message) { }
        public OutOfIndexException(string message, Exception inner) : base(message, inner) { }
        protected OutOfIndexException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
