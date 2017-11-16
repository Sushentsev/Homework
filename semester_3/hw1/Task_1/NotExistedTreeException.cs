using System;

namespace Task_1
{
    /// <summary>
    /// The tree does not exist
    /// </summary>
    [Serializable]
    public class NotExistedTreeException : Exception
    {
        public NotExistedTreeException() { }
        public NotExistedTreeException(string message) : base(message) { }
        public NotExistedTreeException(string message, Exception inner) : base(message, inner) { }
        protected NotExistedTreeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
