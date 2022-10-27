namespace RestaurangXXLSuperWorld
{
    internal class Program
    {
        static void Main()
        {
            char[][] characters = { "╚╝╬═╩╠╣╦╔╗║".ToCharArray(), "└┘┼─┴├┤┬┌┐│".ToCharArray() };

            int[] intsOne = { 8, 3, 9, 10, 0, 1 };
            int[] intsTwo = { 7, 3, 7, 10, 0, 1 };
            int[][] charSet = { intsOne, intsTwo };


            Printer(110, 20, 1, 1, charSet[0], characters[0], ConsoleColor.Red);
            Printer(5, 2, 3, 2, charSet[0], characters[1], ConsoleColor.Blue);

            Printer(10, 4, 50, 1, charSet[1], characters[0], ConsoleColor.Red);



            Console.ReadLine();

        }


        private static void Printer(int bredd, int höjd, int positionX, int positionY, int[] charSet, char[] characters, ConsoleColor color)
        {
            //char[,] characters = { { '╚', '╝', '╬', '═', '╩', '╠', '╣', '╦', '╔', '╗', '║' }, { '└', '┘', '┼', '─', '┴', '├', '┤', '┬', '┌', '┐', '│' } };
            //                          0    1    2    3    4    5    6    7    8    9    10       0    1    2    3    4    5    6    7    8    9    10

            int[] cursorPosition = { positionX, positionY };
            Console.ForegroundColor = color;

            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            Console.Write(characters[charSet[0]]);
            for (int i = 0; i < bredd; i++)
            {
                Console.Write(characters[charSet[1]]);
            }
            Console.Write(characters[charSet[2]]);

            for (int i = 0; i < höjd; i++)
            {
                cursorPosition[1] = i + positionY + 1;
                Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
                Console.Write(characters[charSet[3]]);
                cursorPosition[0] = bredd + positionX;
                Console.SetCursorPosition(cursorPosition[0] + 1, cursorPosition[1]);
                Console.Write(characters[charSet[3]]);
                cursorPosition[0] = positionX;
            }

            cursorPosition[1] = cursorPosition[1] + 1;
            Console.SetCursorPosition(cursorPosition[0], cursorPosition[1]);
            Console.Write(characters[charSet[4]]);
            for (int i = 0; i < bredd; i++)
            {
                Console.Write(characters[charSet[1]]);
            }
            Console.Write(characters[charSet[5]]);
        }
    }
}