using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class VegetarianDish : FoodItem
    {
        internal VegetarianDish (string Name) : base(Name) { }
    }
    internal class VegOne : VegetarianDish
    {
        public VegOne() : base("Sweet & sour lentil dhal with grilled aubergine") { }
    }
    internal class VegTwo : VegetarianDish
    {
        public VegTwo() : base("Caesar Salad with crisp homemade croutons and a light caesar dressing") { }
    }
    internal class VegThree : VegetarianDish
    {
        public VegThree() : base("Aloo Gobi with Potatoes & Cauliflower") { }
    }
}
