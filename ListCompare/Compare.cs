using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCompare
{
    [TestFixture]
    public class ListsCompareTest
    {
        [Test]
        public void OrderedListsWillFail()
        {
            var defaultList = People.GetPeople();
            
        }
        
        [Test]
        public void OrderedListsOneWay()
        {
            var defaultList = People.GetPeople().OrderBy(p => p.FirstName);
            var orderedList = People.OrderedPersonsFirstName();
            Assert.AreEqual(defaultList, defaultList.OrderBy(p => p.LastName));

        }

        [Test]
        public void OrderedListsAnotherWay()
        {
            var defaultList = People.GetPeople().OrderBy(p => p.LastName);
            var expectedList = People.OrderedPersonsLastName();
            CollectionAssert.AreEquivalent(expectedList, defaultList);
        }

        [Test]
        public void OrderedListsAThirdWay()
        {
            var defaultList = People.GetPeople();
            People.OrderedPersonsFirstName().SequenceEqual(defaultList.OrderBy(p => p.FirstName));
        }
    }

    public class People
    {
        private List<Person> Persons { get; set; }

        private People()
        {
            Persons = new List<Person>();
            AddDefaultPeople();

        }

        public static List<Person> OrderedPersonsLastName()
        {
            return new People().Persons.OrderBy(p => p.LastName).ToList();
        }

        public static List<Person> OrderedPersonsFirstName()
        {
            return new People().Persons.OrderBy(p => p.LastName).ToList();
        }

        public static List<Person> GetPeople()
        {
            return new People().Persons;
        }

        private void AddDefaultPeople()
        {
            Persons.Add(Person.CreatePerson(1, "Tim", "Sneed"));
            Persons.Add(Person.CreatePerson(2, "Dirk", "Pitt"));
            Persons.Add(Person.CreatePerson(3, "Jack", "Ryan"));
            Persons.Add(Person.CreatePerson(4, "Mitch", "Rapp"));
            Persons.Add(Person.CreatePerson(5, "Thomas", "Jefferson"));
        }
    }

    public class Person
    {
        public int PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private Person()
        {

        }

        public static Person CreatePerson(int personId, string firstName, string LastName)
        {
            return new Person() { FirstName = firstName, LastName = LastName, PersonId = personId };
        }
    }
}
