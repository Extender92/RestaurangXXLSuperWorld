using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Chef : Person {
        private static double FlatSpecialityBonus = 0.4D;
        private double CompetenceQuality = new();
        internal Order? currentlyCooking;
        private List<string> specialities = new();
        private Menu menu = new();
        internal string doing = "idle";

        internal bool isIdle;

        public Chef() {
            isIdle = true;
            SetCompetence();
            SetSpecialities();
        }
        private void SetCompetence()
        {
            Random random = new();
            CompetenceQuality = random.NextDouble() * (96 - 50) + 50;
        }

        private void SetSpecialities()
        {
            Random random = new Random();
            FoodItem[] items = menu.GetSuitableDishes().ToArray();
            items = items.OrderBy(x => random.Next()).ToArray();
            for (int i = 0; i < 3; i++)
            {
                specialities.Add(items[i].Name);
            }
        }

        private void SetSpecialityFoodQuality()
        {
            foreach(FoodItem dishes in currentlyCooking._dishes)
                if (specialities.Contains(dishes.Name))
                    dishes.QualityLevel += FlatSpecialityBonus;
        }

        private void SetFoodQualityLevel()
        {
            double foodStressModiefier = 0.05D + Math.Pow(0.95, currentlyCooking._dishes.Count);

            foreach (FoodItem dish in currentlyCooking._dishes)
                dish.QualityLevel = foodStressModiefier * CompetenceQuality * 1.2;

            SetSpecialityFoodQuality();
        }

        internal void Cook()
        {
            if(currentlyCooking is null) { 
                return; 
            }
            doing = $"Kocken {this.FirstName} ";
            if(currentlyCooking._dishes.Count > 0) {
                doing += $"{currentlyCooking._dishes[0].GetCurrentStep()}";
            }
            foreach (FoodItem dish in currentlyCooking._dishes) {
                dish.Cook();
            }
            if (currentlyCooking._dishes[0].IsDone)
            {
                SetFoodQualityLevel();
                currentlyCooking.UpdateOrder();
                currentlyCooking = null;
                isIdle = true;
                doing = $"Kocken {this.FirstName} slipar köttyxan";
            }
        }
    }
}
