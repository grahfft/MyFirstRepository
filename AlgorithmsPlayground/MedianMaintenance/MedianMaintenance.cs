using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace MedianMaintenance
{
    public class MedianMaintainer
    {
        private MedianTree tree;

        public MedianMaintainer()
        {
            this.TotalMedian = 0;
        }

        public int TotalMedian
        {
            get; private set;
        }

        public int GetMedianModulo(string fileName)
        {
            this.TotalMedian = 0;
            this.tree = new MedianTree();

            string[]  stream = File.ReadAllLines(@fileName);

            foreach (string newValue in stream)
            {
                int newIntValue = Convert.ToInt32(newValue);

                MedianTreeNode newNode = new MedianTreeNode(newIntValue);
                this.tree.Add(newNode);

                int currentMedian = this.tree.GetCurrentMedian();
                this.TotalMedian = TotalMedian + currentMedian;
            }

            return this.TotalMedian%this.tree.Count;
        }
    }
}
