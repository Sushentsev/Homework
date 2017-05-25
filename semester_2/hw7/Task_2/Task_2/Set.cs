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
        private Dictionary<T, List<T>> set = new Dictionary<T, List<T>>();

        /// <summary>
        /// Операция добавления нового значения
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        public void Add(T value)
        {
            if (!IsBelong(value))
            {
                if (!set.ContainsKey(value))
                {
                    set.Add(value, new List<T>());
                }

                set[value].Add(value);
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

            set[value].Remove(value);
        }

        /// <summary>
        /// Проверка на принадлежность множеству
        /// </summary>
        /// <param name="value">Значение для проверки</param>
        /// <returns>True, если принадлежит, иначе false</returns>
        public bool IsBelong(T value)
        {
            if (set.ContainsKey(value))
            {
                if (set[value].Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Подсчет количества значений в множестве
        /// </summary>
        /// <returns>Количество значений в множестве</returns>
        public int GetSize()
        {
            var result = 0;

            foreach (var setElement in set)
            {
                result += setElement.Value.Count;
            }

            return result;
        }

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
                    foreach (var listElement in setElement.Value)
                    {
                        resultSet.Add(listElement);
                    }
                }

                foreach (var setElement in set2.set)
                {
                    foreach (var listElement in setElement.Value)
                    {
                        resultSet.Add(listElement);
                    }
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
                    foreach (var listElement in setElement.Value)
                    {
                        if (set2.IsBelong(listElement))
                        {
                            resultSet.Add(listElement);
                        }
                    }
                }

                return resultSet;
            }
        }
    }
}
