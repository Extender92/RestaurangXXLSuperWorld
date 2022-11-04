using RestaurangXXLSuperWorld.RestaurantLogic;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
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
        //Reference to the tables the Waiter is Serving
        private List<Table>? tables; 
        // Individual service quality representing the charisma and mood of the waiter 
        private double ServiceQuality;
        private int CollectedTip { get; set; }
        internal static int TotalCollectedTip { get; }


        private void SetQuality()
        {
            Random random = new();
            ServiceQuality = random.NextDouble() * (96 - 1) + 1;
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
                return queue.GetSuitableParty(size);
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
        internal void TakeOrderFromTable() {

        }
        internal void DeliverOrderToKitchen() {

        }
        internal void CleanTable() {

        }
        internal void Update() {
            // See if currently working (ie tablecleaning)

            // If available for work

            // See if any food can be delivered to table by "this"

            // See if any table wants to order food

            // See if any Party wants to leave (clean table and collect tip)

            // See if any Table can have guests
            Table? table = FindEmptyTable();
            Party<Customer>? party;

            if (table is not null)
            {
                party = GetSuitableParty(table.GetNumberOfChairs());
                if(party != null) {
                    table.SeatGuests(party);
                    GUI.DrawWaiterAtTable(table, this);

                }
                
            }
            else
            {
                GUI.DrawWaiterAtKitchen(kitchen, this);
            }
            

            // If can have guest, fetch a party fitting the slot

            // If cannot Work, Idle
        }
    }
}
