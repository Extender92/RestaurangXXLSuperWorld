using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal abstract class Table
    {
        internal static char[] charSet = { '┌', '─', '┐', '│', '└', '┘' };
        private ConsoleColor Color = ConsoleColor.Blue;

        private int positionX { get; set; }
        private int positionY { get; set; }

        protected abstract int SizeX { get; }
        protected abstract int SizeY { get; }


        private double qualityLevel;
        private Party<Customer>? seatedGuests;

        internal Order? PlacedOrder { get; set; }

        internal Menu TodaysMenu { get; set; }

        internal Table (int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }
        internal void Draw()
        {
            GUI.RestaurantPrinter(SizeX, SizeY, positionX, positionY, charSet, Color);
        }

        internal void SetPosition(int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
        }
    }
}
