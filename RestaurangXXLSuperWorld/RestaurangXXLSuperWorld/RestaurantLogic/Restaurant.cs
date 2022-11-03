using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class Restaurant 
    {
        private char[] charSet = { '╔', '═', '╗', '║', '╚', '╝' };
        private ConsoleColor Color = ConsoleColor.Red; 

        private int positionX = 1;
        private int positionY = 1;

        private int sizeX = 51;
        private int sizeY = 50;

        private static int dailyCustomers = 80;

        private List<Person> waiters = new();
        private List<Table> tables = new();
        private RestaurantQueue<Party<Customer>> restaurantQueue = RestaurantQueue<Party<Customer>>.InitializeQueue(dailyCustomers);
        private List<Order> completedOrders = new();
        private Kitchen kitchen = new();

        private void PopulateWaiters()
        {
            for (int i = 0; i < 3; i++)
            {
                waiters.Add(new Waiter());
            }
        }
  
        internal void PopulateTables()
        {
            for (int i = 0; i < 5; i++)
            {
                tables.Add(new LargeTable(4, (3 + 10 * i)));
                tables.Add(new SmallTable(40, (3 + 10 * i)));

                

                //GUI.RestaurantPrinter(LargeTable, 5, 4, (3 + 10 * i), Table.charSet, ConsoleColor.Blue);
                //GUI.RestaurantPrinter(9, 5, 40, (3 + 10 * i), Table.charSet, ConsoleColor.Blue);

            }
            foreach (Table table in tables)
            {
                table.Draw();
            }
        }


        internal void Draw()
        {
            
            GUI.RestaurantPrinter(sizeX, sizeY, positionX, positionY, charSet, Color);
        }
    }
}
