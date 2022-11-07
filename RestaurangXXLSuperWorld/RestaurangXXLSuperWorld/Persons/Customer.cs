using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Customer : Person {
        public int Money { get; set; }
        public double Satisfaction { get; private set; }
        public Customer() {
            Random random = new Random();
            Money = random.Next(120, 361);
        }
        private void FillWallet(int amount = 250) {
            Money += amount;
        }
        internal void ModifySatisfaction(double foodQuality, double tableQuality, double serviceQuality) {
            Satisfaction -= 1;
        }
        internal int GetTipAmount() {
            double modifier = 1.0D;

            return 0;
        }
        internal FoodItem GetDishToOrder(Menu menu) {
            Random random = new Random();
            FoodItem[] items = menu.GetSuitableDishes().ToArray();
            items = items.OrderBy(x => random.Next()).ToArray();
            foreach (FoodItem item in items) {
                if (DishStrikesFancy(item)) {
                    return menu.OrderOneOf(item);
                }
            }
            return GetRandomDish(menu);
        }

        private bool CanAfford(FoodItem item) {
            return item.Price < this.Money;
        }

        private bool DishStrikesFancy(FoodItem item) {
            return (item.Price * 1.2) < (this.Money);
        }
        private FoodItem GetRandomDish(Menu menu) {
            Random random = new Random();
            FoodItem[] items = menu.GetSuitableDishes().ToArray();
            return menu.OrderOneOf(items[random.Next(items.Length)]);
        }
    }
}
