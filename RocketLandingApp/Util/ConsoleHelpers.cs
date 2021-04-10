using System;

namespace RocketLandingApp.Util
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
