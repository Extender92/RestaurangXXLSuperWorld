using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class Kitchen 
    {
        private char[] charSet = { '╠', '═', '╗', '║', '╠', '╝' };
        private ConsoleColor Color = ConsoleColor.Red;

        internal int positionX;
        internal int positionY = 21;

        internal int sizeX = 15;
        internal int sizeY = 9;

        private List<Customer> slaveCustomer = new List<Customer>();
        private List<Customer> masterCustomer = new List<Customer>();

        private List<Person> chefs = new List<Person>();
        private List<Person> idleChefs = new List<Person>();

        private List<FoodItem> currentlyCooking = new List<FoodItem>();

        private Queue<Order> cookingQueue = new Queue<Order>();
        private Queue<Order> deliveryQueue = new Queue<Order>();

        internal Kitchen(int positionX, int sizeX)
        {
            this.positionX = (positionX + sizeX + 1);
        }

        internal void Draw()
        {
            GUI.RestaurantPrinter(sizeX, sizeY, positionX, positionY, charSet, ConsoleColor.Red);
        }

        internal void Update()
        {
            KitchenActivities();
            CookingActivities();
        }

        private void CookingActivities()
        {
        }

        private void KitchenActivities()
        {
        }

        private void populateChefs()
        {
            for (int i = 0; i < 5; i++)
            {
                chefs.Add(new Chef());
            }
        }
    }
}
