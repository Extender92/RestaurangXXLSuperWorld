using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class FoodItem
    {
        public double QualityLevel { get; init; }
        public string Name { get; init; }
        public int Cost { get; init; }
        public int TimeToCook { get; init; }

        internal FoodItem(string name) { Name = name; }
    }
}
