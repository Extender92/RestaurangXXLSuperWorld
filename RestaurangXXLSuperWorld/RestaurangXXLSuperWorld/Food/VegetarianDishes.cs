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
        public VegOne() : base("Sweet & sour lentil dhal with grilled aubergine") {
            Price = 140;
            _cookingSteps = new string[] {
                "Förbereder Köksredskapen",
                "HACKA LÖKEN!!!!!!",
                "Skivar Aubergine",
                "Kokar linser",
                "Kryddar linser",
                "Grillar aubergine",
                "Grillar naan",
                "Vitlökar naan",
                "Lägger upp dhaal i en skål",
                "Lägger naan och grillad aubergine på sidofat"
            };
        }
        public override object Clone() {
            return new VegOne();
        }
    }
    internal class VegTwo : VegetarianDish
    {
        public VegTwo() : base("Caesar Salad with crisp homemade croutons and a light caesar dressing") {
            Price = 180;
            _cookingSteps = new string[] {
                "Förbereder Köksredskapen",
                "HACKA LÖKEN!!!!!!",
                "Lagar krutonger",
                "Hackar sardeller",
                "Steker Kyckling",
                "Steker bacon",
                "Gör dressing",
                "Hackar ingredienser och bygger sallad",
                "Lägger upp sallad, häller över dressing",
                "River parmesan över sallad och strör på krutonger"
            };
        }
        public override object Clone() {
            return new VegTwo();
        }
    }
    internal class VegThree : VegetarianDish
    {
        public VegThree() : base("Aloo Gobi with Potatoes & Cauliflower") {
            Price = 120;
            _cookingSteps = new string[] {
                "Förbereder Köksredskapen",
                "HACKA LÖKEN!!!!!!",
                "Hackar potatis i små bitar",
                "Skär blomkål i buketter",
                "Hackar tomat",
                "Fräser lök",
                "Steker lök, blomkål och potatis",
                "Kryddar och tillsätter tomat",
                "Lägger upp på ett stort fat",
                "Beundrar sitt mästerverk"
            };
        }
        public override object Clone() {
            return new VegThree();
        }
    }
}
