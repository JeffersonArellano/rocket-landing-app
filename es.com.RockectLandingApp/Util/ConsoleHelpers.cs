using System;

namespace es.com.RockectLandingApp.Util
{
    public static class ConsoleHelpers
    {
        /// <summary>
        /// Reads the console.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static string ReadConsole(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Writes the text.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="color">The color.</param>
        public static void WriteLine(string message, string color)
        {
            switch (color)
            {
                case "ok":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ResetColor();

                    break;
                case "warning":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message);
                    Console.ResetColor();
                    break;
                case "alert":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ResetColor();
                    break;

                default:
                    Console.ResetColor();
                    Console.WriteLine(message);
                    break;
            }
        }

        /// <summary>
        /// Confirmations the prompt.
        /// </summary>
        /// <param name="confirmText">The confirm text.</param>
        /// <returns></returns>
        public static bool ConfirmationPrompt(string confirmText)
        {
            Console.Write(confirmText + " [y/n] : ");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            return (response == ConsoleKey.Y);
        }
    }
}
