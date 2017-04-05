using System;

namespace Task_2
{
    /// <summary>
    /// Add value which belongs to list
    /// </summary>
    [Serializable]
    public class AddContainedValueException : Exception
    {
        public AddContainedValueException() { }
        public AddContainedValueException(string message) : base(message) { }
        public AddContainedValueException(string message, Exception inner) : base(message, inner) { }
        protected AddContainedValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
