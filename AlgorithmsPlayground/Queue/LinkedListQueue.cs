using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace Queue
{
    public class LinkedListQueue<T>
    {
        private readonly MyDoubleLinkedList<T> linkedList; 

        public LinkedListQueue()
        {
            this.linkedList = new MyDoubleLinkedList<T>();
        }

        public Node<T> HeadNode
        {
            get
            {
                return this.linkedList.HeadNode;
            }
        }

        public void Enqueue(T item)
        {
            this.linkedList.AddLast(new Node<T>(item));
        }

        public T Dequeue()
        {
            if (this.linkedList.Count == 0)
            {
                throw new Exception("Empty Queue");
            }

            Node<T> tempNode = this.HeadNode;
            this.linkedList.RemoveFirst();

            return tempNode.Value;
        }

        public T Peek()
        {
            if (this.linkedList.Count == 0)
            {
                throw new Exception("Empty Queue");
            }

            return this.HeadNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.linkedList.GetEnumerator();
        }

        public void Clear()
        {
            this.linkedList.Clear();
        }
    }
}
