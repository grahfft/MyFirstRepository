using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LinkedList;

namespace Queue
{
    public class ArrayQueue<T>
    {
        private T[] items = new T[0];

        private int headItem = 0;

        private int tailItem = -1;

        public ArrayQueue()
        {
            
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (this.Count == this.items.Length)
            {
                int newLength = this.Count == 0 ? 4 : this.Count * 2;

                T[] newArray = new T[newLength];

                if (this.Count > 0)
                {
                    //update array
                    int newArrayIndex = 0;

                    if (this.tailItem >= this.headItem)
                    {
                        for (int index = this.headItem; index <= this.tailItem; index++)
                        {
                            newArray[newArrayIndex] = this.items[index];
                            newArrayIndex++;
                        }
                    }
                    else
                    {
                        for (int index = this.headItem; index < this.items.Length; index++)
                        {
                            newArray[newArrayIndex] = this.items[index];
                            newArrayIndex++;
                        }

                        for (int index = 0; index <= this.tailItem; index++)
                        {
                            newArray[newArrayIndex] = this.items[index];
                            newArrayIndex++;
                        }
                    }

                    this.headItem = 0;
                    this.tailItem = newArrayIndex - 1;
                }
                else
                {
                    this.headItem = 0;
                    this.tailItem = -1;
                }

                this.items = newArray;
            }

            if (this.tailItem == this.items.Length - 1)
            {
                this.tailItem = 0;
            }
            else
            {
                this.tailItem++;
            }

            this.items[this.tailItem] = item;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new Exception("Empty Stack");
            }

            T temp = this.items[this.headItem];
            
            if (this.headItem == this.items.Length - 1)
            {
                this.headItem = 0;
            }
            else
            {
                this.headItem++;
            }

            this.Count--;

            return temp;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new Exception("Empty Stack");
            }

            return this.items[this.headItem];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count > 0)
            {
                //update array
                int newArrayIndex = 0;

                if (this.tailItem >= this.headItem)
                {
                    for (int index = this.headItem; index <= this.tailItem; index++)
                    {
                        yield return this.items[index];
                    }
                }
                else
                {
                    for (int index = this.headItem; index < this.items.Length; index++)
                    {
                        yield return this.items[index];
                    }

                    for (int index = 0; index <= this.tailItem; index++)
                    {
                        yield return this.items[index];
                    }
                }

                this.headItem = 0;
                this.tailItem = newArrayIndex - 1;
            }
        }

        public void Clear()
        {
            this.headItem = 0;
            this.tailItem = -1;
            this.Count = 0;
        }
    }
}
