using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class VegetarianDishes : FoodItem
    {
        internal VegetarianDishes (string Name) : base(Name) { }
    }
    internal class VegOne : VegetarianDishes
    {
        public VegOne() : base("Sweet & sour lentil dhal with grilled aubergine") { }
    }
    internal class VegTwo : VegetarianDishes
    {
        public VegTwo() : base("Caesar Salad with crisp homemade croutons and a light caesar dressing") { }
    }
    internal class VegThree : VegetarianDishes
    {
        public VegThree() : base("Aloo Gobi with Potatoes & Cauliflower") { }
    }
}
