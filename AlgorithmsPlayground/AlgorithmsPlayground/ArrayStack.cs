using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MyArrayStack<T>
    {
        private T[] items = new T[0];

        private int size;

        public MyArrayStack()
        {
            
        }

        /// <summary>
        /// push obj onto stack
        /// </summary>
        /// <param name="obj"></param>
        public void Push(T obj)
        {
            if (size == items.Count())
            {
                int newLength = size == 0 ? 4 : size * 2;

                T[] newArray = new T[newLength];
                items.CopyTo(newArray, 0);
                items = newArray;
            }

            items[size] = obj;
            size++;
        }

        /// <summary>
        /// pop off stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (size == 0)
            {
                throw new Exception("Empty Stack");
            }

            //Subtraction done first as the size would indicate next element location
            size--;
            return this.items[size];
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new Exception("Empty Stack");
            }

            int top = size - 1;

            return this.items[top];
        }

        public int Count
        {
            get { return this.size; }
        }

        public void Clear()
        {
            size = 0;
            this.items = new T[size];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = size - 1; i > 0; i--)
            {
                yield return this.items[i];
            }
        }
    }
}
