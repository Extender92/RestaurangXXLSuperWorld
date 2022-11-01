using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class FishyDish : FoodItem
    {
        internal FishyDish (string Name) : base (Name) { }
    }
    internal class FishOne : FishyDish
    {
        private readonly string[] _cookingSteps = {
            "Förbereder Köksredskapen",
            "HACKA LÖKEN!!!!!!",
            "Hackar Pinjenötter",
            "Hackar Basilika",
            "Kokar Pastan",
            "Tillreder laxen",
            "Kokar Potatis",
            "MOSAR POTATIS!!!!!",
            "Lägger upp maten på tallrik",
            "Lägger på en kvist Persilja"
        };
        public FishOne() : base("Spaghetti with pesto, crushed potato and salmon") {
            Prize = 250;
        }
        internal override string GetCurrentStep() { return _cookingSteps[_currentStep]; }
    }
    internal class FishTwo : FishyDish
    {
        public FishTwo() : base("Crispy Homemade Fish Dicks with white sauce") { }
    }
    internal class FishThree : FishyDish
    {
        public FishThree() : base("California Sushi Rolls") { }
    }
}
