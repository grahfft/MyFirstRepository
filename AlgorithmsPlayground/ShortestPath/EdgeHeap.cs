using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class EdgeHeap
    {
        //This has a lot of extra overhead; Sorting function despite hash underneath
        public SortedDictionary<int, List<Edge>> heap;

        public EdgeHeap()
        {
            this.heap = new SortedDictionary<int, List<Edge>>();
            this.Count = 0;
        }

        public int Count
        {
            get; private set;
        }

        public Edge RemoveMinEdge()
        {
            List<Edge> edges = this.heap.First().Value;
            Edge edge = edges.FirstOrDefault();

            if (edge != null)
            {
                this.heap.First().Value.Remove(edge);
                this.Count--;
            }
                
            return edge;
        }

        public void AddEdge(Edge edge)
        {
            List<Edge> edges;

            if (!this.heap.TryGetValue(edge.Weight, out edges))
            {
                edges = new List<Edge>();
                this.heap.Add(edge.Weight, edges);
            }

            edges.Add(edge);

            this.Count++;
        }

        public void RemoveEdges(int vertex)
        {
            //This is creating two extra lists that get cleaned up once the method ends and they go out of scope
            this.heap.Keys.ToList().ForEach(weight => this.heap[weight].ToList().ForEach(edge =>
            {
                if (edge.Head == vertex)
                {
                    this.heap[weight].Remove(edge);
                }
            }));

            //This is creating an extra list that gets cleaned up once the method ends and they go out of scope
            this.heap.Keys.ToList().ForEach(weight =>
            {
                if (this.heap[weight].Count == 0)
                {
                    this.heap.Remove(weight);
                }
            });                
        }
    }
}
