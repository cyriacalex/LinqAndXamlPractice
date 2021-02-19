using System;
using System.Collections.Generic;
using System.Text;

namespace LinqXamlPractice
{
    public class Person
    {
            public int id;
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int rating { get; set; }
            public int startDate { get; set; }

        public static IEnumerable<Person> PersonList()
        {
            var personList = new List<Person>();

            personList.Add(new Person() { id = 1, firstName = "Joseph", lastName = "Stalin", rating = 4, startDate = 1990 });
            personList.Add(new Person() { id = 2, firstName = "Mark", lastName = "Twain", rating = 4, startDate = 2004 });
            personList.Add(new Person() { id = 3, firstName = "Elizabeth", lastName = "Twin", rating = 8, startDate = 1560 });
            personList.Add(new Person() { id = 4, firstName = "Jessica", lastName = "Brown", rating = 2, startDate = 1978 });
            personList.Add(new Person() { id = 5, firstName = "Gary", lastName = "Dro", rating = 10, startDate = 2010 });
            personList.Add(new Person() { id = 6, firstName = "Marcus", lastName = "Brutus", rating = 9, startDate = 1900 });
            personList.Add(new Person() { id = 7, firstName = "Shirley", lastName = "Surely", rating = 2, startDate = 1875 });
            personList.Add(new Person() { id = 8, firstName = "Kurt", lastName = "Russell", rating = 7, startDate = 2000 });
            personList.Add(new Person() { id = 9, firstName = "Kurt", lastName = "Bob", rating = 2, startDate = 1941 });
            personList.Add(new Person() { id = 10, firstName = "Kurt", lastName = "Thomas", rating = 8, startDate = 1980 });

            return personList;
        }
    }
}
