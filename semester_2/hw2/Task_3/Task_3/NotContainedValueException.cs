using System;

namespace Task_3
{
    /// <summary>
    /// Исключение, которое бросается при попытке удаления несуществующего элемента списка
    /// </summary>
    [Serializable]
    public class NotContainedValueException : Exception
    {
        public NotContainedValueException() { }
        public NotContainedValueException(string message) : base(message) { }
        public NotContainedValueException(string message, Exception inner) : base(message, inner) { }
        protected NotContainedValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
