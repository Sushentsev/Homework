using System;

namespace Task_3
{
    /// <summary>
    /// Класс связный список
    /// </summary>
    public class List
    {
        /// <summary>
        /// Класс элемент связного списка
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Указатель на следующий элемент
            /// </summary>
            public ListElement Next { get; set; }

            /// <summary>
            /// Значение элемента
            /// </summary>
            public string Value { get; private set; }

            /// <summary>
            /// Конструктор для класса ListElement
            /// </summary>
            /// <param name="next">Указатель на следующий элемент</param>
            /// <param name="value">Значение элемента</param>
            public ListElement(ListElement next, string value)
            {
                this.Next = next;
                this.Value = value;
            }

        }

        /// <summary>
        /// Указатель на первый элемент списка
        /// </summary>
        private ListElement head;

        /// <summary>
        /// Длина списка
        /// </summary>
        private int length;

        /// <summary>
        /// Добавление нового элемента в начало списка
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        public void Add(string value)
        {
            var newElement = new ListElement(head, value);
            head = newElement;
            ++length;
        }

        /// <summary>
        /// Проверка списка на пустоту
        /// </summary>
        /// <returns>True, если список пуст, иначе false</returns>
        public bool IsEmpty() => length == 0;

        /// <summary>
        /// Получение длины списка
        /// </summary>
        /// <returns>Длина списка</returns>
        public int GetLength() => length;

        /// <summary>
        /// Проверка значения на принадлежность списку
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <returns>True, если значение принадлежит списку, иначе false</returns>
        public bool IsContained(string value)
        {
            var cursor = head;

            for (var i = 0; i < length; ++i)
            {
                if (cursor.Value == value)
                {
                    return true;
                }
                cursor = cursor.Next;
            }

            return false;
        }

        /// <summary>
        /// Удаление элемента из списка
        /// </summary>
        /// <param name="value">Значение для удаления</param>
        public void RemoveElement(string value)
        {
            if (IsEmpty())
            {
                throw new EmptyListException("List is empty!");
            }

            if (!IsContained(value))
            {
                throw new NotContainedValueException("The word is not contained in the list!");
            }

            if (head.Value == value)
            {
                head = head.Next;
                --length;
                return;
            }

            var cursor = head;
            for (var i = 0; i < length - 1; ++i)
            {
                if (cursor.Next.Value == value)
                {
                    cursor.Next = cursor.Next.Next;
                    --length;
                    return;
                }

                cursor = cursor.Next;
            }
        }

        /// <summary>
        /// Получение первого элемента списка
        /// </summary>
        /// <returns>Значение первого элемента списка</returns>
        public string Peek()
        {
            if (IsEmpty())
            {
                throw new EmptyListException("List is empty");
            }

            return head.Value;
        }
    }
}
