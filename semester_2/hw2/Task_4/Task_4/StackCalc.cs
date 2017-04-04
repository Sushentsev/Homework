using System;

namespace Task_4
{
    /// <summary>
    /// Stack calculator.
    /// Works only with expression which can be unsigned integer.
    /// </summary>
    public class StackCalc
    {
        /// <summary>
        /// Stack for calculation
        /// </summary>
        private IStack stack;

        public StackCalc(IStack stack) => this.stack = stack;

        /// <summary>
        /// Calculating an expression
        /// </summary>
        /// <param name="expression">The expression for calculating</param>
        /// <returns>The result of calculating</returns>
        public int Calculation(string expression)
        {
            var expressionLength = expression.Length;
            var currentNumber = 0;
            var isLastNumber = true;

            if (expressionLength == 0)
            {
                return 0;
            }

            for (var i = 0; i < expressionLength; ++i)
            {
                if (expression[i] >= '0' && expression[i] <= '9')
                {
                    currentNumber = currentNumber * 10 + (int)Char.GetNumericValue(expression[i]);
                    isLastNumber = true;
                }
                else
                {
                    if (isLastNumber)
                    {
                        stack.Push(currentNumber);
                        currentNumber = 0;
                        isLastNumber = false;
                    }

                    if (expression[i] != ' ')
                    {
                        ExecuteOperating(expression[i]);
                    }
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// Executing an operating by an operator
        /// </summary>
        /// <param name="operation">Operator</param>
        private void ExecuteOperating(char operation)
        {
            var num1 = stack.Pop();
            var num2 = stack.Pop();

            switch (operation)
            {
                case '+':
                    stack.Push(num1 + num2);
                    break;
                case '-':
                    stack.Push(num2 - num1);
                    break;
                case '*':
                    stack.Push(num1 * num2);
                    break;
                case '/':
                    stack.Push(num2 / num1);
                    break;
                default:
                    break;
            }
        }
    }
}
