using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Person : IRepositoryCRUD<Person>
    {       
        private static int nextId = 1;

        private readonly int _id;
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string gender;
        private Address address;

        //Parametry domyślne konstruktora Person
        public Person() {       
            _id = nextId++;
            FirstName = "Unknown";
            LastName = "Unknown";
            BirthDate = DateTime.Parse("0000-00-00");
            Gender = "Unknown";
        }
        public Person(string firstName, string lastName, DateTime birthDate, string gender, Address address) {
            _id = nextId++;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Address = address;
        }

        public string FirstName { get { return firstName; } set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentNullException ("Pole nie może być puste!"); }
                else { firstName = value; } }
        }
        public string LastName { get { return lastName; } set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentNullException ("Pole nie może być puste!"); }
                else { lastName = value; } }
        }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
        public int Age { get { return CalculateAge(); } }
        public string Gender { get { return gender; } set { gender = value; } }
        public Address Address { get { return address; } set { address = value; } }
        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            return age;
        }

        public override string ToString()
        {
            return $"Id: {_id}\nImie: {FirstName}\nNazwisko: {LastName}\nWiek: {Age}\nPłeć: {Gender}\nAdres: {address}";
        }

        public void Add(Person obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Person obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person obj)
        {
            throw new NotImplementedException();
        }
    }
}
