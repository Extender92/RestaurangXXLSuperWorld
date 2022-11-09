﻿using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal enum OrderSteps {
        Initial,
        ToBeOrdered,  //Collected from Table
        ToBeCooked,   //Delivered to kitchen queue
        Cooked,       //In Kitchen output queue
        Delivered,    //At table again
        Finished      //Customer wants to leave
    }
    internal class Order {
        internal OrderSteps Step { get; private set; }
        private DateTime? _timeDelivered;
        private DateTime? _timeOrdered;
        internal List<FoodItem> _dishes = new();
        private double serviceQuality;
        private int _totalSum;
        internal int PaidSum { get; set; }
        internal Table Target { get; private set; }
        internal Waiter? SingleWaiter { get; set; }

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
                    Console.WriteLine(dish.Price + "\t" +dish.Name);
                }
                foreach(Customer cust in Target.GetParty()) {
                    Console.WriteLine(cust.Money);
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

        internal void StartOrder() {
            _timeOrdered = DateTime.Now;
        }

        internal void DeliverOrder() {
            _timeDelivered = DateTime.Now;

            if ((_timeDelivered - _timeOrdered).Value.TotalSeconds <= 16)
                serviceQuality = SingleWaiter.ServiceQuality;

            else
                serviceQuality = SingleWaiter.ServiceQuality * 0.8;
        }

        private void SetCustomerSatisfaction()
        {
            for (int i = 0; i < _dishes.Count; i++)
            {
                Target.GetParty()[i].ModifySatisfaction(_dishes[i].QualityLevel, Target.qualityLevel, serviceQuality);
            }
        }

        internal void ResetOrder() {
            _timeOrdered = null;
            _timeDelivered = null;
            _totalSum = 0;
            PaidSum = 0;
            Step = OrderSteps.Initial;
            _dishes = new();
            SingleWaiter = null;
        }

        internal double TimeElapsed() {
            if(_timeOrdered != null && _timeDelivered != null) {
                return (_timeDelivered - _timeOrdered).Value.TotalSeconds;
            } else {
                return 99999;
            }
        }
    }
}
