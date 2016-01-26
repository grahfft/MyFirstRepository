using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    public class HashTableNode<TKey, TValue> where TKey : IComparable
    {
        public HashTableNode(TKey key, TValue value)
        {
            
        }

        public TKey Key
        {
            get; 
            private set;
        }

        public TValue Value
        {
            get; 
            private set;
        }
    }
}
