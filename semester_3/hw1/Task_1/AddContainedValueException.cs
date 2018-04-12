using System;

namespace Task_1
{
    /// <summary>
    /// Adding value which belongs to tree
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
