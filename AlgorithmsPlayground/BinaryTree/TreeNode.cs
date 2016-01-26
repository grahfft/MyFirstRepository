using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeNode<T> : IComparable where T: IComparable
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public TreeNode<T> LeftNode { get; set; }
 
        public TreeNode<T> RightNode { get; set; } 

        public TreeNode<T> ParentNode { get; set; } 

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }
    }
}
