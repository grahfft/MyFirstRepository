using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    public class SSCcalculator
    {
        private ReverseDFS reverse = new ReverseDFS();

        private DFS forward = new DFS();

        public SSCcalculator()
        {
            
        }

        public Dictionary<int, List<int>> Graph
        {
            get; private set;
        }

        public Dictionary<int, List<int>> ReversedDirection
        {
            get; private set;
        } 

        public List<int> FindSscsOfGraph(string graph)
        {
            this.ReadGraphFromFile(graph);

            this.reverse.SearchGraph(this.ReversedDirection);

            this.forward.SearchGraph(this.Graph, this.reverse.OrderedVertices);

            List<int> sscScores = this.forward.Sccs.Values.ToList().Select(ssc => ssc.Count).ToList();

            sscScores.Sort();
            sscScores.Reverse();

            return sscScores;
        }

        private void ReadGraphFromFile(string fileName)
        {
            this.Graph = new Dictionary<int, List<int>>();
            this.ReversedDirection = new Dictionary<int, List<int>>();

            string[] number = File.ReadAllLines(@fileName);

            foreach (string edge in number)
            {
                int[] items = edge.Split(' ').Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => Convert.ToInt32(x)).ToArray();

                List<int> headVertices;

                if (!this.Graph.TryGetValue(items[0], out headVertices))
                {
                    headVertices = new List<int>();
                    this.Graph.Add(items[0], headVertices);
                }

                headVertices.Add(items[1]);

                if (!this.ReversedDirection.TryGetValue(items[1], out headVertices))
                {
                    headVertices = new List<int>();
                    this.ReversedDirection.Add(items[1], headVertices);
                }

                headVertices.Add(items[0]);
            }       
        }
    }
}
