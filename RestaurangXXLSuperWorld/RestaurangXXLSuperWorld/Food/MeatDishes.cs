using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class MeatDishes : FoodItem
    {
        internal MeatDishes (string Name) : base(Name) { }
    }

    internal class MeatOne : MeatDishes
    {
        public MeatOne () : base("Crackling pork roast with pickled onions") { }
    }
    internal class MeatTwo : MeatDishes
    {
        public MeatTwo() : base("Roast beef with red wine & banana shallots") { }
    }
    internal class MeatThree : MeatDishes
    {
        public MeatThree() : base("T-bone steak with fries and béarnaise sauce") { }
    }
}
