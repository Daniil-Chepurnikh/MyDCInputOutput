using System;
using System.Diagnostics;

namespace MyDCInputOutputConsole
{
    /// <summary>
    /// Класс ввода данных
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Читает одну строку пользовательского ввода
        /// </summary>
        /// <returns></returns>
        public static string? Data()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var choice = Console.ReadLine();
            Console.ResetColor();
            return choice;
        }

        /// <summary>
        /// Красиво печатает меню и возвращает выбор
        /// </summary>
        /// <param name="menu">Печатаемое меню</param>
        /// <param name="message">Заглавие к меню</param>
        /// <returns>Номер выбранного пункта меню</returns>
        public static uint MenuAction(string[] menu, string message)
        {
            uint action;
            string? choice;
            do
            {
                bool isCorrectAction;
                do
                {
                    Output.Message(message, ConsoleColor.DarkYellow);
                    for (int i = 0; i < menu.Length; i++)
                    {
                        Output.Message($" {i + 1}.  {menu[i]}\n\n", ConsoleColor.White);
                    }

                    Output.Message("Введите номер выбранного действия:  ", ConsoleColor.White);
                    isCorrectAction = uint.TryParse(Input.Data(), out action);

                    if (action > menu.Length || action == 0)
                    {
                        Output.Error("Нераспознанная команда! Проверьте корректность ввода");
                        isCorrectAction = false;
                    }
                } while (!isCorrectAction);

                Output.Message($"Вы выбрали дейстиве: {menu[action - 1]}\n", ConsoleColor.White);
                Output.Message("Вы уверены в своём выборе? Если уверены, напишите ДА(в любом регистре), любой другой ввод будет воспринят как НЕТ:  ", ConsoleColor.White);
                choice = Input.Data();

            } while (!string.Equals(choice, "Да", StringComparison.OrdinalIgnoreCase));
            return action;
        }

        /// <summary>
        /// Читает целое число в пределах типа int
        /// </summary>
        /// <param name="message">Приглашенние к вводу числа</param>
        /// <param name="error">Сообщение об ошибке</param>
        /// <returns></returns>
        public static int IntNumber(string message, string error)
        {
            bool isCorrect;
            int number;
            do
            {
                Output.Message(message, ConsoleColor.White);
                isCorrect = int.TryParse(Data(), out number);

                if (!isCorrect)
                    Output.Error(error);

            } while (!isCorrect);
            return number;
        }

    }
}
