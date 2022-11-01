using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Food
{
    internal class FoodItem
    {
        protected int _currentStep;
        protected DateTime? _timeDone = null;
        public double QualityLevel { get; set; }
        public string Name { get; init; }
        public bool IsDone { get; private set; }
        public DateTime? TimeDone 
        { 
            get { if (IsDone && _timeDone != null) { return _timeDone; } return null;} 
            set { _timeDone = value; } 
        }
        public int Prize { get; init; }
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
        internal virtual string GetCurrentStep() { return "Cooking the idea of Food"; }
    }
}
