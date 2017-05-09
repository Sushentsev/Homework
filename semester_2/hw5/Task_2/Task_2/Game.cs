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
        public void OnDown(object sender, EventArgs args)
        {
            if (Console.CursorTop < Console.BufferHeight - 1)
            {
                ++Console.CursorTop;
            }
        }
    }
}
