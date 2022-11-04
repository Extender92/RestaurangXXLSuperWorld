using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic
{
    internal class RestaurantDoor
    {
        internal static char[] charSet = { '┌', '─', '┤', '│', '└', '┤' };
        private ConsoleColor Color = ConsoleColor.Magenta;

        private int positionX;
        private int positionY; 

        private int SizeX = 1;
        private int SizeY = 5;

        internal RestaurantDoor(int positionX, int positionY, int sizeX, int sizeY)
        {
            this.positionX = (positionX + sizeX - 1);
            this.positionY = (positionY + sizeY - SizeY - 2);
        }

        internal void Draw()
        {
            GUI.RestaurantPrinter(SizeX, SizeY, positionX, positionY, charSet, Color);
        }
    }
}
