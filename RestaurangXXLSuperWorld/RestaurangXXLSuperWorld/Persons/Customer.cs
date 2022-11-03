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
            Money = random.Next(250, 501);
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


            //Default Order
            return new MeatOne();
        }
    }
}
