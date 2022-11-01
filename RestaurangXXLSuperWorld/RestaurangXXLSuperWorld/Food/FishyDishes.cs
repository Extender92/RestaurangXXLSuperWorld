using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class FishyDishes : FoodItem
    {
        internal FishyDishes (string Name) : base (Name) { }
    }
    internal class FishOne : FishyDishes
    {
        public FishOne() : base("Spaghetti with pesto, crushed potato and salmon") { }
    }
    internal class FishTwo : FishyDishes
    {
        public FishTwo() : base("Crispy Homemade Fish Dicks with white sauce") { }
    }
    internal class FishThree : FishyDishes
    {
        public FishThree() : base("California Sushi Rolls") { }
    }
}
