using System;

namespace Контрольная_работа
{
    /// <summary>
    /// Исключение, которое бросается при неккоректном количестве кнопок
    /// </summary>
    [Serializable]
    public class IncorrectSizeException : Exception
    {
        public IncorrectSizeException() { }
        public IncorrectSizeException(string message) : base(message) { }
        public IncorrectSizeException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectSizeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
