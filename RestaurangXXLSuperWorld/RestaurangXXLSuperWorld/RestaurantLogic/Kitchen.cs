using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class Kitchen 
    {
        private char[] charSet = { '╦', '═', '╦', '║', '╚', '╝' };
        private ConsoleColor Color = ConsoleColor.Red;

        private int positionX = 50;
        private int positionY = 1;

        private int sizeX = 10;
        private int sizeY = 4;

        private List<Customer> slaveCustomer = new List<Customer>();
        private List<Customer> masterCustomer = new List<Customer>();

        private List<Person> chefs = new List<Person>();
        private List<Person> idleChefs = new List<Person>();

        private List<FoodItem> currentlyCooking = new List<FoodItem>();

        private Queue<Order> cookingQueue = new Queue<Order>();
        private Queue<Order> deliveryQueue = new Queue<Order>();



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
