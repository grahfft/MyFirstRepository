using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MySingleLinkedList<T>
    {
        public Node<T> HeadNode { get; private set; }
 
        public Node<T> TailNode { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(Node<T> newNode)
        {
            newNode.NextNode = this.HeadNode;

            this.HeadNode = newNode;

            this.Count++;

            if (Count == 1)
            {
                this.TailNode = this.HeadNode;
            }
        }

        public void AddLast(Node<T> newNode)
        {
            if (this.Count == 0)
            {
                this.HeadNode = newNode;
            }
            else
            {
                this.TailNode.NextNode = newNode;

            }

            this.TailNode = newNode;
            this.Count++;
        }

        public void RemoveLast()
        {
            if (this.Count != 0)
            {
                if (this.Count == 1)
                {
                    this.HeadNode = null;
                    this.TailNode = null;
                }
                else
                {
                    Node<T> currentNode = this.HeadNode;
                    while (currentNode.NextNode != this.TailNode)
                    {
                        currentNode = currentNode.NextNode;
                    }

                    currentNode.NextNode = null;
                    this.TailNode = currentNode;
                }

                this.Count--;
            }
        }

        public void RemoveFirst()
        {
            if (this.Count != 0)
            {               
                this.HeadNode = this.HeadNode.NextNode;

                this.Count--;

                if (this.Count == 0)
                {
                    this.TailNode = null;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.HeadNode;

            while (currentNode.NextNode != null)
            {
                //Research yield keyword more
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        public bool Contains(T value)
        {
            Node<T> currentNode = this.HeadNode;
            while (currentNode.NextNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> currentNode = this.HeadNode;
            while (currentNode.NextNode != null)
            {
                array[arrayIndex++] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        public bool Remove(T item)
        {
            Node<T> previousNode = null;
            Node<T> currentNode = this.HeadNode;

            while (currentNode.NextNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previousNode == null)
                    {
                        this.RemoveFirst();
                    }
                    else
                    {
                        previousNode.NextNode = currentNode.NextNode;

                        if (currentNode.NextNode == null)
                        {
                            this.TailNode = previousNode;
                        }

                        this.Count--;
                    }

                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            return false;
        }

        public void Clear()
        {
            this.HeadNode = null;
            this.TailNode = null;
            Count = 0;
        }
    }
}
