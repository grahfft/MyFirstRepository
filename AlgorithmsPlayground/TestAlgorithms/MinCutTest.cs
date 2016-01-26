using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinCutProblem;

namespace TestAlgorithms
{
    [TestClass]
    public class MinCutTest
    {
        /// <summary>
        /// This is used to find the value for Coursera Course
        /// </summary>
        [TestMethod]
        [DeploymentItem("kargerMinCut.txt")]
        public void CalculateMinCut()
        {
            MinCut minCut = new MinCut();

            minCut.FindMinCut(10000, "kargerMinCut.txt");

            Assert.AreEqual(minCut.MinCutofGraph, 17);
        }
    }
}
