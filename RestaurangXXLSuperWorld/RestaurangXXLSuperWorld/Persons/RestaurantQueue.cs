using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    /**
     * A class representing the queue to a restaurant with the 
     * associated functionality
     */
    // Constraint, must be able to create new Ts with public parameterless xtor!
    internal class RestaurantQueue<T> where T : IMeasurable, new() {
        //A generic Collection of generic type :)
        private readonly Collection<T> _groups;
        private RestaurantQueue(Collection<T> groups) {
            _groups = groups;
        }
        /**
         * Gets an instance of a queue with a default number of parties
         */
        public static RestaurantQueue<T> InitializeQueue(int numberOfVisitors) {
            //Initialize the collection of Ts
            Collection<T> groups = new ();
            //Create new Ts and add to collection as long as there is space for more
            while (numberOfVisitors > 0) {
                T newGroup = new();
                //Can the new group fit?
                if(newGroup.Size() <= numberOfVisitors) {
                    // Then add it and decrease the number of visitors needed to fill the queue
                    groups.Add(newGroup);
                    numberOfVisitors -= newGroup.Size();
                }
            }
            return new RestaurantQueue<T>(groups);
        }
        /**
         * fill the queue with a suitable amount of elements
         */
        public void FillQueue(int numberOfParties) {
            for (int number = 0; number < numberOfParties; number++) {
                _groups.Add(new T());
            }
        }
        /**
         * Gets the first party in queue
         * "We can solve any problem by introducing an extra level of indirection."
         */
        public T GetFirstInQueue() {
            return _groups.First();
        }
        /**
         * Gets a party os suitable Size in queue if there is one, else gets the first party in queue
         */
        public T GetSuitableParty(int maxSize) {
            foreach(T party in _groups) {
                if(party.Size() <= maxSize) {
                    T suitableParty = party;
                    _groups.Remove(suitableParty);
                    return suitableParty;
                }
            }
            return GetFirstInQueue();
        }
    }
}
