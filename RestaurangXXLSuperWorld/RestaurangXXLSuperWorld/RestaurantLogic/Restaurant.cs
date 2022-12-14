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

        private int sizeX = 80;
        private int sizeY = 50;

        private static int dailyCustomers = 80;

        private List<Waiter> waiters = new();
        private List<Table> tables = new();
        private RestaurantQueue<Party<Customer>> restaurantQueue = RestaurantQueue<Party<Customer>>.InitializeQueue(dailyCustomers);
        internal static double totalCustomerSatisfaction;
        internal static int ServedVisitors { get; set; }
        private Kitchen kitchen;
        private RestaurantDoor door;

        internal Restaurant(int numberOfTables)
        {
            kitchen = new(positionX, sizeX);
            door = new(positionX, positionY, sizeX, sizeY);
            GUI.restaurant = this;
        }


        internal void PopulateWaiters()
        {
            for (int i = 0; i < 3; i++)
            {
                waiters.Add(new Waiter());
            }
            foreach (Waiter waiter in waiters)
            {
                waiter.SetKitchen(kitchen);
                waiter.SetTables(tables);
                waiter.SetRestaurantQueue(restaurantQueue);
                waiter.SetDoor(door);
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
        /**
         * Updates the restaurant one discrete timestep
         */
        internal void Update()
        {
            GUI.ResetStatics();
            foreach (Waiter waiter in waiters)
            {
                waiter.Update();
            }
            foreach (Table table in tables)
            {
                GUI.PartyPrintTableCleaner(table);
                table.Update();
                GUI.PartyTablePrinter(table);
            }
            kitchen.Update();
            //GUI.PrintKitchenNews(kitchen.chefs);
            //GUI.PrintWaitresNews(waiters);
            GUI.PrintQueueAtDoor(restaurantQueue, door);
            GUI.PrintPartyLeaving(door);
        }

        internal void Draw()
        {            
            GUI.RestaurantPrinter(sizeX, sizeY, positionX, positionY, charSet, Color);
            kitchen.Draw();
            door.Draw();

        }

        internal void PostUpdate() {
            foreach (Table table in tables) {
                GUI.DrawWaiterAtTable(table, null);
            }
            GUI.DrawWaiterAtKitchen(kitchen, null);
            GUI.DrawWaiterAtQueue(door, null);
            GUI.PrintQueueAtDoor(null, door);
        }

        internal void PrintTableOrders() {
            foreach(Table table in tables) {
                table.TablesOrder.DebugPrintOrder(0, 60);
            }
        }
        internal int GetNumberOfVisitors() {
            int visitors = 0;
            foreach (Table table in tables) {
                if (!table.IsFree()) {
                    visitors += table.seatedGuests.Size();
                }
            }
            return visitors;
        }
        internal int GetTotalNumberOfVisitorsCompleted() {
            return ServedVisitors;
        }
        internal int GetTotalTip() {
            return Waiter.TotalCollectedTip;
        }
        internal (string, int)[] GetTipForEachWaiter() {
            (string, int)[] values = new (string, int)[waiters.Count];
            for (int i = 0; i < waiters.Count; i++) {
                values[i] = (waiters[i].FirstName, waiters[i].CollectedTip);
            }
            return values;
        }
        internal double GetAverageSatisfaction() {
            return totalCustomerSatisfaction / ServedVisitors;
        }

        internal void PrintNews()
        {
            GUI.PrintRestuarantInfo();
            GUI.PrintWaitresNews(waiters.ToArray());
            GUI.PrintKitchenNews(kitchen.chefs.ToArray(), kitchen);
        }
    }
}
