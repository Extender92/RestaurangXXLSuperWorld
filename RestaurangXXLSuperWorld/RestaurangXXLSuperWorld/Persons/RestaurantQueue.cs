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
    // Constraint, whatever we want to place in the queue must have a "size"
    // Constraint, must be able to create new Ts with public parameterless ctor!
    internal class RestaurantQueue<T> where T : IMeasurable, new() {
        //A generic Collection of generic type :)
        private readonly Collection<T> _groups;
        private RestaurantQueue(Collection<T> groups) {
            _groups = groups;
        }
        /**
         * Gets an instance of a queue with a default number of parties
         */
        public static RestaurantQueue<T> InitializeQueue(int numberToQueue) {
            //Initialize the collection of Ts
            Collection<T> groupsInQueue = new ();
            //Create new Ts and add to collection as long as there is space for more
            while (numberToQueue > 0) {
                T newGroup = new();
                //Can the new group fit?
                if(newGroup.Size() <= numberToQueue) {
                    // Then add it and decrease the number of visitors needed to fill the queue
                    groupsInQueue.Add(newGroup);
                    numberToQueue -= newGroup.Size();
                }
            }
            return new RestaurantQueue<T>(groupsInQueue);
        }
        /**
         * Fill the queue with a suitable amount of elements
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
            T firstParty = _groups.First();
            _groups.Remove(firstParty);
            return firstParty;
        }
        /**
         * Gets a party of suitable Size in queue if there is one, else gets the first party in queue
         */
        public T GetSuitableParty(int maxSize) {
            //Find the first entry matching size requirements
            foreach(T party in _groups) {
                if(party.Size() <= maxSize) {
                    T suitableParty = party;
                    _groups.Remove(suitableParty);
                    return suitableParty;
                }
            }
            //if we cannot find one, return the first unfitting group
            return GetFirstInQueue();
        }
    }
}
