using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.RestaurantLogic;
using RestaurangXXLSuperWorld.View;
using System.Diagnostics;

namespace RestaurangXXLSuperWorld
{
    internal class Program
    {
        private static readonly int FrameTime = 1000; //ms
        static void Main()
        {
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

            //GUI.DrawRestaurant();
            //Console.ReadLine();

            //Main Loop Skeleton

            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            //for (int frame = 0; true ; frame++) {
            //    //Program Loop Here
                
            //    //Timer Debug
            //    Console.SetCursorPosition(0, 0);
            //    Console.WriteLine($"Elapsed in program: {timer.Elapsed.TotalMilliseconds}");
            //    //Wait without accumulating errors
            //    Thread.Sleep(FrameTime - (((int)timer.Elapsed.TotalMilliseconds) % 1000));

            Restaurant restaurant = new Restaurant();
            restaurant.Draw();
            restaurant.PopulateTables();

            

        }    
    }
}