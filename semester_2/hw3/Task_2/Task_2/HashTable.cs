using System;

namespace Task_2
{
    /// <summary>
    /// Hash table on linked list
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Size of hash table
        /// </summary>
        private const int size = 100;

        /// <summary>
        /// Function for hashing
        /// </summary>
        private IHashFunction hashFunction;

        /// <summary>
        /// Hash table
        /// </summary>
        private List[] table;

        /// <summary>
        /// Constructor for hash table
        /// </summary>
        /// <param name="hashFunction">Function for hashing</param>
        public HashTable(IHashFunction hashFunction)
        {
            this.hashFunction = hashFunction;
            table = new List[size];

            for (var i = 0; i < size; ++i)
            {
                table[i] = new List();
            }
        }

        /// <summary>
        /// Adding new word to hash table
        /// </summary>
        /// <param name="word">Word for adding</param>
        public void Add(string word) => table[hashFunction.GetHash(word) % size].Add(word);

        /// <summary>
        /// Removing word from hash table
        /// </summary>
        /// <param name="word">Word for removing</param>
        public void Remove(string word) => table[hashFunction.GetHash(word) % size].RemoveElement(word);

        /// <summary>
        /// Checking if the word is contained
        /// </summary>
        /// <param name="word">Word for checking</param>
        /// <returns>True if belongs otherwise false</returns>
        public bool IsContained(string word) => table[hashFunction.GetHash(word) % size].IsContained(word);
    }
}
