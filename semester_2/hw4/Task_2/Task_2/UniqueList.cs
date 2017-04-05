using System;

namespace Task_2
{
    /// <summary>
    /// Class linked UniqueList based on class List
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Adding new value to unique list.
        /// If the value belongs to list, the exception will be thrown
        /// </summary>
        /// <param name="value">Value for adding</param>
        public override void Add(int value)
        {
            if (IsContained(value))
            {
                throw new AddContainedValueException("The value is already in the list!");
            }

            base.Add(value);
        }

        /// <summary>
        /// Removing value from unique list.
        /// If the value does not belong to list, the exception will be thrown
        /// </summary>
        /// <param name="value">Value for removing</param>
        public override void RemoveElement(int value)
        {
            if (!IsContained(value))
            {
                throw new RemoveNotContainedValueException("The value is not contained in the list!");
            }

            base.RemoveElement(value);
        }
    }
}
