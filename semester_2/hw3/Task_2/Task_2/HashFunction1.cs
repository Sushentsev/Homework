using System;

namespace Task_2
{
    /// <summary>
    /// Function for hashing
    /// </summary>
    public class HashFunction1 : IHashFunction
    {
        /// <summary>
        /// Getting hash value
        /// </summary>
        /// <param name="word">Word for hashing</param>
        /// <returns>Hash value</returns>
        public uint GetHash(string word)
        {
            uint hash = 2139062143;

            foreach (var symbol in word)
            {
                hash = 37 * hash + symbol;
            }

            return hash;
        }
    }
}
