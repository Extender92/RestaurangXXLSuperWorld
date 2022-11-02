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
            Price = 250;
        }
        internal override string GetCurrentStep() { return _cookingSteps[_currentStep]; }
    }
    internal class FishTwo : FishyDish
    {
        private readonly string[] _cookingSteps = {
            "Förbereder Köksredskapen",
            "HACKA LÖKEN!!!!!!",
            "Filear Fisken",
            "Panerar Fisken",
            "Tillreder sås",
            "Smakar av såsen",
            "Kokar Potatis",
            "MOSAR POTATIS!!!!!",
            "Lägger upp maten på tallrik",
            "Lägger på en hög bostongurka"
        };
        public FishTwo() : base("Crispy Homemade Fish Dicks with white sauce") {
            Price = 195;
        }
    }
    internal class FishThree : FishyDish
    {
        private readonly string[] _cookingSteps = {
            "Förbereder Köksredskapen",
            "HACKA LÖKEN!!!!!!",
            "Kokar ris",
            "Kokar ris",
            "Kokar ris",
            "Skivar tillbehör",
            "Rullar riset",
            "Rullar rullarna i sesamfrö",
            "Lägger upp maten på ett fat",
            "Lägger på en klick wasabi, majonnäs och avslutar med några drag med ketchupflaskan"
        };
        public FishThree() : base("California Sushi Rolls") {
            Price = 300;
        }
    }
}
