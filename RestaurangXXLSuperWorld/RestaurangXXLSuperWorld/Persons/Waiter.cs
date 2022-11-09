using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.RestaurantLogic;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Waiter : Person {
        // Reference to Kitchen the Waiter is Delivering to
        private Kitchen? kitchen;
        // Turns cleaning table
        private RestaurantQueue<Party<Customer>>? queue;

        private int tableCleaning;
        private Table _tableToClean;
        //Reference to the tables the Waiter is Serving
        private List<Table>? tables; 
        // Individual service quality representing the charisma and mood of the waiter 
        internal double ServiceQuality;
        private int CollectedTip { get; set; }
        internal static int TotalCollectedTip { get; }


        private void SetQuality()
        {
            Random random = new();
            ServiceQuality = random.NextDouble() * (96 - 50) + 50;
        }
        private Table? FindEmptyTable()
        {
            //Loop list of tables, when finding one unoccupied return that instance
            foreach (Table table in tables)
            {
                if (table.IsFree()) return table;
            }
            return null;
            //If no table is found return null
        }

        private Party<Customer>? GetSuitableParty(int size)
        {
            if (queue is not null)
                return queue.GetSuitableParty(size, 1);
            else 
                return null;
        }


        public Waiter()
        {
            SetQuality();
        }

        internal void SetRestaurantQueue(RestaurantQueue<Party<Customer>> queue) 
        {
            this.queue = queue;
        }

        internal void SetKitchen(Kitchen kitchen) {
            this.kitchen = kitchen;
        }
        internal void SetTables(List<Table> tables) {
            this.tables = tables;
        }
        internal bool FindPartyForAvailableTable() {
            Table? table = FindEmptyTable();
            Party<Customer>? party;

            if (table is not null) {
                party = GetSuitableParty(table.GetNumberOfChairs());
                if (party is not null && party.Size() <= table.GetNumberOfChairs()) {
                    table.SeatGuests(party);
                    GUI.DrawWaiterAtTable(table, this);
                    PresentTodaysMenu(table, party);
                } else if (party is not null) {
                    queue.PutInFront(party);
                }

            } 
            else {
                return false;
            }
            return true;
        }
        internal bool FindTableForFirstPartyInQueue() {
            Party<Customer>? firstParty;
            firstParty = queue.GetFirstInQueue();
            if (firstParty is not null) {
                var freeTables = from table in tables where table.IsFree()
                                 select table;
                foreach (Table table in freeTables) {
                    if (firstParty.Size() <= table.GetNumberOfChairs() && table.GetNumberOfChairs() - firstParty.Size() <= 1) {
                        table.SeatGuests(firstParty);
                        GUI.DrawWaiterAtTable(table, this);
                        PresentTodaysMenu(table, firstParty);
                        return true;
                    }
                }
            }
            queue.PutInFront(firstParty);
            return false;
        }

        internal void PresentTodaysMenu(Table table, Party<Customer> party) {
            Menu menu = table.TodaysMenu;
            List<FoodItem> orderDishes = new();
            foreach(Customer customer in party.getParty()) {
                orderDishes.Add(customer.GetDishToOrder(menu));
            }
            table.TablesOrder.OrderFood(orderDishes);
            table.TablesOrder.UpdateOrder();
            table.TablesOrder.AssignWaiter(this);
            table.TablesOrder.StartOrder();
        }
        internal bool TakeOrderFromTable() 
        {
            var possibleOrders = from table in tables
                                 where table.TablesOrder.SingleWaiter == this && table.TablesOrder.Step == OrderSteps.ToBeOrdered
                                 select table.TablesOrder;
            if (possibleOrders is not null && possibleOrders.Count() > 0)
            {
                DeliverOrderToKitchen(possibleOrders);
                return true;
            }
            return false;
        }
        internal void DeliverOrderToKitchen(IEnumerable <Order> possibleOrders) 
        {
            Order newOrder = possibleOrders.First();
            kitchen.AddToCookingQueue(newOrder);
            newOrder.UpdateOrder();
            //newOrder.DebugPrintOrder(0 , 0);
        }

        internal bool DeliverOrderToTable()
        {
            Order? delivery = kitchen.TakeFromDeliveryList(this);
            if (delivery is null) 
                return false;
            delivery.UpdateOrder();
            delivery.DeliverOrder();
            GUI.DrawWaiterAtTable(delivery.Target, this);
            return true;
        }

        internal void CleanTable() 
        {
            tableCleaning--;
            if (tableCleaning == 0) {
                _tableToClean._timeSinceCleaned = 0;
                _tableToClean.UnSeatGuests();
                GUI.DrawWaiterAtKitchen(kitchen, this);
                return;
            }
            GUI.DrawWaiterAtTable(_tableToClean, this);
        }

        private bool FinnishOrder()
        {
            foreach (Table table in tables)
            {
                if (table.TablesOrder.Step == OrderSteps.Finished && table.TablesOrder.SingleWaiter == this)
                {
                    for (int i = 0; i < table.TablesOrder._dishes.Count; i++)
                    {
                        if (!table.GetParty()[i].CanAfford(table.TablesOrder._dishes[i])) {
                            table.GetParty()[i].PayForFood(table.TablesOrder._dishes[i].Price);
                            //Set in slave service
                        } else {
                            // Total paid sum                                                    The cost of food ordered
                            CollectedTip += table.GetParty()[i].PayForFood(table.TablesOrder._dishes[i].Price) - table.TablesOrder._dishes[i].Price;
                        }
                    }
                    tableCleaning = 3;
                    _tableToClean = table;
                    table.TablesOrder.ResetOrder();
                    GUI.DrawWaiterAtTable(table, this);
                    return true;
                }
            }
            return false;
        }

        internal void Update() {
              // See if currently working (ie tablecleaning)
            if (tableCleaning > 0)
            {
                CleanTable();
            }
            else if (FinnishOrder()) {

            }
              // If available for work

              // See if any cooked order can be delivered to customer
            else if (DeliverOrderToTable()) {
              // Try to take new orders
            } else if (TakeOrderFromTable()) {
                // Try to find a table for the first party in queue
            } else if (FindTableForFirstPartyInQueue()) {
                // // Try to find a any party for table
            } else if (FindPartyForAvailableTable()) {
              // Idling
            } else {
                GUI.DrawWaiterAtKitchen(kitchen, this);
            }
        }
    }
}
