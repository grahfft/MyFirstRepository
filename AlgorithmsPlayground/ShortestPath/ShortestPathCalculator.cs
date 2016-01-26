using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class ShortestPathCalculator
    {
        private Dictionary<int, int> vertexWeights;

        private const int MaxPathScore = 1000000;

        private EdgeHeap myHeap;

        public ShortestPathCalculator()
        {
            this.vertexWeights = new Dictionary<int, int>();
            this.myHeap = new EdgeHeap();
        }

        public Dictionary<int, List<Edge>> Graph
        {
            get; private set;
        }

        public int ComputeShortestPath(int startVertex, int endVertex, string fileName)
        {
            this.ReadFromFile(fileName);

            if (endVertex == startVertex)
            {
                return 0;
            }

            int currentVertex = startVertex; //For the sake of the assignement this is marked 1;
            Edge currentEdge = null;

            this.vertexWeights.Add(currentVertex, 0);

            do
            {
                List<Edge> currentEdges;
                if (!this.Graph.TryGetValue(currentVertex, out currentEdges))
                {
                    currentEdges = new List<Edge>();
                }

                currentEdges.ForEach(edge =>
                {
                    if (!this.vertexWeights.ContainsKey(edge.Head)) //Only add new head vertices
                    {
                        Edge copyEdge = edge;

                        copyEdge.Weight = this.vertexWeights[edge.Tail] + edge.Weight;
                        //Add to heap
                        this.myHeap.AddEdge(copyEdge);
                    }
                });

                //Get min edge
                currentEdge = this.myHeap.RemoveMinEdge();

                //Remove edges that point to new vertex; don't need it anymore its already consumed
                this.myHeap.RemoveEdges(currentEdge.Head);

                //update current head and current edge
                if (!this.vertexWeights.ContainsKey(currentEdge.Head))
                {
                    this.vertexWeights.Add(currentEdge.Head, currentEdge.Weight);
                }
                this.vertexWeights[currentEdge.Head] = currentEdge.Weight;

                currentVertex = currentEdge.Head;

            } while (currentVertex != endVertex || this.myHeap.Count == 0);

            return this.vertexWeights.ContainsKey(endVertex) ? this.vertexWeights[endVertex] : MaxPathScore;
        }

        private void ReadFromFile(string fileName)
        {
            this.Graph = new Dictionary<int, List<Edge>>();
            this.vertexWeights = new Dictionary<int, int>();

            string[] edges = File.ReadAllLines(@fileName);

            foreach (string edge in edges)
            {
                string[] items = edge.Split('\t').Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => x).ToArray();

                List<Edge> currentEdges;
                int tailVertex = Convert.ToInt32(items[0]);
                if (!this.Graph.TryGetValue(tailVertex, out currentEdges))
                {
                    currentEdges = new List<Edge>();
                    this.Graph.Add(tailVertex, currentEdges);
                }

                for(int index = 1; index < items.Count(); index++)
                {
                    currentEdges.Add(new Edge(tailVertex, items[index]));
                }
            }
        }
    }
}
