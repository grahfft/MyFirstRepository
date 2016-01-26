using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace Stack
{
    public class MyLinkedListStack<T>
    {
        private MyDoubleLinkedList<T> list = new MyDoubleLinkedList<T>(); 

        public MyLinkedListStack()
        {
            
        }

        public void Push(T obj)
        {
            this.list.AddFirst(new Node<T>(obj));
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new Exception("Empty Stack");
            }

            T temp = this.list.HeadNode.Value;
            this.list.RemoveFirst();
            return temp;
        }

        public T Peek()
        {
            if (this.list.Count == 0)
            {
                throw new Exception("Empty Stack");
            }

            return this.list.HeadNode.Value;
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
 
    }
}
