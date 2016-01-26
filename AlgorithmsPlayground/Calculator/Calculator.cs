using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;

namespace Calculator
{
    public class Calculator
    {
        MyArrayStack<int> numbers = new MyArrayStack<int>(); 

        MyArrayStack<int> operations = new MyArrayStack<int>(); 

        public Calculator()
        {
            
        }

        public int CalculateExpression(string expression)
        {
            int total = 0;
            this.numbers.Clear();
            this.operations.Clear();

            if (!string.IsNullOrEmpty(expression))
            {
                char[] items = expression.ToCharArray();
                int value = 0;

                for (int index = 0; index < items.Count(); index++)
                {
                    if (int.TryParse(items[index].ToString(), out value))
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
            }

            return total;
        }
    }
}
