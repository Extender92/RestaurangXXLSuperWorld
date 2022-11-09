using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

        internal List<Person> chefs = new List<Person>();

        private List<Order> currentlyCooking = new List<Order>();

        private Queue<Order> cookingQueue = new Queue<Order>();
        private List<Order> deliveryList = new List<Order>();



        internal Kitchen(int positionX, int sizeX)
        {
            this.positionX = (positionX + sizeX + 1);
            populateChefs();
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
            var cooking = currentlyCooking;
            for (int i = 0; i < cooking.Count; i++)
            {
                if (currentlyCooking[i].Step == OrderSteps.Cooked)
                {
                    deliveryList.Add(currentlyCooking[i]);
                    cooking.Remove(currentlyCooking[i]);
                }
            }
            currentlyCooking = cooking;

            foreach (Chef chef in chefs) {
                if (chef.isIdle && (cookingQueue != null) && (cookingQueue.Any())) {
                    Order newOrder = cookingQueue.Dequeue();
                    currentlyCooking.Add(newOrder);
                    chef.currentlyCooking = newOrder;
                    chef.isIdle = false;
                } else {
                    chef.Cook();
                }
            }
        }

        private string KitchenActivities()
        {
            string activity = "";
            if (masterCustomer.Count >= 0)
                foreach (Customer customer in masterCustomer)
                    activity += $"{customer.FirstName} diskar\n";

            if (slaveCustomer.Count >= 0)
                foreach (Customer customer in slaveCustomer)
                    activity += $"{customer.FirstName} skalar potatis\n";

            return activity;
        }

        internal void AddToCookingQueue(Order order)
        {
            cookingQueue.Enqueue(order);
        }

        internal Order? TakeFromDeliveryList(Waiter waiter)
        {
            var deliveries = from delivery in deliveryList
                             where delivery.SingleWaiter == waiter
                             select delivery;
            if (deliveries is null || deliveries.Count() == 0)
                return null;
            var temp = deliveries.First();
            deliveryList.Remove(deliveries.First());
            return temp;
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
