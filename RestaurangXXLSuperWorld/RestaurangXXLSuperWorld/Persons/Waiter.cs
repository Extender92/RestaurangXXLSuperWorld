using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Waiter : Person {

        private double ServiceQuality;
        private int CollectedTip { get; set; }

        private void SetQuality()
        {
            Random random = new();
            ServiceQuality = random.NextDouble() * (96 - 1) + 1;
        }
        private Table FindEmptyTable(List<Table> tables)
        {
            return tables.First();
        }
        public Waiter()
        {
            SetQuality();
        }

    }
}
