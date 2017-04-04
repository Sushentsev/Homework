using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    /// <summary>
    /// Interface of hash function
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Getting hash value
        /// </summary>
        /// <param name="word">Value for hashing</param>
        /// <returns>Hash</returns>
        uint GetHash(string word);
    }
}
