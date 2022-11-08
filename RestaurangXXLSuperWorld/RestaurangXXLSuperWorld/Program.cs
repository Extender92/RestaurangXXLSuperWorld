using RestaurangXXLSuperWorld.Food;
using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.RestaurantLogic;
using RestaurangXXLSuperWorld.View;
using System.Diagnostics;

namespace RestaurangXXLSuperWorld {
    internal class Program {
        private static readonly int FrameTime = 1000; //ms
        static void Main() {
            Console.WriteLine(Math.Pow(0.95,4));

            //Restaurant restaurant = new Restaurant(10);
            //restaurant.PopulateTables();
            //restaurant.Draw();
            //restaurant.PopulateWaiters();
            //SimpleTimer timer = new SimpleTimer(FrameTime);
            //Console.CursorVisible = false;
            //while (true) {
            //    restaurant.Update();
            //    Thread.Sleep(FrameTime - timer.ElapsedMillisecs());
            //    ////var currentTimeFormated = DateTime.Now.ToString(@"{0:mm:ss.ffff}");
            //    ////Console.SetCursorPosition(0,60);
            //    ////Console.WriteLine(currentTimeFormated);
            //    restaurant.PostUpdate();

            //}
        }
        static void Debug(Restaurant restaurant) {
            //    //PersonTester
            //    Person p1 = new Customer();
            //    Person p2 = new Customer();
            //    Console.WriteLine(p1.Name);
            //    Console.WriteLine(p2.Name);

            //    //Party Tester
            //    Party<Customer> party1 = new();
            //    Party<Customer> party2 = new();
            //    Console.WriteLine(party1.Size());
            //    Console.WriteLine(party2.Size());

            //    //QueueTester
            //    RestaurantQueue<Party<Customer>> queue = RestaurantQueue<Party<Customer>>.InitializeQueue(80);
            //    party1 = queue.GetFirstInQueue();
            //    party2 = queue.GetSuitableParty(1);
            //    Console.WriteLine(party1.Size());
            //    Console.WriteLine(party2.Size());

            //    var persons = party1.getParty();
            //    foreach(Customer customer in persons) {
            //        Console.WriteLine(customer.Satisfaction);
            //        customer.ModifySatisfaction(10d,10d,10d);
            //        Console.WriteLine(customer.Name);
            //        Console.WriteLine(customer.Satisfaction);
            //    }

            //Console.WriteLine("En rad med skit");
            //restaurant.PrintTableOrders();
        }
    }
}
