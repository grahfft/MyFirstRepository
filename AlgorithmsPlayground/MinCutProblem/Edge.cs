using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCutProblem
{
    /// <summary>
    /// This is class is for my definitions only; acts the same as a tuple
    /// </summary>
    public class Edge
    {
        public Edge(int firstNode, int secondNode)
        {
            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
        }

        public int FirstNode
        {
            get; set;
        }

        public int SecondNode
        {
            get; set;
        }

        public override string ToString()
        {
            return string.Format("{0}_{1}", this.FirstNode, this.SecondNode);
        }
    }
}
