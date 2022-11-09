﻿using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.View
{
    internal class GUI
    {
        static int waitersAtKitchen = 0;

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
            Console.SetCursorPosition((table.positionX + 1), (table.positionY + 3));
            Console.Write(table.GetParty()[0].LastName + " " + (table.GetParty().Count - 1));
                       
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
        internal static void ResetStatics()
        {
            waitersAtKitchen = 0;
            waitersAtQueue = 0; 
        }
    }
}
