using System;
using System.Diagnostics;

namespace MyDCInputOutput
{
    public class Output
    {
        /// <summary>
        /// Сообщает об ошибках
        /// </summary>
        /// <param name="error">Печатаемая ошибка</param>
        public static void Error(string error) => Message($"Ошибка: {error}!\n", ConsoleColor.Red);

        /// <summary>
        /// Печатаем красивые сообщения пользователю
        /// </summary>
        /// <param name="message">Сообщение на печать</param>
        /// <param name="color">Цвет печать</param>
        public static void Message(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Печатает строки
        /// </summary>
        /// <param name="color">Цвет печати</param>
        /// <param name="messages">Массив строк</param>
        public static void Message(ConsoleColor color, params string[] messages)
        {
            Console.ForegroundColor = color;
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Печатает разделители
        /// </summary>
        public static void Separator() => Message("<===><=====><========><============>\n\n", ConsoleColor.DarkGreen);
    }
}
