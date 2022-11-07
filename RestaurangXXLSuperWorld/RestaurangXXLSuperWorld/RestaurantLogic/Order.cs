using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal enum OrderSteps {
        Initial,
        ToBeOrdered,
        ToBeCooked,
        Cooked,
        Delivered,
        Finished
    }
    internal class Order {
        internal OrderSteps Step { get; private set; }
        private List<FoodItem> _dishes = new();
        private int _totalSum;
        internal int PaidSum { get; set; }
        internal Table Target { get; private set; }
        private Waiter? SingleWaiter;

        internal Order(Table target) {
            Target = target;
            Step = OrderSteps.Initial;
        }
        internal void UpdateOrder() {
            Step++;
        }
        internal string GetStatus() {
            return Step.ToString();
        }

        public void DebugPrintOrder(int col, int row) {
            Console.SetCursorPosition(col, row);
            Console.WriteLine(Step.ToString());
            if (_dishes.Count > 0) {
                foreach(FoodItem dish in _dishes) {
                    Console.WriteLine(dish.Name);
                }
            }
        }
        public void AssignWaiter(Waiter servant) {
            SingleWaiter = servant;
        } 
        public void OrderFood(IEnumerable<FoodItem> toOrder) {
            foreach(FoodItem order in toOrder) {
                _dishes.Add(order);
            }
        }
        public void ResetOrder() {
            _totalSum = 0;
            PaidSum = 0;
            Step = OrderSteps.Initial;
            _dishes = new();
            SingleWaiter = null;
        }
    }
}
