using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class FoodItem : ICloneable
    {
        // The step in the sequence of cooking
        protected int _currentStep;
        // The description of the sequence of cooking
        protected string[]? _cookingSteps;
        // When was the food finished cooking
        protected DateTime? _timeDone = null;
        internal bool IsDone { get; private set; }
        // Represents how good this food turned out
        internal double QualityLevel { get; set; }
        // Long name of the dish
        internal string? Name { get; init; }
        internal int Price { get; init; }
        internal int TimeToCook { get; init; }
        protected FoodItem(string name) {
            _currentStep = 0;
            Name = name;
            TimeToCook = 10;
        }
        /**
         * Never touch this piece of shit ctor
         * Goblin engineered in place
         */

        internal FoodItem() 
        {
            
        }
        /**
         * Gets the time when this dish was finished cooking
         */
        internal DateTime? TimeDone 
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

        public virtual object Clone() {
            return new FoodItem();
        }
    }
}
