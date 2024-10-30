using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private string gender;
        private Address address; 
        public Person() { }
        public Person(string firstName, string lastName, DateTime birthDate, string gender, Address address) {
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
            return $"Imie: {FirstName}\nNazwisko: {LastName}\nWiek: {Age}\nPłeć: {Gender}\nAdres: {address}";
        }

    }
}
