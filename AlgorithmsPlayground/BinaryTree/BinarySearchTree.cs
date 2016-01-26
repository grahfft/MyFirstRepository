using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public abstract class BinarySearchTree<T> where T: IComparable
    {
        protected TreeNode<T> rootNode;

        public T HeadValue
        {
            get
            {
                return this.rootNode.Value;
            }
        }

        public int Count
        {
            get; 
            protected set;
        }

        public virtual void Add(T value)
        {
            
        }

        public virtual TreeNode<T> FindNode(T value)
        {
            return null;
        } 

        public virtual void Remove(T value)
        {
            TreeNode<T> currentNode = this.FindNode(value);

            if (currentNode != null)
            {
                if (currentNode.RightNode == null)
                {
                    if (currentNode.LeftNode == null) // if a leaf, just null out the parent node
                    {
                        if (currentNode.ParentNode.LeftNode.Value.CompareTo(currentNode.Value) == 0)
                        {
                            currentNode.ParentNode.LeftNode = null;
                        }
                        else
                        {
                            currentNode.ParentNode.RightNode = null;
                        }
                    }
                    else // removal node has only a left node; direct parent node to point to this node
                    {
                        if (currentNode.ParentNode.LeftNode.Value.CompareTo(currentNode.Value) == 0)
                        {
                            currentNode.ParentNode.LeftNode = currentNode.LeftNode;
                        }
                        else
                        {
                            currentNode.ParentNode.RightNode = currentNode.LeftNode;
                        }
                    }
                }
                else // There is a right node handle right cases
                {
                    if (currentNode.RightNode.LeftNode == null) // Right node has no left node; shift everything up
                    {
                        if (currentNode.ParentNode.LeftNode.Value.CompareTo(currentNode.Value) == 0)
                        {
                            currentNode.ParentNode.LeftNode = currentNode.RightNode;
                        }
                        else
                        {
                            currentNode.ParentNode.RightNode = currentNode.RightNode;
                        }
                    }
                    else
                    {
                        // Left most child of the right node replces remove node value
                        TreeNode<T> childNode = currentNode.RightNode.LeftNode;
                        while (childNode.LeftNode != null)
                        {
                            childNode = childNode.LeftNode;
                        }

                        currentNode.Value = childNode.Value;
                        if (childNode.RightNode == null)
                        {
                            childNode.ParentNode.LeftNode = null;
                        }
                        else
                        {
                            childNode.ParentNode.LeftNode = childNode.RightNode;
                        }
                    }
                }
            }

            this.Count--;
        }
    }
}
