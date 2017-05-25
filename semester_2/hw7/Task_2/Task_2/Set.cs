using System.Collections.Generic;

namespace Task_2
{
    /// <summary>
    /// АТД "Множество"
    /// </summary>
    /// <typeparam name="T">Параметр-тип</typeparam>
    public class Set<T>
    {
        /// <summary>
        /// Множество 
        /// </summary>
        private Dictionary<T, T> set = new Dictionary<T, T>();

        /// <summary>
        /// Операция добавления нового значения
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        public void Add(T value)
        {
            if (!IsBelong(value))
            {
                set.Add(value, value);
            }
        }

        /// <summary>
        /// Операция удаления значения
        /// </summary>
        /// <param name="value">Значение для удаления</param>
        public void Remove(T value)
        {
            if (!IsBelong(value))
            {
                throw new RemoveNotContainedValueException("The value is not contained in the set!");
            }

            set.Remove(value);
        }

        /// <summary>
        /// Проверка на принадлежность множеству
        /// </summary>
        /// <param name="value">Значение для проверки</param>
        /// <returns>True, если принадлежит, иначе false</returns>
        public bool IsBelong(T value) => set.ContainsKey(value);

        /// <summary>
        /// Подсчет количества значений в множестве
        /// </summary>
        /// <returns>Количество значений в множестве</returns>
        public int GetSize() => set.Count;

        /// <summary>
        /// Класс с операциями над множествами
        /// </summary>
        public static class SetOperations
        {
            /// <summary>
            /// Объединение множеств
            /// </summary>
            /// <param name="set1">Первое множество</param>
            /// <param name="set2">Второе множество</param>
            /// <returns>Объединение двух множеств в виде множества</returns>
            public static Set<T> Union(Set<T> set1, Set<T> set2)
            {
                var resultSet = new Set<T>();

                foreach (var setElement in set1.set)
                {
                    resultSet.Add(setElement.Value);
                }

                foreach (var setElement in set2.set)
                {
                    resultSet.Add(setElement.Value);
                }

                return resultSet;
            }

            /// <summary>
            /// Пересечение множеств
            /// </summary>
            /// <param name="set1">Первое множество</param>
            /// <param name="set2">Второе множество</param>
            /// <returns>Пересечение двух множеств в виде множества</returns>
            public static Set<T> Intersection(Set<T> set1, Set<T> set2)
            {
                var resultSet = new Set<T>();

                foreach (var setElement in set1.set)
                {
                    if (set2.IsBelong(setElement.Value))
                    {
                        resultSet.Add(setElement.Value);
                    }
                }

                return resultSet;
            }
        }
    }
}
