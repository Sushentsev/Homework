namespace Task_1
{
    /// <summary>
    /// Узел-оператор
    /// </summary>
    public abstract class Operator : Node
    {
        /// <summary>
        /// Левый узел оператора
        /// </summary>
        protected Node leftChild;

        /// <summary>
        /// Правый узел оператора
        /// </summary>
        protected Node rightChild;

        /// <summary>
        /// Конструктор для класса
        /// </summary>
        /// <param name="leftChild">Левый узел</param>
        /// <param name="rightChild">Правый узел</param>
        public Operator(Node leftChild, Node rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        /// <summary>
        /// Вычисление дерева, начиная с данной вершины
        /// </summary>
        public override abstract int Calculate();

        /// <summary>
        /// Печать дерева в виде строки, начиная с данной вершины
        /// </summary>
        public override abstract string Print();
    }
}
