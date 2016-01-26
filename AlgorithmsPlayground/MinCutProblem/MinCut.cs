using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCutProblem
{
	public class MinCut
	{
		public MinCut()
		{
			this.MinCutofGraph = Int32.MaxValue;
			this.Edges = new List<Edge>();
			this.Graph = new Dictionary<int, List<int>>();
		}

		public int MinCutofGraph
		{
			get; private set;
		}

		public Dictionary<int, List<int>> Graph
		{
			get; private set;
		} 

		public List<Edge> Edges
		{
			get; private set;
		} 

		public void FindMinCut(int seed, string fileName)
		{
			for (int index = 1; index < seed; index++)
			{
				Random rngesus = new Random(index);
				int highestValue = 0;

				this.ReadInput(fileName);

				while (this.Graph.Count > 2)
				{
					Edge edge = this.GetEdge(rngesus);
					this.UpdateEdges(edge.FirstNode, edge.SecondNode);
				}

				foreach (KeyValuePair<int, List<int>> data in this.Graph)
				{
				    if (data.Value.Count > highestValue)
				    {
				        highestValue = data.Value.Count;
				    }
				}

				if (this.MinCutofGraph > highestValue)
				{
					this.MinCutofGraph = highestValue;
				}
			}
		}

		private void ReadInput(string fileName)
		{
			this.Edges = new List<Edge>();
		    this.Graph = new Dictionary<int, List<int>>();

		    string[] number = File.ReadAllLines(@fileName);
		    this.Graph = new Dictionary<int,List<int>>();
	
		    for(int i = 0; i < number.Length; i++)
		    {
				int[] items = number[i].Split('\t').Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => Convert.ToInt32(x)).ToArray();
				this.Graph.Add(items[0],items.Skip(1).ToList<int>());
		    }       
		}

		private Edge GetEdge(Random rngesus)
		{
            int randomVertex = rngesus.Next(0, this.Graph.Count());
            var keyArray = this.Graph.Select(x => x.Key).ToArray();
            int item1 = keyArray[randomVertex]; //Get the main edge

            int randomEdgeVertex = rngesus.Next(0, this.Graph[item1].Count);
            int item2 = this.Graph[item1].ToArray()[randomEdgeVertex];
            return new Edge(item1, item2);
		}

		private void UpdateEdges(int parentVertex, int toBeMergedVertex)
		{
			var listOfDestinatioNodes = this.Graph[toBeMergedVertex];

            //Step 1 add toBeMerged edges to parentVertex edges
			foreach (var number in listOfDestinatioNodes)
			{
                this.Graph[parentVertex].Add(number);
			}

            //Step 2 replace all other instances of ToBeMerged with parentVertex
            foreach (int replace in listOfDestinatioNodes)
            {
                if (this.Graph[replace].Contains(toBeMergedVertex))
                {
                    int count = this.Graph[replace].RemoveAll(x => x == toBeMergedVertex);
                    for (int i = 0; i < count; i++)
                    {
                        this.Graph[replace].Add(parentVertex);
                    }
                }
            }

            //Step 3 remove self loops
		    this.RemoveSelfLoops();           

            //Step 4 update new edges and remove the absorbed vertex
			this.Graph.Remove(toBeMergedVertex);
		}

		private void RemoveSelfLoops()
		{
			foreach (KeyValuePair<int, List<int>> data in this.Graph)
			{
				int key = data.Key;
				this.Graph[key].RemoveAll(x => x == key);
			}
		}
	}
}
