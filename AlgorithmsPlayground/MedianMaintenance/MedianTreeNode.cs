using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance
{
    public class MedianTreeNode
    {
        public MedianTreeNode(int value)
        {
            this.Value = value;
            this.RightTreeCount = 0;
            this.LeftTreeCount = 0;
        }

        public int Value
        {
            get; private set;
        }

        public MedianTreeNode ParentNode { get; set; }

        public MedianTreeNode LeftNode { get; set; }

        public MedianTreeNode RightNode { get; set; }

        public int RightTreeCount { get; set; }

        public int LeftTreeCount { get; set; }
    }
}
