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
        public void OrderedListsAreNotSame()
        {
            var failList = People.OrderedPersonsFirstName().ToList();
            Assert.AreNotSame(failList.OrderBy(p => p.FirstName).ToList(), failList);
        }

        [Test]
        public void OrderedListsOneWay()
        {
            var orderedList = People.OrderedPersonsFirstName().ToList();
            Assert.AreEqual(orderedList.OrderBy(p => p.FirstName), orderedList);
        }

        [Test]
        public void OrderedListsAnotherWay()
        {
            var expectedList = People.OrderedPersonsLastName().ToList();
            CollectionAssert.AreEqual(expectedList.OrderBy(p => p.LastName), expectedList);
        }

        [Test]
        public void OrderedListsAThirdWay()
        {
            var list = People.OrderedPeopleIdDescending().ToList();
            Assert.IsTrue(list.SequenceEqual(list.OrderByDescending(p => p.PersonId)));
        }

        [Test]
        public void NoobieCheckingListsAreOrdered()
        {
            var orderedList = People.OrderedPeopleId().ToList();
            var expectedList = orderedList.OrderBy(p => p.PersonId).ToList();

            for (int i = 0; i < orderedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i], orderedList[i]);
            }
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

        public static IEnumerable<Person> OrderedPersonsLastName()
        {
            return new People().Persons.OrderBy(p => p.LastName).ToList();
        }

        public static IEnumerable<Person> OrderedPersonsFirstName()
        {
            return new People().Persons.OrderBy(p => p.FirstName).ToList();
        }

        public static IEnumerable<Person> GetPeople()
        {
            return new People().Persons;
        }

        public static IEnumerable<Person> OrderedPeopleIdDescending()
        {
            return new People().Persons.OrderByDescending(p => p.PersonId).ToList();
        }

        public static IEnumerable<Person> OrderedPeopleId()
        {
            return new People().Persons.OrderBy(p => p.PersonId).ToList();
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
