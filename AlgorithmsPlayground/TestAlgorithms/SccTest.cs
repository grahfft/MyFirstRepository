using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StronglyConnectedComponents;

namespace TestAlgorithms
{
    [TestClass]
    public class SccTest
    {
        [TestMethod]
        [DeploymentItem("SCC.txt")]
        public void TestSccCalculator()
        {
            SSCcalculator calc = new SSCcalculator();

            List<int> scores = calc.FindSscsOfGraph("SCC.txt");

            Assert.AreEqual(scores.Count, 3);
        }
    }
}
