using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class RecursiveBinarySearchTree<T> : BinarySearchTree<T> where T: IComparable
    {
        private T[] enumeratorArray = new T[0];

        private int size = 0;

        public override void Add(T value)
        {
            TreeNode<T> node = new TreeNode<T>(value);

            if (this.rootNode != null)
            {
                this.Add(this.rootNode, node);
            }
            else
            {
                this.rootNode = node;
            }

            this.Count++;
        }

        public override TreeNode<T> FindNode(T value)
        {
            TreeNode<T> foundNode = null;

            if (this.rootNode != null)
            {
                foundNode = this.Find(this.rootNode, value);
            }

            return foundNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.PreOrderTraversal(this.rootNode, this.AddToArray);
            return ((IEnumerable<T>) this.enumeratorArray).GetEnumerator();
        }

        private void Add(TreeNode<T> currentNode, TreeNode<T> newNode)
        {
            if (currentNode.Value.CompareTo(newNode.Value) > 0)
            {
                if (currentNode.LeftNode != null)
                {
                    this.Add(currentNode.LeftNode, newNode);
                }
                else
                {
                    currentNode.LeftNode = newNode;
                    newNode.ParentNode = currentNode;
                }
            }
            else
            {
                if (currentNode.RightNode != null)
                {
                    this.Add(currentNode.RightNode, newNode);
                }
                else
                {
                    currentNode.RightNode = newNode;
                    newNode.ParentNode = currentNode;
                }
            }         
        }

        //Recursive find
        private TreeNode<T> Find(TreeNode<T> currentNode, T value )
        {
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.Value.CompareTo(value) == 0)
            {
                return currentNode;
            }

            return this.Find(currentNode.Value.CompareTo(value) > 0 ? currentNode.LeftNode : currentNode.RightNode, value);
        }

        // TODO: Re-do this without recursion
        private void PreOrderTraversal(TreeNode<T> currentNode, Action<T> action)
        {
            if (currentNode == null)
            {
                return;
            }

            action(currentNode.Value); // This is process. Process current node then all others
            this.PreOrderTraversal(currentNode.LeftNode, action);
            this.PreOrderTraversal(currentNode.RightNode, action);
        }

        private void InOrderTraversal(TreeNode<T> currentNode, Action<T> action)
        {
            if (currentNode == null)
            {
                return;
            }

            this.InOrderTraversal(currentNode.LeftNode, action);
            action(currentNode.Value); // This is process. Process current node then all others
            this.InOrderTraversal(currentNode.RightNode, action);
        }

        private void PostOrderTraversal(TreeNode<T> currentNode, Action<T> action)
        {
            if (currentNode == null)
            {
                return;
            }

            this.PostOrderTraversal(currentNode.LeftNode, action);
            this.PostOrderTraversal(currentNode.RightNode, action);
            action(currentNode.Value); // This is process. Process current node then all others
        }

        private void AddToArray(T value)
        {
            if (this.size == enumeratorArray.Count())
            {
                int newLength = this.size == 0 ? 4 : size * 2;

                T[] newArray = new T[newLength];
                this.enumeratorArray.CopyTo(newArray, 0);
                this.enumeratorArray = newArray;
            }

            this.enumeratorArray[size] = value;
            this.size++;
        }
    }
}
