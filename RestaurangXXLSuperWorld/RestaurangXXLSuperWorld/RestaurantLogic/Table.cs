using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.RestaurantLogic {
    internal abstract class Table
    {
        internal enum TableStatus {
            Empty,
            Waiting,  // Waiting for food
            Eating,   // Eating their food
            Finished, // Wants to leave
            Cleaning, // Waiter is cleaning table
        }

        internal TableStatus Status { get; set; }
        private double eatingTime = 19.9D;
        internal static char[] charSet = { '┌', '─', '┐', '│', '└', '┘' };
        private ConsoleColor Color = ConsoleColor.Blue;

        internal int positionX { get; set; }
        internal int positionY { get; set; }

        protected abstract int SizeX { get; }
        protected abstract int SizeY { get; }


        internal double qualityLevel;
        // Represents the number of updates since the table was cleaned
        internal int _timeSinceCleaned;
        internal Party<Customer>? seatedGuests;

        internal Order TablesOrder { get; set; }

        internal Menu TodaysMenu { get; set; }

        internal abstract int GetNumberOfChairs();

        internal Table (int positionX, int positionY)
        {
            Status = TableStatus.Empty;
            this.positionX = positionX;
            this.positionY = positionY;
            TodaysMenu = new Menu ();
            TablesOrder = new Order(this);
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

        internal bool IsFree()
        {
            if (seatedGuests is null) return true;
            return false;
        }

        internal void SeatGuests(Party<Customer> party)
        {
            seatedGuests = party;
            DetermineTableQualityLevel();
        }
        internal void UnSeatGuests() {
            Restaurant.ServedVisitors += seatedGuests.Size();
            seatedGuests = null;
        }
        internal bool IsPartySeated(Party<Customer> party) {
            return seatedGuests == party;
        }

        //internal void PrintParty()
        //{
        //    if (seatedGuests != null)
        //        GUI.PartyTablePrinter(this);
        //    //else
        //    //    Console.WriteLine(0);
        //}
        internal void Update() {
            _timeSinceCleaned++;
            if(TablesOrder.Step == OrderSteps.Delivered && TablesOrder.TimeElapsed() < eatingTime) {
                //Eating Food
            } else if (TablesOrder.Step == OrderSteps.Delivered && TablesOrder.TimeElapsed() > eatingTime) {
                TablesOrder.UpdateOrder();
            }
        }
        // Fancy method for quality level when guests arrive based on time since cleaned and size (one man at big table == putin bad)
        private void DetermineTableQualityLevel() {
            double cleanModifier = 1.2D - 0.05D * _timeSinceCleaned;
            double tableSizeModifier = 1.2D - 0.2 * (GetNumberOfChairs() - seatedGuests.Size());
            qualityLevel = 10.0D * cleanModifier * tableSizeModifier;
        }
        internal List<Customer> GetParty()
        {
            return seatedGuests.getParty().ToList();
        }

        internal double GetTableSatisfaction() {
            double average = 0.0D;
            if (seatedGuests is null) {
                return 0.0;
            } else {
                foreach (Customer guest in seatedGuests._members) {
                    average += guest.Satisfaction;
                }
                average /= seatedGuests.Size();
                return average;
            }
        }

    }
}
