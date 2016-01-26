using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    public class DirectedEdge
    {
        public DirectedEdge(int tail, int head)
        {
            this.TailVertex = tail;
            this.HeadVertex = head;
        }

        public int TailVertex
        {
            get; private set;
        }

        public int HeadVertex
        {
            get; private set;
        }
    }
}
