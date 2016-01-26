using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoSum;

namespace TestAlgorithms
{
    [TestClass]
    public class TestTwoSum
    {
        private const string Filename = "algo1-programming_prob-2sum.txt";

        [TestMethod]
        [DeploymentItem(Filename)]
        public void TwoSumTest()
        {
            TwoSumCalculator calc = new TwoSumCalculator();

            calc.CalculateTwoSums(Filename, -10000, 10000);

            Task newTask = calc.Complete.Task;
            newTask.Wait();

            Assert.AreEqual(calc.Count, 427);
        }
    }
}
