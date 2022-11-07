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
        public MeatOne () : base("Crackling pork roast with pickled onions") {
            Price = 185;
            _cookingSteps = new string[] {
                "Förbereder Köksredskap",
                "HACKA LÖKEN!!!!!!",
                "Kryddar fläskstek",
                "Picklar lök",
                "Tar ut fläskstek ur ugn",
                "Lagar gräddsås",
                "Kokar Potatis",
                "MOSAR POTATIS!!!!!",
                "Lägger upp på planka",
                "Lägger på picklad lök"
            };
        }
    }
    internal class MeatTwo : MeatDish
    {
        public MeatTwo() : base("Roast beef with red wine & banana shallots") {
            Price = 210;
            _cookingSteps = new string[] {
                "Förbereder Köksredskapen",
                "HACKA LÖKEN!!!!!!",
                "Bryner Rostbiff",
                "Lägger rostbiff i ugn",
                "Korkar upp vin",
                "Smakar av vin",
                "Rostar lök",
                "Dricker lite mer vin",
                "Lägger upp rostbiff på trancherbräda",
                "Häller upp några glas vin"
            };
        }
    }
    internal class MeatThree : MeatDish
    {
        public MeatThree() : base("T-bone steak with fries and béarnaise sauce") {
            Price = 250;
            _cookingSteps = new string[] {
                "Förbereder Köksredskapen",
                "HACKA LÖKEN!!!!!!",
                "Skivar kött",
                "Grillar kött",
                "Kokar potatis",
                "Skär potatis i stavar",
                "Friterar potatis",
                "Gör sauce bearnaise",
                "Lägger upp mat på varm metallbricka",
                "Lägger på persilja och dragon"
            };
        }
    }
}
