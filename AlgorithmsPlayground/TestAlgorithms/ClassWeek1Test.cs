using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsClassWeek1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAlgorithms
{
    [TestClass]
    public class ClassWeek1Test
    {
        [TestMethod]
        public void BasicTest()
        {
            int[] testArray = new[] {1, 3, 5, 2, 4, 6};

            CountInversions calc = new CountInversions();

            SortedArray inversions = calc.CalculateInversions(testArray);

            Assert.AreEqual(inversions.Inversions, 3);
        }

        [TestMethod]
        public void MoreComplexTest()
        {
            int[] testArray = new[] { 1, 100, 3, 5, 2, 4, 6, 7 };

            CountInversions calc = new CountInversions();

            SortedArray inversions = calc.CalculateInversions(testArray);

            Assert.AreEqual(inversions.Inversions, 9);
        }

        [TestMethod]
        public void EvenMoreComplexTest()
        {
            int[] testArray = new[] {1001, 1, 100, 3, 5, 2, 4, 6, 7 };

            CountInversions calc = new CountInversions();

            SortedArray inversions = calc.CalculateInversions(testArray);

            Assert.AreEqual(inversions.Inversions, 17);
        }

        [TestMethod]
        public void DoMyHomework()
        {
            CountInversions calc = new CountInversions();

            SortedArray inversions = calc.WeekOneAssignment();

            Assert.IsTrue(inversions.Inversions > 0);
        }
    }
}
