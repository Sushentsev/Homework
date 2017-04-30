using System;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Функции Map, Filter, Fold
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Функция Map
        /// </summary>
        /// <param name="list">Связный список</param>
        /// <param name="function">Функция</param>
        /// <returns>Связный список, получаемый применением функции к каждому элементу</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var newList = new List<int>();

            foreach (var element in list)
            {
                newList.Add(function(element));
            }

            return newList;
        }

        /// <summary>
        /// Функция Filter
        /// </summary>
        /// <param name="list">Связный список</param>
        /// <param name="function">Функция</param>
        /// <returns>Связный список, составленный из элементов переданного списка, для которых переданная функция вернула true</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var newList = new List<int>();

            foreach (var element in list)
            {
                if (function(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        /// <summary>
        /// Функция Fold
        /// </summary>
        /// <param name="list">Связный список</param>
        /// <param name="value">Начальное значение</param>
        /// <param name="function">Функция</param>
        /// <returns>Накопленное значение, получившееся после всего прохода списка</returns>
        public static int Fold(List<int> list, int acc, Func<int, int, int> function)
        {
            foreach (var element in list)
            {
                acc = function(acc, element);
            }

            return acc;
        }
    }
}
