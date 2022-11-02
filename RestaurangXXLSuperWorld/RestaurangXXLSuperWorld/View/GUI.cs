using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.View
{
    internal class GUI
    {
        internal static void DrawRestaurant()
        {
            //char[,] characters = { { '╚', '╝', '╬', '═', '╩', '╠', '╣', '╦', '╔', '╗', '║' }, { '└', '┘', '┼', '─', '┴', '├', '┤', '┬', '┌', '┐', '│' } };
            //                          0    1    2    3    4    5    6    7    8    9    10       0    1    2    3    4    5    6    7    8    9    10

            //char[][] characters = { "╚╝╬═╩╠╣╦╔╗║".ToCharArray(), "└┘┼─┴├┤┬┌┐│".ToCharArray() };

            //int[] intsOne = { 8, 3, 9, 10, 0, 1 };
            //int[] intsTwo = { 7, 3, 7, 10, 0, 1 };
            //int[][] charSet = { intsOne, intsTwo };

            char[] restaurangChar = { '╔', '═', '╗', '║', '╚', '╝' };
            char[] kitchenChar = { '╦', '═', '╦', '║', '╚', '╝' };
            char[] tableChar = { '┌', '─', '┐', '│', '└', '┘' };

            RestaurantPrinter(51, 50, 1, 1, restaurangChar, ConsoleColor.Red);
            //RestaurantPrinter(10, 4, 50, 1, kitchenChar, ConsoleColor.Red);

            for (int i = 0; i < 5; i++)
            {
                RestaurantPrinter(18, 5, 4, (3 + 10 * i), tableChar, ConsoleColor.Blue);
                RestaurantPrinter(9, 5, 40, (3 + 10 * i), tableChar, ConsoleColor.Blue);
            }
        }

        private static void RestaurantPrinter(int width, int height, int positionX, int positionY, char[] characters, ConsoleColor color)
        {
            int[] cursorPosition = { positionX, positionY };
            Console.ForegroundColor = color;

            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            Console.Write(characters[0]);
            for (int i = 0; i < width; i++)
                Console.Write(characters[1]);
            Console.Write(characters[2]);

            for (int i = 0; i < height; i++)
            {
                cursorPosition[1] = i + positionY + 1;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
                Console.Write(characters[3]);
                cursorPosition[0] = width + positionX + 1;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
                Console.Write(characters[3]);
                cursorPosition[0] = positionX;
            }

            cursorPosition[1]++;
            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            Console.Write(characters[4]);
            for (int i = 0; i < width; i++)
                Console.Write(characters[1]);
            Console.Write(characters[5]);
        }
    }
}
