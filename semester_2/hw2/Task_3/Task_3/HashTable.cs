using System;

namespace Task_3
{
    /// <summary>
    /// Класс хеш-таблица на основе связного списка
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Размер хеш-таблицы
        /// </summary>
        private const int sizeOfTable = 128;

        /// <summary>
        /// Хеш-таблица
        /// </summary>
        public List[] Table { get; private set; }

        /// <summary>
        /// Конструктор для хеш-таблицы
        /// </summary>
        public HashTable()
        {
            Table = new List[sizeOfTable];

            for (var i = 0; i < sizeOfTable; ++i)
            {
                Table[i] = new List();
            }
        }

        /// <summary>
        /// Хеш-функция
        /// </summary>
        /// <param name="word">Слово для хеширования</param>
        /// <returns>Хеш-значение</returns>
        public int GetHash(string word)
        {
            var hash = 0;

            for (var i = 0; i < word.Length; ++i)
            {
                hash = hash + word[i];
                hash %= sizeOfTable;
            }

            return hash;
        }

        /// <summary>
        /// Добавление нового значения в хеш-таблицу
        /// </summary>
        /// <param name="word">Значение для добавления</param>
        public void Add(string word) => Table[GetHash(word)].Add(word);

        /// <summary>
        /// Удаление значения из хеш-таблицы
        /// </summary>
        /// <param name="word">Значение для удаления</param>
        public void Remove(string word) => Table[GetHash(word)].RemoveElement(word);

        /// <summary>
        /// Проверка значения на принадлежность хеш-таблице
        /// </summary>
        /// <param name="word">Значение для проверки</param>
        /// <returns>True, если принадлежит, иначе false</returns>
        public bool IsContained(string word) => Table[GetHash(word)].IsContained(word);
    }
}
