using System.Collections;
using System.Collections.Generic;

namespace Task_2
{
    /// <summary>
    /// АТД "Множество"
    /// </summary>
    /// <typeparam name="T">Параметр-тип</typeparam>
    public class Set<T> : IEnumerable<T>
    {
        /// <summary>
        /// Элемент множества
        /// </summary>
        private class SetElement
        {
            /// <summary>
            /// Значение элемента множества
            /// </summary>
            public T Value { get; private set; }

            /// <summary>
            /// Указатель на следующий элемент
            /// </summary>
            public SetElement Next { get; set; }

            /// <summary>
            /// Конструктор для элемента множества
            /// </summary>
            /// <param name="value">Значение элемента</param>
            /// <param name="next">Указатель на следующий элемент</param>
            public SetElement(T value, SetElement next)
            {
                this.Value = value;
                this.Next = next;
            }
        }

        /// <summary>
        /// Указатель на первый элемент множества
        /// </summary>
        private SetElement head;

        /// <summary>
        /// Длина множества
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Добавление нового значения в множество
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        public void Add(T value)
        {
            if (!IsBelong(value))
            {
                var newElement = new SetElement(value, head);
                head = newElement;
                ++Length;
            }
        }

        /// <summary>
        /// Удаление элемента из множества
        /// </summary>
        /// <param name="value">Значение для удаления</param>
        public void Remove(T value)
        {
            if (!IsBelong(value))
            {
                throw new RemoveNotContainedValueException("Данного значения нет в множестве!");
            }

            if (Equals(head.Value, value))
            {
                head = head.Next;
                --Length;
                return;
            }

            var cursor = head;
            while(!Equals(cursor.Next.Value, value))
            {
                cursor = cursor.Next;
            }

            cursor.Next = cursor.Next.Next;
            --Length;
        }

        /// <summary>
        /// Проверка знаачения на принадлежность множеству
        /// </summary>
        /// <param name="value">Значение для проверки</param>
        /// <returns>True, если принадлежит, иначе false</returns>
        public bool IsBelong(T value)
        {
            var cursor = head;
            while (cursor != null)
            {
                if (Equals(cursor.Value, value))
                {
                    return true;
                }

                cursor = cursor.Next;
            }

            return false;
        }

        /// <summary>
        /// Операции объединения и пересечения двух множеств
        /// </summary>
        public static class SetOperations
        {
            /// <summary>
            /// Операция объединения двух множеств
            /// </summary>
            /// <param name="set1">Первое множество</param>
            /// <param name="set2">Второе множество</param>
            /// <returns>Объединение двух множеств в виде множества</returns>
            public static Set<T> Union(Set<T> set1, Set<T> set2)
            {
                var resultSet = set1;

                foreach (var element in set2)
                {
                    if (!set1.IsBelong(element))
                    {
                        resultSet.Add(element);
                    }
                }

                return resultSet;
            }

            /// <summary>
            /// Операция объединения двух множеств
            /// </summary>
            /// <param name="set1">Первое множество</param>
            /// <param name="set2">Второе множество</param>
            /// <returns>Объединение двух множеств в виде множества</returns>
            public static Set<T> Intersection(Set<T> set1, Set<T> set2)
            {
                var resultSet = new Set<T>();

                foreach (var element in set1)
                {
                    if (set2.IsBelong(element))
                    {
                        resultSet.Add(element);
                    }
                }

                return resultSet;
            }
        }

        /// <summary>
        /// Получить генериковый перечислитель
        /// </summary>
        /// <returns>Генериковый перечислитель</returns>
        public IEnumerator<T> GetEnumerator() => new SetEnumerator(this);

        /// <summary>
        /// Получить негенериковый перечислитель
        /// </summary>
        /// <returns>Негенериковый перечислитель</returns>
        IEnumerator IEnumerable.GetEnumerator() => new SetEnumerator(this);

        /// <summary>
        /// Класс для перебора элементов
        /// </summary>
        private class SetEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Указатель на первый элемеент
            /// </summary>
            private SetElement head;

            /// <summary>
            /// Указатель на текущий элемент
            /// </summary>
            private SetElement cursor;

            /// <summary>
            /// Проверка на конец множества
            /// </summary>
            private bool isFinished;

            /// <summary>
            /// Конструктор для перечислителя
            /// </summary>
            public SetEnumerator(Set<T> set) => head = set.head;

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
                if (isFinished)
                {
                    return false;
                }

                if (cursor == null)
                {
                    cursor = head;

                    if (head == null)
                    {
                        isFinished = true;
                        return false;
                    }

                    return true;
                }

                if (cursor.Next == null)
                {
                    isFinished = true;
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
