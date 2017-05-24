using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    /// <summary>
    /// Исключение, которе бросается при удалении несуществующего в множестве значения
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
