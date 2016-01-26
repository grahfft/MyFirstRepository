using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    public class ReverseDFS
    {
        private int finishOrder = 1;
 
        private Stack<int> vertexStack = new Stack<int>();
 
        private Dictionary<int, int> visited = new Dictionary<int, int>(); 

        public ReverseDFS()
        {
            this.OrderedVertices = new Dictionary<int, int>();
        }

        /// <summary>
        /// First int is the new order; second is vertex Id
        /// </summary>
        public Dictionary<int, int> OrderedVertices
        {
            get; private set;
        }

        public void SearchGraph(Dictionary<int, List<int>> reverseGraph)
        {
            List<int> vertices = reverseGraph.Keys.ToList();
            vertices.Sort();
            vertices.Reverse();

            foreach(int vertex in vertices)
            {                           
                if (!this.visited.ContainsKey(vertex))
                {
                    this.visited.Add(vertex, 0);                    
                    this.vertexStack.Push(vertex);

                    while (this.vertexStack.Count != 0)
                    {
                        int tail = this.vertexStack.Pop();
                        
                        List<int> edges;
                        if (!reverseGraph.TryGetValue(tail, out edges))
                        {
                            edges = new List<int>();
                        }

                        bool allVisited = true;

                        foreach (int head in edges)
                        {
                            if (!this.visited.ContainsKey(head))
                            {
                                allVisited = false;
                                this.vertexStack.Push(tail);
                                
                                this.visited.Add(head, 0);
                                

                                this.vertexStack.Push(head);
                                break;
                            }
                        }

                        if (allVisited)
                        {
                            this.visited[tail] = this.finishOrder++;
                        }
                    }
                }
            }

            foreach (int vertex in this.visited.Keys.ToList())
            {
                this.OrderedVertices.Add(this.visited[vertex], vertex);
            }
        }
    }
}
