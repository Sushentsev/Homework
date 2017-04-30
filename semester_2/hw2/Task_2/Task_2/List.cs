using System;

namespace Task_2
{
    /// <summary>
    /// Класс связный список
    /// </summary>
    public class List
    {
        /// <summary>
        /// Элемент связного списка
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Указатель на следующий элемент списка
            /// </summary>
            public ListElement Next { get; set; }

            /// <summary>
            /// Значение элемента списка
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Конструктор для класса ListElement
            /// </summary>
            /// <param name="next">Указатель на следующий элемент</param>
            /// <param name="value">Значение элемента</param>
            public ListElement(ListElement next, int value)
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
        public int Length { get; private set; }

        /// <summary>
        /// Добавление нового элемента в нужную позицию.
        /// Нумерация начинается с 0
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        /// <param name="position">Позиция для добавления</param>
        public void AddValueByPosition(int value, int position)
        {
            if (position < 0 || position > Length)
            {
                throw new OutOfIndexException("Incorrect position!");
            }

            if (position == 0)
            {
                var newHeadElement = new ListElement(head, value);
                head = newHeadElement;
                ++Length;
                return;
            }

            var cursor = head;
            for (var i = 0; i < position - 1; ++i)
            {
                cursor = cursor.Next;
            }
            var newElement = new ListElement(cursor.Next, value);
            cursor.Next = newElement;
            ++Length;
        }

        /// <summary>
        /// Проверка списка на пустоту
        /// </summary>
        /// <returns>True, если список пуст, иначе false </returns>
        public bool IsEmpty() => Length == 0;

        /// <summary>
        /// Получение значения элемента по его позиции
        /// </summary>
        /// <param name="position">Необходимая позиция</param>
        /// <returns>Значение элемента</returns>
        public int GetValueByPosition(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new OutOfIndexException("Incorrect position!");
            }

            var cursor = head;
            for (var i = 0; i < position; ++i)
            {
                cursor = cursor.Next;
            }

            return cursor.Value;
        }

        /// <summary>
        /// Изменения значения элемента по его позиции
        /// </summary>
        /// <param name="value">Новое значение</param>
        /// <param name="position">Необходимая позиция</param>
        public void ChangeValueByPosition(int value, int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new OutOfIndexException("Incorrect position!");
            }

            var cursor = head;
            for (var i = 0; i < position; ++i)
            {
                cursor = cursor.Next;
            }
            cursor.Value = value;
        }

        /// <summary>
        /// Удаление элемента в заданной позиции
        /// </summary>
        /// <param name="position">Позиция для удаления</param>
        public void RemoveElementByPosition(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new OutOfIndexException("Incorrect position!");
            }

            if (position == 0)
            {
                head = head.Next;
                --Length;
                return;
            }

            var cursor = head;
            for (var i = 0; i < position - 1; ++i)
            {
                cursor = cursor.Next;
            }
            cursor.Next = cursor.Next.Next;
            --Length;
        }  
    }
}
