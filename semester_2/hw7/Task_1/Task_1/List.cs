using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Класс список
    /// </summary>
    /// <typeparam name="T">Параметр-тип</typeparam>
    public class List<T> : IEnumerable<T>
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
            public T Value { get; set; }

            /// <summary>
            /// Конструктор для элемента списка
            /// </summary>
            /// <param name="next">Указатель на следующий элемент</param>
            /// <param name="value">Значение элемента</param>
            public ListElement(ListElement next, T value)
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
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        /// <param name="position">Позиция для добавления</param>
        public void AddValueByPosition(T value, int position)
        {
            if (position < 0 || position > Length)
            {
                throw new OutOfIndexException("Некорректная позиция!");
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
        public T GetValueByPosition(int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new OutOfIndexException("Некорректная позиция!");
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
        public void ChangeValueByPosition(T value, int position)
        {
            if (position < 0 || position >= Length)
            {
                throw new OutOfIndexException("Некорректная позиция!");
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
                throw new OutOfIndexException("Некорректная позиция!");
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

        /// <summary>
        /// Получить генериковый перечислитель
        /// </summary>
        /// <returns>Генериковый перечислитель</returns>
        public IEnumerator<T> GetEnumerator() => new ListEnumerator(this);

        /// <summary>
        /// Получить негенериковый перечислитель
        /// </summary>
        /// <returns>Негенериковый перечислитель</returns>
        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator(this);

        /// <summary>
        /// Класс для перебора элементов
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Указатель на первый элемеент
            /// </summary>
            private ListElement head;

            /// <summary>
            /// Указатель на текущий элемент
            /// </summary>
            private ListElement cursor;

            /// <summary>
            /// Конструктор для перечислителя
            /// </summary>
            public ListEnumerator(List<T> list) => head = list.head;

            /// <summary>
            /// Возвращает значение текущего элемента
            /// </summary>
            public T Current
            {
                get
                {
                    return cursor.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {

            }

            /// <summary>
            /// Переход к следующему элементу
            /// </summary>
            /// <returns>True, если переход состоялся, иначе false</returns>
            public bool MoveNext()
            {
                if (cursor == null)
                {
                    cursor = head;
                    
                    if (head == null)
                    {
                        return false;
                    }

                    return true;
                }

                if (cursor.Next == null)
                {
                    return false;
                }

                cursor = cursor.Next;
                return true;
            }

            /// <summary>
            /// Поставить перечислитель на начальную позицию
            /// </summary>
            public void Reset() => cursor = null;
        }
    }
}
