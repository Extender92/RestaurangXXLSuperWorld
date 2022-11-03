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

        private List<Person> waiters;
        private List<Table> tables;
        private RestaurantQueue<Party<Customer>> restaurantQueue;
        private List<Order> completedOrders;
        private Kitchen kitchen;

        private void PopulateWaiters()
        {
            for (int i = 0; i < 3; i++)
            {
                waiters.Add(new Waiter());
            }
        }
  
        private void PopulateTables()
        {
            for (int i = 0; i < 5; i++)
            {
                tables.Add(new LargeTable());
                tables.Add(new SmallTable());
            }
        }








        private void draw()
        {
            GUI.RestaurantPrinter(sizeX, sizeY, positionX, positionY, charSet, Color);
        }


    }
}
