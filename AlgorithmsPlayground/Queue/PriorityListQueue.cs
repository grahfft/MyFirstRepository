using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace Queue
{
    public class PriorityListQueue<T> where T: IComparable
    {
        private MySingleLinkedList<T> itemsList = new MySingleLinkedList<T>();

        public Node<T> HeadNode { get; private set; }

        public int Count { get { return this.itemsList.Count; } }

        public void Enqueue(T item)
        {
            if (this.Count == 0)
            {
                this.itemsList.AddLast(new Node<T>(item));
            }
            else
            {
                Node<T> newNode = new Node<T>(item);

                Node<T> currentNode = this.itemsList.HeadNode;

                Node<T> previousNode = null;

                //Finds place in list; Will add item into list at proper queued spot
                while (currentNode != null && currentNode.Value.CompareTo(item) > 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.NextNode;
                }

                //Hit end of the list; Add last
                if (currentNode == null)
                {
                    this.itemsList.AddLast(newNode);
                }
                else
                {
                    //Found a node with higher priority; check for lower priority
                    if (previousNode != null)
                    {
                        newNode.NextNode = currentNode;
                        previousNode.NextNode = newNode;
                    }
                    else
                    {
                        //No lower priority in list; add to front of the list
                        this.itemsList.AddFirst(newNode);
                    }
                }
            }
        }

        public T Dequeue()
        {
            if (this.itemsList.Count == 0)
            {
                throw new Exception("Empty Queue");
            }

            Node<T> tempNode = this.HeadNode;
            this.itemsList.RemoveFirst();

            return tempNode.Value;
        }

        public T Peek()
        {
            if (this.itemsList.Count == 0)
            {
                throw new Exception("Empty Queue");
            }

            return this.HeadNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.itemsList.GetEnumerator();
        }

        public void Clear()
        {
            this.itemsList.Clear();
        }
    
        // Only difference between normal linked list queue and priority linked list queue is the enqueue call
    }
}
