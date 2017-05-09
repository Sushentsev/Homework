using System;

namespace Task_1
{
    /// <summary>
    /// Класс стек на основе списка 
    /// </summary>
    /// <typeparam name="T">Параметр-тип</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// Элемент стека
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Указатель на следующий элемент стека
            /// </summary>
            public StackElement Next { get; private set; }

            /// <summary>
            /// Значение элемента стека
            /// </summary>
            public T Value { get; private set; }

            /// <summary>
            /// Конструктор для элемента стека
            /// </summary>
            /// <param name="next">Указатель на следующий элемент</param>
            /// <param name="value">Значение элемента</param>
            public StackElement(StackElement next, T value)
            {
                this.Next = next;
                this.Value = value;
            }
        }

        /// <summary>
        /// Длина стека
        /// </summary>
        private int length;

        /// <summary>
        /// Указатель на первый элемент стека
        /// </summary>
        private StackElement head;

        /// <summary>
        /// Добавление нового элемента в стек
        /// </summary>
        /// <param name="value">Значение для добавления</param>
        public void Push(T value)
        {
            var newElement = new StackElement(head, value);
            head = newElement;
            ++length;
        }

        /// <summary>
        /// Удаление элемента из стека
        /// </summary>
        /// <returns>Значение "головы" стека</returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new EmptyStackException("Стек пуст!");
            }

            var temp = head.Value;
            head = head.Next;
            --length;
            return temp;
        }

        /// <summary>
        /// Проверка стека на пустоту
        /// </summary>
        /// <returns>True, если стек пуст, иначе false</returns>
        public bool IsEmpty() => length == 0;

        /// <summary>
        /// Получение длины стека
        /// </summary>
        /// <returns>Длина стека</returns>
        public int GetLength() => length;
    }
}
