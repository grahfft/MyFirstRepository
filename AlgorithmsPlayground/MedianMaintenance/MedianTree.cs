using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance
{
    public class MedianTree
    {
        private MedianTreeNode rootNode;

        public MedianTree()
        {
            this.Count = 0;
        }

        public int Count
        {
            get;
            protected set;
        }

        public void Add(MedianTreeNode newNode)
        {
            this.Count++;

            if (this.rootNode == null)
            {
                this.rootNode = newNode;
                return;
            }

            MedianTreeNode nextNode = this.rootNode;

            while (nextNode != null)
            {
                if (nextNode.Value.CompareTo(newNode.Value) > 0)
                {
                    nextNode.LeftTreeCount++;

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
                    nextNode.RightTreeCount++;

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

        public int GetCurrentMedian()
        {
            int medianIndex = this.Count%2 == 0 ? this.Count/2 : (this.Count + 1)/2;
            int medianValue = 0;

            MedianTreeNode currentNode = this.rootNode;
            int currentRank = 0;

            while (currentNode != null)
            {
                if ((currentNode.LeftTreeCount + currentRank) >= medianIndex)
                {
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    if (currentNode.LeftTreeCount + currentRank + 1 == medianIndex)
                    {
                        medianValue = currentNode.Value;
                        currentNode = null;
                    }
                    else
                    {
                        currentRank = currentRank + currentNode.LeftTreeCount + 1;
                        currentNode = currentNode.RightNode; 
                    }
                }
            }

            return medianValue;
        }
    }
}
