namespace RestaurangXXLSuperWorld
{
    internal class Program
    {
        static void Main()
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



            Printer(110, 20, 1, 1, restaurangChar, ConsoleColor.Red);
            Printer(5, 2, 3, 2, tableChar, ConsoleColor.Blue);

            Printer(10, 4, 50, 1, kitchenChar, ConsoleColor.Red);



            Console.ReadLine();

        }


        private static void Printer(int width, int height, int positionX, int positionY, char[] characters, ConsoleColor color)
        {
            int[] cursorPosition = { positionX, positionY };
            Console.ForegroundColor = color;

            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            Console.Write(characters[0]);
            for (int i = 0; i < width; i++)
            {
                Console.Write(characters[1]);
            }
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
            {
                Console.Write(characters[1]);
            }
            Console.Write(characters[5]);
        }
    }
}