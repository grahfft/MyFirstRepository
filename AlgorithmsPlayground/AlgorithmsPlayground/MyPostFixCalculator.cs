using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MyPostFixCalculator
    {
        private MyArrayStack<int> calculator = new MyArrayStack<int>();

        private MyLinkedListStack<int> listCalculator = new MyLinkedListStack<int>(); 

        public MyPostFixCalculator()
        {             
        }

        public int CalculateArrayPostFixNotation(string[] items)
        {
            int value = 0;
            this.calculator.Clear();

            for (int nextItem = 0; nextItem < items.Count(); nextItem++)
            {
                if (int.TryParse(items[nextItem], out value))
                {
                    this.calculator.Push(value);
                }
                else
                {
                    // In this example, the second number is the left side number and the first is the right side number
                    int first = this.calculator.Pop();
                    int second = this.calculator.Pop();

                    switch (items[nextItem])
                    {
                        case "+":
                            this.calculator.Push(second + first);
                            break;
                        case "-":
                            this.calculator.Push(second - first);
                            break;
                        case "/":
                            this.calculator.Push(second / first);
                            break;
                        case "*":
                            this.calculator.Push(second * first);
                            break;
                        default:
                            throw new Exception("Unknown character");
                    }
                }
            }

            if (this.calculator.Count > 1)
            {
                throw new Exception("All numbers were not used for calculations");
            }

            return this.calculator.Pop();
        }

        public int CalculateListPostFixNotation(string[] items)
        {
            int value = 0;
            this.calculator.Clear();

            for (int nextItem = 0; nextItem < items.Count(); nextItem++)
            {
                if (int.TryParse(items[nextItem], out value))
                {
                    this.listCalculator.Push(value);
                }
                else
                {
                    // In this example, the second number is the left side number and the first is the right side number
                    int first = this.listCalculator.Pop();
                    int second = this.listCalculator.Pop();

                    switch (items[nextItem])
                    {
                        case "+":
                            this.listCalculator.Push(second + first);
                            break;
                        case "-":
                            this.listCalculator.Push(second - first);
                            break;
                        case "/":
                            this.listCalculator.Push(second / first);
                            break;
                        case "*":
                            this.listCalculator.Push(second * first);
                            break;
                        default:
                            throw new Exception("Unknown character");
                    }
                }
            }

            if (this.listCalculator.Count > 1)
            {
                throw new Exception("All numbers were not used for calculations");
            }

            return this.listCalculator.Pop();
        }
    }
}
