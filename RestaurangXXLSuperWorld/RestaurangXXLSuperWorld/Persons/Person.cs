using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons {
    internal abstract class Person {
        private readonly string _name;
        public string Name { get => _name; }
        public Person() {
            _name = NameGenerator.GetName();
        }
    }
}
