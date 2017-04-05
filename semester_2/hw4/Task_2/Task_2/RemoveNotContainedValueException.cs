using System;

namespace Task_2
{
    /// <summary>
    /// Remove value which does not belong to list
    /// </summary>
    [Serializable]
    public class RemoveNotContainedValueException : Exception
    {
        public RemoveNotContainedValueException() { }
        public RemoveNotContainedValueException(string message) : base(message) { }
        public RemoveNotContainedValueException(string message, Exception inner) : base(message, inner) { }
        protected RemoveNotContainedValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
