using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class Edge
    {
        public Edge(int tail, string values)
        {
            int[] items = values.Split(',').Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => Convert.ToInt32(x)).ToArray();

            this.Tail = tail;
            this.Head = items[0];
            this.Weight = items[1];
        }

        public int Tail
        {
            get; private set;
        }

        public int Head
        {
            get; private set;
        }

        public int Weight
        {
            get; set;
        }
    }
}
