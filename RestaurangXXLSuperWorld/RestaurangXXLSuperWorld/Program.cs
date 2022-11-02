using RestaurangXXLSuperWorld.Persons;
using RestaurangXXLSuperWorld.View;

namespace RestaurangXXLSuperWorld
{
    internal class Program
    {
        static void Main()
        {
            //PersonTester
            Person p1 = new Customer();
            Person p2 = new Customer();
            Console.WriteLine(p1.Name);
            Console.WriteLine(p2.Name);

            //Party Tester
            Party<Customer> party1 = new();
            Party<Customer> party2 = new();
            Console.WriteLine(party1.Size());
            Console.WriteLine(party2.Size());

            //QueueTester
            RestaurantQueue<Party<Customer>> queue = RestaurantQueue<Party<Customer>>.InitializeQueue(80);
            party1 = queue.GetFirstInQueue();
            party2 = queue.GetSuitableParty(1);
            Console.WriteLine(party1.Size());
            Console.WriteLine(party2.Size());

            var persons = party1.getParty();
            foreach(Customer customer in persons) {
                Console.WriteLine(customer.Satisfaction);
                customer.ModifySatisfaction(10d,10d,10d);
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.Satisfaction);
            }

            //GUI.DrawRestaurant();
            //Console.ReadLine();

        }


     
    }
}