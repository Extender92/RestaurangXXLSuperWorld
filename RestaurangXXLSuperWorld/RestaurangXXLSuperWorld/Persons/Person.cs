using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal abstract class Person {
        private readonly string _firstname;
        private readonly string _lastname;
        public string FirstName { get => _firstname; }
        public string LastName { get => _lastname; }

        public Person() {
            _firstname = NameGenerator.GetFirstName();
            _lastname = NameGenerator.GetLastName();


        }

       
    }

    
}
