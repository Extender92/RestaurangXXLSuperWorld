using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal abstract class FoodItem
    {
        protected int _currentStep;
        protected string[] _cookingSteps;
        protected DateTime? _timeDone = null;
        public double QualityLevel { get; set; }
        public string Name { get; init; }
        public bool IsDone { get; private set; }
        public DateTime? TimeDone 
        { 
            get { if (IsDone && _timeDone != null) { return _timeDone; } return null;} 
            set { _timeDone = value; } 
        }
        public int Price { get; init; }
        public int TimeToCook { get; init; }

        internal FoodItem(string name) 
        {
            _currentStep = 0;
            Name = name;
            TimeToCook = 10;
        }
        internal void Cook() {
            _currentStep++;
            if(_currentStep == 10) {
                IsDone = true;
                TimeDone = DateTime.Now;
            }
        }
        internal virtual string GetCurrentStep() { return _cookingSteps[_currentStep]; }
    }
}
