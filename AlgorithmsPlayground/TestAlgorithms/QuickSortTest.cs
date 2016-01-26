using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsWeek2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAlgorithms
{
    [TestClass]
    public class QuickSortTest
    {
        public QuickSortTest()
        {
            
        }

        /// <summary>
        /// Used to solve coursera algorithms course week 2
        /// </summary>
        [TestMethod]
        [DeploymentItem("10.txt")]
        [DeploymentItem("100.txt")]
        [DeploymentItem("1000.txt")]
        public void NumberOfComparisonsFirstElementTest()
        {
            QuickSort sort = new QuickSort();

            sort.ReadFromFile("10.txt");

            sort.Start();

            for (int index = 0; index < sort.Data.Length; index++)
            {
                Assert.AreEqual(index + 1, sort.Data[index]);
            }

            Assert.AreEqual(sort.TotalComparisons, 8921);
        }

        [TestMethod]
        [DeploymentItem("QuickSort.txt")]
        public void Assignment()
        {

        }
    }
}
