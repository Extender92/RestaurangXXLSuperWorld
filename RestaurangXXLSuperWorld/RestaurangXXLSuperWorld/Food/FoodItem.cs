using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class FoodItem
    {
        // The step in the sequence of cooking
        protected int _currentStep;
        // The description of the sequence of cooking
        protected string[] _cookingSteps;
        // When was the food finished cooking
        protected DateTime? _timeDone = null;
        public bool IsDone { get; private set; }
        // Represents how good this food turned out
        public double QualityLevel { get; set; }
        // Long name of the dish
        public string Name { get; init; }
        public int Price { get; init; }
        public int TimeToCook { get; init; }
        protected FoodItem(string name) {
            _currentStep = 0;
            Name = name;
            TimeToCook = 10;
        }
        /**
         * Never touch this piece of shit ctor
         * Goblin engineered in place
         */
        public FoodItem() {
        }
        /**
         * Gets the time when this dish was finished cooking
         */
        public DateTime? TimeDone 
        { 
            get { if (IsDone && _timeDone != null) { return _timeDone; } return null;} 
            set { _timeDone = value; } 
        }
        /**
         * Cooks the foodItem one step forward
         */
        internal void Cook() {
            _currentStep++;
            if(_currentStep == 10) {
                IsDone = true;
                TimeDone = DateTime.Now;
            }
        }
        /**
         * Gets the current steps as a string description of the cooking process
         */
        internal virtual string GetCurrentStep() { return _cookingSteps[_currentStep]; }
    }
}
