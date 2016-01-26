using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedianMaintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAlgorithms
{
    [TestClass]
    public class MedianMaintenaceTest
    {
        [TestMethod]
        [DeploymentItem("Median.txt")]
        public void CalculateMedianModulo()
        {
            MedianMaintainer calc = new MedianMaintainer();

            int modulo = calc.GetMedianModulo("Median.txt");

            Assert.AreEqual(calc.TotalMedian, 25);
        }
    }
}
