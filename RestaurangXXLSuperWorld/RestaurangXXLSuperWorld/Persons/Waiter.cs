using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Waiter : Person {
        // Reference to Kitchen the Waiter is Delivering to
        private Kitchen kitchen;
        // Turns cleaning table
        private int tableCleaning;
        //Reference to the tables the Waiter is Serving
        private List<Table> tables; 
        // Individual service quality representing the charisma and mood of the waiter 
        private double ServiceQuality;
        private int CollectedTip { get; set; }
        internal static int TotalCollectedTip { get; }

        private void SetQuality()
        {
            Random random = new();
            ServiceQuality = random.NextDouble() * (96 - 1) + 1;
        }
        private Table FindEmptyTable(List<Table> tables)
        {
            //Loop list of tables, when finding one unoccupied return that instance
            return tables.First();
            //If no table is found return null
        }
        public Waiter()
        {
            SetQuality();
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
            // If can have guest, fetch a party fitting the slot

            // If cannot Work, Idle
        }
    }
}
