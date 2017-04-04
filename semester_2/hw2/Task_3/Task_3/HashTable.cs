using System;

namespace Task_3
{
    /// <summary>
    /// Hash table on linked list
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// The size of hash table
        /// </summary>
        private const int sizeOfTable = 128;

        /// <summary>
        /// Hash table
        /// </summary>
        public List[] Table { get; private set; }

        /// <summary>
        /// Constructor for hash table
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
        /// Hash function
        /// </summary>
        /// <param name="word">Word for hashing</param>
        /// <returns>Hash value</returns>
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
        /// Adding new word to hash table
        /// </summary>
        /// <param name="word">Word for adding</param>
        public void Add(string word) => Table[GetHash(word)].Add(word);

        /// <summary>
        /// Removing word from hash table
        /// </summary>
        /// <param name="word">Word for removing</param>
        public void Remove(string word) => Table[GetHash(word)].RemoveElement(word);

        /// <summary>
        /// Checking if the word is contained
        /// </summary>
        /// <param name="word">Word for checking</param>
        /// <returns>True if belongs otherwise false</returns>
        public bool IsContained(string word) => Table[GetHash(word)].IsContained(word);
    }
}
