using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAlgorithms
{
    [TestClass]
    public class CalculatorTest
    {
        public CalculatorTest()
        {
            
        }

        [TestMethod]
        public void OnlyNumberExpression()
        {
            Calculator.Calculator calculator = new Calculator.Calculator();

            calculator.CalculateExpression("8675309 + 7");
        }
    }
}
