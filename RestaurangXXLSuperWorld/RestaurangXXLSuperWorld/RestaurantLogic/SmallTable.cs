using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class SmallTable : Table
    {
        private int _sizeX = 12;       
        private int _sizeY = 5;

        public SmallTable(int positionX, int positionY) : base(positionX, positionY)
        {
        }

        protected override int SizeX => _sizeX;
        protected override int SizeY => _sizeY;

        internal override int GetNumberOfChairs()
        {
            return 2;
        }
    }
    
}
