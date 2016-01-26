using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestPath;

namespace TestAlgorithms
{
    [TestClass]
    public class ShortestPathTest
    {
        private const string fileName = "dijkstraData.txt";

        [TestMethod]
        [DeploymentItem(fileName)]
        public void ComputeShortestPath()
        {
            ShortestPathCalculator calc = new ShortestPathCalculator();

            int shortestPath = calc.ComputeShortestPath(1, 7, fileName);

            Assert.IsTrue(shortestPath == 2599);

            shortestPath = calc.ComputeShortestPath(1, 37, fileName);

            Assert.IsTrue(shortestPath == 2610);

            shortestPath = calc.ComputeShortestPath(1, 59, fileName);

            Assert.IsTrue(shortestPath == 2947);

            shortestPath = calc.ComputeShortestPath(1, 82, fileName);

            Assert.IsTrue(shortestPath > 0);

            shortestPath = calc.ComputeShortestPath(1, 99, fileName);

            Assert.IsTrue(shortestPath > 0);

            shortestPath = calc.ComputeShortestPath(1, 115, fileName);

            Assert.IsTrue(shortestPath > 0);

            shortestPath = calc.ComputeShortestPath(1, 133, fileName);

            Assert.IsTrue(shortestPath > 0);

            shortestPath = calc.ComputeShortestPath(1, 165, fileName);

            Assert.IsTrue(shortestPath > 0);

            shortestPath = calc.ComputeShortestPath(1, 188, fileName);

            Assert.IsTrue(shortestPath > 0);

            shortestPath = calc.ComputeShortestPath(1, 197, fileName);

            Assert.IsTrue(shortestPath > 0);
        }
    }
}
