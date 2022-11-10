using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.View
{
    internal class GUI
    {
        static int waitersAtKitchen = 0;
        internal static Restaurant restaurant;
        static int waitersAtQueue = 0;



        //internal static void DrawRestaurant()
        //{
        //    //char[,] characters = { { '╚', '╝', '╬', '═', '╩', '╠', '╣', '╦', '╔', '╗', '║' }, { '└', '┘', '┼', '─', '┴', '├', '┤', '┬', '┌', '┐', '│' } };
        //    //                          0    1    2    3    4    5    6    7    8    9    10       0    1    2    3    4    5    6    7    8    9    10

        //    //char[][] characters = { "╚╝╬═╩╠╣╦╔╗║".ToCharArray(), "└┘┼─┴├┤┬┌┐│".ToCharArray() };

        //    //int[] intsOne = { 8, 3, 9, 10, 0, 1 };
        //    //int[] intsTwo = { 7, 3, 7, 10, 0, 1 };
        //    //int[][] charSet = { intsOne, intsTwo };

        //    //char[] restaurangChar = { '╔', '═', '╗', '║', '╚', '╝' };
        //    char[] kitchenChar = { '╦', '═', '╦', '║', '╚', '╝' };
        //    char[] tableChar = { '┌', '─', '┐', '│', '└', '┘' };

        //    RestaurantPrinter(51, 50, 1, 1, restaurangChar, ConsoleColor.Red);
        //    //RestaurantPrinter(10, 4, 50, 1, kitchenChar, ConsoleColor.Red);

        //    for (int i = 0; i < 5; i++)
        //    {
        //        RestaurantPrinter(18, 5, 4, (3 + 10 * i), tableChar, ConsoleColor.Blue);
        //        RestaurantPrinter(9, 5, 40, (3 + 10 * i), tableChar, ConsoleColor.Blue);
        //    }
        //}
        /** <summary>
         * This method Prints rectangles with colored borders in the console
         * <param name="width">internal width of rectangle in cols</param>
         * <param name="height">internal height of rectangle in rows</param>
         * <param name="positionX">Column-Offset</param>
         * <param name="positionY">Row-offset</param>
         * <param name="characters">The charset to use</param>
         * <param name="color">The Color of the border</param>
         * <example>
         * For example:
         * <code>
         * RestaurantPrinter(18, 5, 4, 3, tableChar, ConsoleColor.Blue);
         * </code>
         * results in a blue rectangle of size 18*5, border exclusive, starting at position (4,3)
         * </example>
         * </summary>
        */
        internal static void RestaurantPrinter(int width, int height, int positionX, int positionY, char[] characters, ConsoleColor color)
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

        internal static void PartyTablePrinter(Table table)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (table.seatedGuests != null)
            {
                Console.SetCursorPosition((table.positionX + 1), (table.positionY + 3));
                Console.Write("Party:");
                Console.SetCursorPosition((table.positionX + 1), (table.positionY + 4));
                Console.Write(table.GetParty()[0].LastName + " " + (table.GetParty().Count - 1));

            }
            Console.SetCursorPosition((table.positionX + 1), (table.positionY + 5));
            Console.Write("Nöjdhet: " + String.Format("{0:0}", table.GetTableSatisfaction()));

            Console.SetCursorPosition((table.positionX + 1), (table.positionY + 1));
            Console.Write("Status: ");
            Console.SetCursorPosition((table.positionX + 1), (table.positionY + 2));
            Console.Write(table.Status);
        }

        internal static void PartyPrintTableCleaner(Table table)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.SetCursorPosition((table.positionX + 1), (table.positionY + i));
                Console.Write(new string(' ', 12));
            }
        }

        internal static void DrawWaiterAtTable(Table table, Waiter? waiter)
        {
            if (waiter == null)
            {
                Console.SetCursorPosition(table.positionX, (table.positionY - 1));
                Console.Write(new string(' ', 21));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(table.positionX, (table.positionY - 1));
                Console.Write("[Servitör: " + waiter.FirstName + "]");
            }            
        }
        internal static void DrawWaiterAtQueue(RestaurantDoor door, Waiter? waiter)
        {
            if (waiter == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(door.positionX - 21, (door.positionY + 2 + i));
                    Console.Write(new string(' ', 21));
                }
            }
            else
            {
                waitersAtQueue++;
                string waiterName = "[Servitör: " + waiter.FirstName + "]";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(door.positionX - waiterName.Length, (door.positionY + 1 + waitersAtQueue));
                Console.Write(waiterName);
            }
        }
        internal static void DrawWaiterAtKitchen(Kitchen kitchen, Waiter? waiter)
        {            
            if (waiter == null)
            {
                for (int i = 0; i < 3; i++)
                {                    
                    Console.SetCursorPosition(kitchen.positionX - 21, (kitchen.positionY + 2 + i));
                    Console.Write(new string(' ', 21));
                }                
            }
            else
            {
                waitersAtKitchen++;
                string waiterName = "[Servitör: " + waiter.FirstName + "]";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(kitchen.positionX - waiterName.Length, (kitchen.positionY + 1 + waitersAtKitchen));
                Console.Write(waiterName);
            }
        }
        internal static void PrintQueueAtDoor(RestaurantQueue<Party<Customer>>? queue, RestaurantDoor door) {
            if (queue is null) {
                for (int i = 0; i < 4; i++) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(door.positionX + 4, (door.positionY + i + 1));
                    Console.Write(new String(' ', 120));
                }
            } else {
                ImmutableList<Party<Customer>> parties = queue.Peek(Math.Min(6, queue.Count()));
                int xOffsets = 0;
                foreach (Party<Customer> party in parties) {
                    for (int i = 0; i < party.Size(); i++) {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(door.positionX + 4 + 21*xOffsets, (door.positionY + i + 1));
                        Console.Write(party._members[i].FirstName + " " + party._members[i].LastName);
                    }
                    xOffsets++;
                }
            }
        }
        internal static void PrintPartyLeaving(RestaurantQueue<Party<Customer>>? queue, RestaurantDoor door)
        {
            if (queue is null)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(door.positionX + 4, (door.positionY + i + 1));
                    Console.Write(new String(' ', 120));
                }
            }
            else
            {
                ImmutableList<Party<Customer>> parties = queue.Peek(Math.Min(6, queue.Count()));
                int xOffsets = 0;
                foreach (Party<Customer> party in parties)
                {
                    for (int i = 0; i < party.Size(); i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(door.positionX + 4 + 21 * xOffsets, (door.positionY + i + 1));
                        Console.Write(party._members[i].FirstName + " " + party._members[i].LastName);
                    }
                    xOffsets++;
                }
            }
        }
        internal static void PrintKitchenNews(Chef[] chefs, Kitchen kitchen)
        {
            string[] currentlyDoing = new string[chefs.Length + 1];
            currentlyDoing[0] = "Köket News:";
            for (int i = 1; i < currentlyDoing.Length; i++)
            {
                currentlyDoing[i] = chefs[i - 1].doing;
            }

            //DrawNews("Kitchen News", 85, 13, currentlyDoing);
            PrintNews(kitchen.positionX + kitchen.sizeX + 2, kitchen.positionY + 1, 80, currentlyDoing, ConsoleColor.Yellow, ConsoleColor.Blue);

            //Console.SetCursorPosition(kitchen.positionX + 1, kitchen.positionY + 1);
            //Console.Write("Köket:");
            //for (int i = 0; i < currentlyDoing.Length; i++)
            //{
            //    Console.SetCursorPosition(kitchen.positionX + kitchen.sizeX + 2, kitchen.positionY + i + 2);
            //    Console.Write(currentlyDoing[i]);
            //}
        }
        internal static void PrintWaitresNews(Waiter[] waiters)
        {
            string[] currentlyDoing = new string[4];
            (string, int)[] tips = restaurant.GetTipForEachWaiter();
            currentlyDoing[0] = "Servitör News:";
            for (int i = 1; i <= 3; i++)
            {
                currentlyDoing[i] = /*"Namn: " + */tips[i - 1].Item1 + ": " + tips[i - 1].Item2 + "kr i dricks. Aktivitet: "+ waiters[i - 1].doing;
            }
            PrintNews(85, 8, 76, currentlyDoing, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen);
        }

        internal static void PrintRestuarantInfo()
        {
            string[] news = new string[]
            {
                $"Restaurang Info:", $"Antal besökare just nu: {restaurant.GetNumberOfVisitors()}", $"Totalt antal besökare: {restaurant.GetNumberOfVisitors() + restaurant.GetTotalNumberOfVisitorsCompleted()}", $"Total dricks: {restaurant.GetTotalTip()}", $"Medel på kundnöjdhet: {String.Format("{0:0.##}", restaurant.GetAverageSatisfaction())}"
            };

            //DrawNews("Restaurang Info", 85, 1, news);
            PrintNews(85, 1, 32, news, ConsoleColor.DarkRed, ConsoleColor.DarkYellow);
        } 

        internal static void PrintNews(int positionX, int PositionY, int sizeX, string[] news, ConsoleColor borderColor, ConsoleColor textColor)
        {
            Console.ForegroundColor = borderColor;
            Console.SetCursorPosition(positionX, PositionY);
            Console.Write('┌' + new String('─', sizeX - 2) + '┐');
            for (int i = 0; i < news.Length; i++)
            {
                Console.SetCursorPosition(positionX, PositionY + 1 + i);
                Console.Write('│');

                Console.ForegroundColor = textColor;
                Console.Write(" " + news[i] + new String(' ', sizeX - news[i].Length - 3));

                Console.ForegroundColor = borderColor;
                Console.Write('│');
            }
            Console.SetCursorPosition(positionX, PositionY + news.Length + 1);
            Console.Write('└' + new String('─', sizeX - 2) + '┘');
        }

        //private static void DrawNews(string header, int fromLeft, int fromTop, string[] graphics)
        //{

        //    int width = 0;
        //    for (int i = 0; i < graphics.Length; i++)
        //    {
        //        if (graphics[i].Length > width)
        //        {
        //            width = graphics[i].Length;
        //        }
        //    }
        //    if (width < header.Length + 4)
        //    { width = header.Length + 4; };

        //    Console.SetCursorPosition(fromLeft, fromTop);
        //    if (header != "")
        //    {
        //        Console.Write('┌' + " ");
        //        Console.ForegroundColor = ConsoleColor.DarkGray;
        //        Console.Write(header);
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.Write(" " + new String('─', width - header.Length) + '┐');
        //    }
        //    else
        //    {
        //        Console.Write('┌' + new String('─', width + 2) + '┐');
        //    }
        //    Console.WriteLine();
        //    int maxRows = 0;
        //    for (int j = 0; j < graphics.Length; j++)
        //    {
        //        Console.SetCursorPosition(fromLeft, fromTop + j + 1);
        //        Console.WriteLine('│' + " " + graphics[j] + new String(' ', width - graphics[j].Length + 1) + '│');
        //        maxRows = j;
        //    }
        //    Console.SetCursorPosition(fromLeft, fromTop + maxRows + 2);
        //    Console.Write('└' + new String('─', width + 2) + '┘');

        //}
        internal static void ResetStatics()
        {
            waitersAtKitchen = 0;
            waitersAtQueue = 0; 
        }
    }
}
