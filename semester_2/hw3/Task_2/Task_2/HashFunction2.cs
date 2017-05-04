using System;

namespace Task_2
{
    /// <summary>
    /// Function for hashing
    /// </summary>
    public class HashFunction2 : IHashFunction
    {
        /// <summary>
        /// Getting hash value
        /// </summary>
        /// <param name="word">Word for hashing</param>
        /// <returns>Hash value</returns>
        public uint GetHash(string word)
        {
            uint hash = 0;

            foreach (var symbol in word)
            {
                hash = hash * 1664525 + symbol + 1013904223;
            }

            return hash;
        }
    }
}
