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
        private readonly bool anyTableForSmallParties = true;
        // Reference to Kitchen the Waiter is Delivering to
        private Kitchen? kitchen;
        // Turns cleaning table
        private RestaurantQueue<Party<Customer>>? queue;
        private RestaurantDoor? door;
        private int tableCleaning;
        private Table? _tableToClean;
        private Order? _delivery;
        private Party<Customer>? _toEntable;
        //Reference to the tables the Waiter is Serving
        private List<Table>? tables; 
        // Individual service quality representing the charisma and mood of the waiter 
        internal double ServiceQuality;
        internal int CollectedTip { get; set; }
        internal static int TotalCollectedTip { get; set; }
        internal string doing = "idle";

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
            _delivery = null;
            SetQuality();
        }

        internal void SetRestaurantQueue(RestaurantQueue<Party<Customer>> queue) 
        {
            this.queue = queue;
        }
        internal void SetDoor(RestaurantDoor door)
        {
            this.door = door;
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
        internal bool CanFindTableForFirstParty(bool largeTablesForSmallParties = false) {
            var firstParty = queue.Peek(1);
            if (firstParty is not null && firstParty.First() is not null) {
                var freeTables = from table in tables where table.IsFree()
                                 select table;
                foreach (Table table in freeTables) {
                    if(largeTablesForSmallParties == true) {
                        if (firstParty.First().Size() <= table.GetNumberOfChairs() && (largeTablesForSmallParties ? true : table.GetNumberOfChairs() - firstParty.First().Size() <= 1)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool GetFirstPartyInQueue(bool largeTablesForSmallParties = false) {
            Party<Customer>? firstParty;
            firstParty = queue.GetFirstInQueue();
            if (firstParty is not null) {
                _toEntable = firstParty;
                var freeTables = from table in tables where table.IsFree()
                                 select table;
                foreach (Table table in freeTables) {
                    if (_toEntable.Size() <= table.GetNumberOfChairs() && (largeTablesForSmallParties ? true : table.GetNumberOfChairs() - _toEntable.Size() <= 1)) {
                        table.SeatGuests(_toEntable);
                        return true;
                    }
                }
            }
            _toEntable = null;
            return false;
        }
        private void PlacePartyAtTable() {
            var seatedTables = from table in tables where table.IsPartySeated(_toEntable) == true
                               select table;
            if (seatedTables is null || seatedTables.Count() == 0) {
                queue.PutInFront(_toEntable);
                _toEntable = null;
            } else {
                Table firstTable = seatedTables.First();
                GUI.DrawWaiterAtTable(firstTable, this);
                firstTable.TablesOrder.AssignWaiter(this);
                PresentTodaysMenu(firstTable, _toEntable);
                _toEntable = null;
                //GUI.PartyTablePrinter(firstTable);
            }
        }

        internal void PresentTodaysMenu(Table table, Party<Customer> party) {
            Menu menu = table.TodaysMenu;
            List<FoodItem> orderDishes = new();
            foreach(Customer customer in party.getParty()) {
                orderDishes.Add(customer.GetDishToOrder(menu));
            }
            table.TablesOrder.OrderFood(orderDishes);
            table.TablesOrder.UpdateOrder();
            table.TablesOrder.StartOrder();
        }
        internal bool TakeOrderFromTable() 
        {
            var possibleOrders = from table in tables
                                 where table.TablesOrder.SingleWaiter == this && table.TablesOrder.Step == OrderSteps.ToBeOrdered
                                 select table.TablesOrder;
            if (possibleOrders is not null && possibleOrders.Count() > 0)
            {
                _delivery = possibleOrders.First();
                GUI.DrawWaiterAtTable(_delivery.Target, this);
                return true;
            }
            return false;
        }
        internal void DeliverOrderToKitchen(Order order) 
        {
            GUI.DrawWaiterAtKitchen(kitchen, this);
            kitchen.AddToCookingQueue(order);
            order.UpdateOrder();
            _delivery = null;
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
                foreach(Customer guest in _tableToClean.seatedGuests._members) {
                    Restaurant.totalCustomerSatisfaction += guest.Satisfaction;
                }
                _tableToClean.UnSeatGuests();
                GUI.DrawWaiterAtKitchen(kitchen, this);
                _tableToClean.Status = Table.TableStatus.Empty;
                return;
            }
            _tableToClean.Status = Table.TableStatus.Cleaning;
            GUI.DrawWaiterAtTable(_tableToClean, this);
        }

        private bool CollectPayment()
        {
            foreach (Table table in tables)
            {
                if (table.TablesOrder.Step == OrderSteps.Finished && table.TablesOrder.SingleWaiter == this)
                {
                    for (int i = 0; i < table.TablesOrder._dishes.Count; i++) {
                        if (!table.GetParty()[i].CanAfford(table.TablesOrder._dishes[i])) {
                            table.GetParty()[i].PayForFood(table.TablesOrder._dishes[i].Price);
                            //Set in slave service
                        } else {
                            // Total paid sum                                                    The cost of food ordered
                            int tipSum = table.GetParty()[i].PayForFood(table.TablesOrder._dishes[i].Price) - table.TablesOrder._dishes[i].Price;
                            CollectedTip += tipSum;
                            TotalCollectedTip += tipSum;
                        }
                        tableCleaning = 3;
                        _tableToClean = table;
                        table.TablesOrder.ResetOrder();
                        GUI.DrawWaiterAtTable(table, this);
                        GUI.PartyPrintTableCleaner(table);
                        return true;
                    }
                }
            }
            return false;
        }
        private bool isBusy() {
            return _delivery is not null || _toEntable is not null || tableCleaning > 0;
        }
        private void PerformDuties() {
            if (tableCleaning > 0) {
                CleanTable();
            } else if (_delivery is not null) {
                DeliverOrderToKitchen(_delivery);
            } else if (_toEntable is not null) {
                PlacePartyAtTable();
            }
        }

        internal void Update() {
            if (isBusy()) {
                PerformDuties();
            }
            else if (CollectPayment()) {

            } else if (DeliverOrderToTable()) {
            } else if (TakeOrderFromTable()) {

            } else if (CanFindTableForFirstParty()) {
                GetFirstPartyInQueue();
                GUI.DrawWaiterAtQueue(door, this);
            } else if (anyTableForSmallParties == true && CanFindTableForFirstParty(true)) {
                GetFirstPartyInQueue();
                GUI.DrawWaiterAtQueue(door, this);
            } 
            else {
                GUI.DrawWaiterAtKitchen(kitchen, this);
            }
        }
    }
}
