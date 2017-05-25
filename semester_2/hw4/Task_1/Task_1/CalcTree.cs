namespace Task_1
{
    /// <summary>
    /// Арифметическое дерево разбора
    /// </summary>
    public class CalcTree
    {
        /// <summary>
        /// Корень дерева
        /// </summary>
        private Node root;

        /// <summary>
        /// Вычисление значения дерева арифметического разбора
        /// </summary>
        /// <returns> Значение дерева разбора</returns>
        public int CalculateTree() => root.Calculate();

        /// <summary>
        /// Печать дерева в виде строки
        /// </summary>
        public string PrintTree() => root.Print();

        /// <summary>
        /// Построение арифметического дерева разбора
        /// </summary>
        /// <param name="expression">Выражение для разбора</param>
        public void Build(string expression) => root = BuildTree(expression);

        /// <summary>
        /// Построение арифметического дерева разбора
        /// </summary>
        /// <param name="expression">Выражение для разбора</param>
        /// <returns>Корень дерева</returns>
        private Node BuildTree(string expression)
        {
            if (expression[0] != '(')
            {
                return new Number(int.Parse(expression));
            }

            var operation = expression[1];
            var leftOperand = "";
            var rightOperand = "";

            if (expression[3] != '(')
            {
                var i = 3;

                while (expression[i] != ' ')
                {
                    leftOperand += expression[i];
                    ++i;
                }

                rightOperand = expression.Substring(i + 1, expression.Length - i - 2);
            }
            else
            {
                leftOperand = "(";
                var i = 4;
                var balance = 1;

                while (balance != 0)
                {
                    if (expression[i] == '(')
                    {
                        ++balance;
                    }

                    if (expression[i] == ')')
                    {
                        --balance;
                    }

                    leftOperand += expression[i];
                    ++i;
                }

                rightOperand = expression.Substring(i + 1, expression.Length - i - 2);
            }

            return GetOperationNode(operation, BuildTree(leftOperand), BuildTree(rightOperand));
        }

        /// <summary>
        /// Создание нового узла в зависимости от операции
        /// </summary>
        /// <param name="operation">Операция</param>
        /// <param name="leftChild">Левый узел</param>
        /// <param name="rightChild">Правый узел</param>
        /// <returns>Новый узел</returns>
        private Node GetOperationNode(char operation, Node leftChild, Node rightChild)
        {
            switch (operation)
            {
                case '+':
                    return new Plus(leftChild, rightChild);
                case '-':
                    return new Minus(leftChild, rightChild);
                case '*':
                    return new Multiplication(leftChild, rightChild);
                case '/':
                    return new Division(leftChild, rightChild);
                default:
                    return null;
            }
        }
    }
}
