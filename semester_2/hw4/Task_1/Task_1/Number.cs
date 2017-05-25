namespace Task_1
{
    /// <summary>
    /// Узел-число
    /// </summary>
    public class Number : Node
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        private int value;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="value">Значение узла</param>
        public Number(int value) => this.value = value;

        /// <summary>
        /// Считает значение узла
        /// </summary>
        /// <returns>Значение узла</returns>
        public override int Calculate() => value;

        /// <summary>
        /// Печать узла в строку
        /// </summary>
        /// <returns>Значение узла в виде строки</returns>
        public override string Print() => value.ToString();
    }
}
