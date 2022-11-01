using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurangXXLSuperWorld.Persons
{
    /**
     * A class for creating randomly generated swedish full names
     * 
     */
    internal sealed class NameGenerator
    {
        private static readonly Random random = new();
        private static readonly string[] names1 = {
                "Karin",
                "Anders",
                "Johan",
                "Eva",
                "Maria",
                "Mikael",
                "Anna",
                "Sara",
                "Erik",
                "Per",
                "Christina",
                "Lena",
                "Lars",
                "Emma",
                "Kerstin",
                "Karl",
                "Marie",
                "Peter",
                "Thomas",
                "Karl",
                "Jan",
                "Maria",
                "Karin",
                "Lena" };
        private static readonly string[] names2 = {
                "Andersson",
                "Johansson",
                "Karlsson",
                "Nilsson",
                "Eriksson",
                "Larsson",
                "Olsson",
                "Persson",
                "Svensson",
                "Gustafsson"
        };
        /**
         * A method that returns a full (Swedish) name 
         */
        internal static string GetName()
        {
            return GetFirstName() +
             " " + GetLastName();
        }
        /**
         * Returns a swedish first name
         */
        internal static string GetFirstName() {
            return names1[random.Next(names1.Length)];
        }
        /**
         * Returns a swedish surname
         */
        internal static string GetLastName() {
            return names2[random.Next(names2.Length)];
        }
        //Good luck ever obtaining an instance of this class 
        private NameGenerator() {; }
    }
}
