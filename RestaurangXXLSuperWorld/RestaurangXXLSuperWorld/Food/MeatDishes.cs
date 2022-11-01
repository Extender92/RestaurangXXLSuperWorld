using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class MeatDish : FoodItem
    {
        internal MeatDish (string Name) : base(Name) { }
    }

    internal class MeatOne : MeatDish
    {
        public MeatOne () : base("Crackling pork roast with pickled onions") { }
    }
    internal class MeatTwo : MeatDish
    {
        public MeatTwo() : base("Roast beef with red wine & banana shallots") { }
    }
    internal class MeatThree : MeatDish
    {
        public MeatThree() : base("T-bone steak with fries and béarnaise sauce") { }
    }
}
