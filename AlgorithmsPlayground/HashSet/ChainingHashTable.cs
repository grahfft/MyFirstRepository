using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinkedList;

namespace HashSet
{
    /// <summary>
    /// This class uses chaining to store information
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChainingHashTable<TKey, TValue> where TKey : IComparable
    {
        private MyDoubleLinkedList<HashTableNode<TKey, TValue>>[] myTable = new MyDoubleLinkedList<HashTableNode<TKey, TValue>>[0];

        private readonly double loadFactor = .75;

        private int currentTableSize = 0;

        public ChainingHashTable()
        {
            
        }

        public ChainingHashTable(int startSize, double loadFactor)
        {
            this.myTable = new MyDoubleLinkedList<HashTableNode<TKey, TValue>>[startSize];
            this.currentTableSize = startSize;

            if (loadFactor > -1.0)
            {
                this.loadFactor = loadFactor;
            }
        }

        public int Count
        {
            get; 
            private set;
        }

        public double Threshold
        {
            get
            {
                if (this.currentTableSize != 0)
                {
                    return (float)this.Count / this.currentTableSize;
                }

                return 1.0;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!this.TryGetValue(key, out value))
                {
                    throw new Exception("No Value attached to key");
                }

                return value;
            }
        }

        public void AddItem(TKey key, TValue value)
        {
            HashTableNode<TKey, TValue> tableNode = new HashTableNode<TKey, TValue>(key, value);

            if (this.Threshold >= this.loadFactor)
            {
                if (this.currentTableSize == 0)
                {
                    this.currentTableSize = 16; //picked a random number
                }
                else
                {
                    this.currentTableSize = this.currentTableSize * 2;
                }

                MyDoubleLinkedList<HashTableNode<TKey, TValue>>[] oldTable = this.myTable;
                this.myTable = new MyDoubleLinkedList<HashTableNode<TKey, TValue>>[this.currentTableSize];
                this.AddToNewTable(oldTable);
            }

            this.AddItem(tableNode);
            this.Count++;
        }

        public void RemoveItem(TKey key)
        {
            HashTableNode<TKey, TValue> node = this.FindItem(key);
            if (node != null)
            {
                int index = this.GetIndex(key);

                var list = this.myTable[index];

                if (list != null)
                {
                    list.Remove(node);
                }
            }

            this.Count--;
        }

        public HashTableNode<TKey, TValue> FindItem(TKey key)
        {
            int index = this.GetIndex(key);

            var list = this.myTable[index];

            if (list != null)
            {
                foreach (HashTableNode<TKey, TValue> hashTableNode in list)
                {
                    if (hashTableNode.Key.CompareTo(key) == 0)
                    {
                        return hashTableNode;
                    }
                }
            }

            return null;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            HashTableNode<TKey, TValue> node = this.FindItem(key);
            if (node == null)
            {
                value = default(TValue);
                return false;
            }

            value = node.Value;
            return true;
        }

        public IEnumerator<HashTableNode<TKey, TValue>> GeetEnumerator()
        {
            foreach (MyDoubleLinkedList<HashTableNode<TKey, TValue>> linkedList in myTable)
            {
                if (linkedList != null)
                {
                    foreach (HashTableNode<TKey, TValue> hashTableNode in linkedList)
                    {
                        yield return hashTableNode;
                    }
                }
            }
        }

        private void AddToNewTable(MyDoubleLinkedList<HashTableNode<TKey, TValue>>[] oldTable)
        {
            foreach (MyDoubleLinkedList<HashTableNode<TKey, TValue>> list in oldTable)
            {
                if (list != null)
                {
                    foreach (HashTableNode<TKey, TValue> item in list)
                    {
                        this.AddItem(item);
                    }
                }
            }
        }

        private void AddItem(HashTableNode<TKey, TValue> tableNode)
        {
            int index = this.GetIndex(tableNode.Key);

            if (this.myTable[index] == null)
            {
                this.myTable[index] = new MyDoubleLinkedList<HashTableNode<TKey, TValue>>();
            }
            
            this.myTable[index].AddFirst(new Node<HashTableNode<TKey, TValue>>(tableNode));
        }


        private int GetIndex(TKey key)
        {
            return key.GetHashCode() % this.currentTableSize;
        }
    }
}
