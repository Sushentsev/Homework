using System;

namespace Task_2
{
    /// <summary>
    /// Бизнес-логика игры
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Смещение курсора влева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnLeft(object sender, EventArgs args)
        {
            if (Console.CursorLeft > 0)
            {
                --Console.CursorLeft;
            }
        }

        /// <summary>
        /// Смещение курсора вправо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft < Console.BufferWidth - 1)
            {
                ++Console.CursorLeft;
            }
        }

        /// <summary>
        /// Смещение курсора вверх
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnUp(object sender, EventArgs args)
        {
            if (Console.CursorTop > 0)
            {
                --Console.CursorTop;
            }
        }

        /// <summary>
        /// Смещение курсора вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDown(object sender, EventArgs args) => ++Console.CursorTop; 
    }
}
