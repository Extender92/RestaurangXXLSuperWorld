using RestaurangXXLSuperWorld.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class Menu {
        private List<FoodItem> _itemsOnMenu = new List<FoodItem>();
        internal List<FoodItem> GetSuitableDishes () {
            return _itemsOnMenu;
        }
        internal Menu() {
            _itemsOnMenu.AddRange(new FoodItem[] { new MeatOne(), new MeatTwo(), new MeatThree(), 
                                                  new FishOne(), new FishTwo(), new FishThree(), 
                                                  new VegOne(), new VegTwo(), new VegThree() 
                                                }
                                );

        }
        internal T OrderOneOf<T>(T placeholder) where T : new() {
            return new T();
        }

        /**
         * Debug function
         */
        internal void DisplayMenu() {
            foreach(FoodItem item in _itemsOnMenu) {
                Console.WriteLine(item.Name + " Kostar " + item.Price + "kr");
            }
        }

    }
}
