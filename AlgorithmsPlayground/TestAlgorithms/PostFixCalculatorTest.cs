using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stack
{
    [TestClass]
    public class CalculatorTest
    {
        public CalculatorTest()
        {
            
        }

        [TestMethod]
        public void GoodCalculation()
        {
            int value = 0;
            string[] items = new[] {"5", "6", "7", "*", "+","1","-"};

            MyPostFixCalculator calc = new MyPostFixCalculator();

            value = calc.CalculateArrayPostFixNotation(items);

            Assert.AreEqual(value, 46);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BadCalculation()
        {
            int value = 0;
            string[] items = new[] { "5", "6", "8", "7", "*", "+", "1", "-" };

            MyPostFixCalculator calc = new MyPostFixCalculator();

            value = calc.CalculateArrayPostFixNotation(items);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExtraSign()
        {
            int value = 0;
            string[] items = new[] { "5", "6", "%", "7", "*", "+", "1", "-" };

            MyPostFixCalculator calc = new MyPostFixCalculator();

            value = calc.CalculateArrayPostFixNotation(items);
        }

        [TestMethod]
        public void GoodListCalculation()
        {
            int value = 0;
            string[] items = new[] { "5", "6", "7", "*", "+", "1", "-" };

            MyPostFixCalculator calc = new MyPostFixCalculator();

            value = calc.CalculateListPostFixNotation(items);

            Assert.AreEqual(value, 46);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BadListCalculation()
        {
            int value = 0;
            string[] items = new[] { "5", "6", "8", "7", "*", "+", "1", "-" };

            MyPostFixCalculator calc = new MyPostFixCalculator();

            value = calc.CalculateListPostFixNotation(items);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExtraSignList()
        {
            int value = 0;
            string[] items = new[] { "5", "6", "%", "7", "*", "+", "1", "-" };

            MyPostFixCalculator calc = new MyPostFixCalculator();

            value = calc.CalculateListPostFixNotation(items);
        }
    }
}
