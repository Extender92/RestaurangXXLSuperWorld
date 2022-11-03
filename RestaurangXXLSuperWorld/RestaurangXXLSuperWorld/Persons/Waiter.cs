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

    }
}
