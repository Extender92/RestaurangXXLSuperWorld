using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.RestaurantLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal class Customer : Person {
        public int Money { get; set; }
        internal double Satisfaction { get; private set; }
        public Customer() {
            Random random = new Random();
            Money = random.Next(120, 361);
            Satisfaction = 100D;
        }

        private void FillWallet(int amount = 250) {
            Money += amount;
        }

        internal void ModifySatisfaction(double foodQuality, double tableQuality, double serviceQuality) 
        {
            Satisfaction *= (foodQuality / 100) * (tableQuality / 10) * (serviceQuality / 100);
        }

        internal int GetTipAmount(int moneyLeft) 
        {
            double tip = moneyLeft * (Satisfaction / 100);
            return ((int)tip);
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

        internal bool CanAfford(FoodItem item) {
            return item.Price < this.Money;
        }

        internal int PayForFood(int sum)
        {
            if (Money < sum) {
                int temp = Money;
                Money = 0;
                return temp;
            }
            int ret = sum + GetTipAmount(Money - sum);
            Money -= ret;
            return ret;
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
