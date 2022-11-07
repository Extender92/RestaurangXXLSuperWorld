using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class SimpleTimer {
        private DateTime _oldTime;
        private int targetTime;

        public SimpleTimer(int target) {
            targetTime = target;
            _oldTime = DateTime.Now;
        }
        internal int ElapsedMillisecs() {
            DateTime newTime = DateTime.Now;
            double elapsedTime = ((int)(newTime - _oldTime).TotalMilliseconds) % 1000;
            return ((int)elapsedTime);
        }
    }
}
