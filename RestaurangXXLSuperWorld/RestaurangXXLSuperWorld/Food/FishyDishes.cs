using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food {
    internal abstract class FishyDish : FoodItem {
        internal FishyDish(string Name) : base(Name) { }
    }
    internal class FishOne : FishyDish {
        public FishOne() : base("Spaghetti with pesto, crushed potato and salmon") {
            Price = 250;
            _cookingSteps = new string[] {
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
        }
        public override object Clone() {
            return new FishOne();
        }
    }
    internal class FishTwo : FishyDish {
        public FishTwo() : base("Crispy Homemade Fish Dicks with white sauce") {
            Price = 195;
            _cookingSteps = new string[] {
                "Förbereder Köksredskapen",
                "HACKA LÖKEN!!!!!!",
                "Filear Fisken",
                "Panerar Fisken",
                "Tillreder sås",
                "Smakar av såsen",
                "Kokar Potatis",
                "MOSAR POTATIS!!!!!",
                "Lägger upp maten på tallrik",
                "Final touches for favorite customer <3     8====D "
            };
        }
        public override object Clone() {
            return new FishTwo();
        }
    }
    internal class FishThree : FishyDish {
        public FishThree() : base("California Sushi Rolls") {
            Price = 300;
            _cookingSteps = new string[] {
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
        }
        public override object Clone() {
            return new FishThree();
        }
    }
}
