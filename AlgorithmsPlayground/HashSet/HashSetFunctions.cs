using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    //Example Hashing algorithms
    public class HashSetFunctions
    {
        public static int AdditiveHashFunction(string value)
        {
            int total = 0;

            unchecked
            {
                total = value.Aggregate(total, (current, character) => current + (int) character);
            }

            return total;
        }

        /// <summary>
        /// First Reported by Dan Bernstein
        /// www.cse.yorku.ca/~oz/hash.html
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int DJB2HashFunction(string value)
        {
            int hash = 5381;

            foreach (int c in value.ToCharArray())
            {
                unchecked
                {
                    hash = ((hash << 5) + hash) + c;
                }
            }

            return hash;
        }

        public static int FoldingHashFunction(string value)
        {
            int currentHashValue = 0;

            int startIndex = 0;
            int currentBytes = 0;

            do
            {

                currentBytes = GetNextBytes(startIndex, value);
                unchecked
                {
                    currentHashValue += currentBytes;
                }

                startIndex += 4;

            } while (currentBytes != 0);

            return currentHashValue;
        }

        private static int GetNextBytes(int startIndex, string str)
        {
            int currentBytes = 0;

            currentBytes += GetByte(str, startIndex);
            currentBytes += GetByte(str, startIndex + 1) << 8;
            currentBytes += GetByte(str, startIndex + 2) << 16;
            currentBytes += GetByte(str, startIndex + 3) << 24;

            return currentBytes;
        }

        private static int GetByte(string str, int index)
        {
            if (index < str.Length)
            {
                return (int) str[index];
            }

            return 0;
        }
    }
}
