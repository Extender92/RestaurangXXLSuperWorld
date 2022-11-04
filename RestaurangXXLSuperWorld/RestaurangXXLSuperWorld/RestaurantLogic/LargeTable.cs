using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal class LargeTable : Table 
    {
        private int _sizeX = 18;
        private int _sizeY = 5;

        public LargeTable(int positionX, int positionY) : base(positionX, positionY)
        {
        }

        protected override int SizeX => _sizeX;
        protected override int SizeY => _sizeY;

        internal override int GetNumberOfChairs()
        {
            return 4;
        }
    }
}
