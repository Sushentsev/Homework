namespace Task_1
{
    /// <summary>
    /// Абстрактный класс для узла дерева
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Печать дерева в виде строки, начиная с дерева
        /// </summary>
        public abstract string Print();

        /// <summary>
        /// Подсчитать дерево, начиная с вершины
        /// </summary>
        public abstract int Calculate();
    }
}
