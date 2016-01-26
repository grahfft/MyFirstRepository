using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Queue;
using Stack;

namespace BinaryTree
{
    public class LoopBinarySearchTree<T> : BinarySearchTree<T> where T : IComparable
    {
        public override void Add(T value)
        {
           TreeNode<T> newNode = new TreeNode<T>(value);
            if (this.rootNode != null)
            {
                this.Add(this.rootNode, newNode);
            }
            else
            {
                this.rootNode = newNode;
            }

            this.Count++;
        }

        public override TreeNode<T> FindNode(T value)
        {
            return this.Find(this.rootNode, value);
        }

        private TreeNode<T> Find(TreeNode<T> currentNode, T value)
        {
            TreeNode<T> nextNode = currentNode;

            while (nextNode != null && nextNode.Value.CompareTo(value) != 0)
            {
                nextNode = nextNode.Value.CompareTo(value) > 0 ? nextNode.LeftNode : nextNode.RightNode;
            }

            return nextNode;
        }

        private void Add(TreeNode<T> currentNode, TreeNode<T> newNode)
        {
            TreeNode<T> nextNode = currentNode;

            while (nextNode != null)
            {
                if (nextNode.Value.CompareTo(newNode.Value) > 0)
                {
                    if (nextNode.LeftNode != null)
                    {
                        nextNode = nextNode.LeftNode;
                    }
                    else
                    {
                        nextNode.LeftNode = newNode;
                        newNode.ParentNode = nextNode;
                        nextNode = null;
                    }
                }
                else
                {
                    if (nextNode.RightNode != null)
                    {
                        nextNode = nextNode.RightNode;
                    }
                    else
                    {
                        nextNode.RightNode = newNode;
                        newNode.ParentNode = nextNode;
                        nextNode = null;
                    }
                }
            }
        }

        public IEnumerator<T> PreOrderTraversal()
        {
            TreeNode<T> currentNode;
            MyArrayStack<TreeNode<T>> treeStack = new MyArrayStack<TreeNode<T>>();
            bool goLeft = true;

            if (this.rootNode == null)
            {
                throw new Exception("Empty tree");
            }

            treeStack.Push(this.rootNode);

            while (treeStack.Count > 0)
            {
                currentNode = treeStack.Pop();

                if (goLeft)
                {
                    while (currentNode != null)
                    {
                        yield return currentNode.Value;
                        treeStack.Push(currentNode);
                        currentNode = currentNode.LeftNode;
                    }

                    goLeft = false;
                }
                else
                {
                    if (currentNode.RightNode != null)
                    {
                        treeStack.Push(currentNode.RightNode);
                        goLeft = true;
                    }
                }
            }
        }

        public IEnumerator<T> InOrderTraversal()
        {
            TreeNode<T> currentNode;
            MyArrayStack<TreeNode<T>> treeStack = new MyArrayStack<TreeNode<T>>();

            bool goLeft = true;

            if (this.rootNode == null)
            {
                throw new Exception("Empty Tree");
            }

            treeStack.Push(this.rootNode);

            while (treeStack.Count > 0)
            {
                currentNode = treeStack.Pop();

                if (goLeft)
                {
                    while (currentNode.LeftNode != null)
                    {
                        treeStack.Push(currentNode);
                        currentNode = currentNode.LeftNode;
                    }

                    
                    goLeft = false;
                }

                yield return currentNode.Value;

                if (currentNode.RightNode != null)
                {
                    treeStack.Push(currentNode.RightNode);
                    goLeft = true;
                }                              
            }
        }

        public IEnumerator<T> PostOrderTraversal()
        {
            TreeNode<T> previousNode = null;
            MyArrayStack<TreeNode<T>> postOrderStack = new MyArrayStack<TreeNode<T>>();

            if (this.rootNode == null)
            {
                throw new Exception("Empty Tree");
            }

            postOrderStack.Push(this.rootNode);

            while (postOrderStack.Count > 0)
            {
                TreeNode<T> currentNode = postOrderStack.Peek();

                if (previousNode == null || (previousNode.LeftNode != null && previousNode.LeftNode.Value.CompareTo(currentNode.Value) == 0 )||
                    (previousNode.RightNode != null && previousNode.RightNode.Value.CompareTo(currentNode.Value) == 0))
                {
                    if (currentNode.LeftNode != null)
                    {
                        postOrderStack.Push(currentNode.LeftNode);
                    }
                    else if (currentNode.RightNode != null)
                    {
                        postOrderStack.Push(currentNode.RightNode);
                    }
                }
                else if (currentNode.LeftNode != null && currentNode.LeftNode.Value.CompareTo(previousNode.Value) == 0)
                {
                    if (currentNode.RightNode != null)
                    {
                        postOrderStack.Push(currentNode.RightNode);
                    }
                }
                else
                {
                    yield return currentNode.Value;
                    postOrderStack.Pop();
                }

                previousNode = currentNode;
            }
        }
    }
}
