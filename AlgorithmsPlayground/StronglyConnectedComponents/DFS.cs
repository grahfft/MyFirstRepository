using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    public class DFS
    {
        private int leaderVertex = 0;

        private Stack<int> vertexStack = new Stack<int>(); 

        private Dictionary<int, int> visited; 

        public DFS()
        {
            this.visited = new Dictionary<int, int>();
            this.Sccs = new Dictionary<int, List<int>>();
        }

        public Dictionary<int, List<int>> Sccs
        {
            get; private set;
        } 

        public void SearchGraph(Dictionary<int, List<int>> graph, Dictionary<int,int> newOrder)
        {
            List<int> weightedOrder = newOrder.Keys.ToList();
            weightedOrder.Sort();
            weightedOrder.Reverse();

            foreach (int weight in weightedOrder)
            {
                this.leaderVertex = newOrder[weight];
                if (!this.visited.ContainsKey(this.leaderVertex))
                {
                    this.visited.Add(this.leaderVertex, this.leaderVertex);
                    this.vertexStack.Push(this.leaderVertex);

                    while (this.vertexStack.Count != 0)
                    {
                        int tail = this.vertexStack.Pop();
                       
                        List<int> edges;
                        if (!graph.TryGetValue(tail, out edges))
                        {
                            edges = new List<int>();
                        }

                        foreach (int head in edges)
                        {
                            if (!this.visited.ContainsKey(head))
                            {
                                this.vertexStack.Push(tail);
                                
                                this.visited.Add(head, this.leaderVertex);
                                this.vertexStack.Push(head);
                                break;
                            }
                        }
                    }
                }
            }

            foreach (int vertex in this.visited.Keys.ToList())
            {
                List<int> stronglyConnected;
                if (!this.Sccs.TryGetValue(this.visited[vertex], out stronglyConnected))
                {
                    stronglyConnected = new List<int>();
                    this.Sccs.Add(this.visited[vertex], stronglyConnected);
                }

                stronglyConnected.Add(vertex);
            }
        }
    }
}
