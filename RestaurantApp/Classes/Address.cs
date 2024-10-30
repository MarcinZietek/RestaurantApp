using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Address
    {
        private string country;
        private string state;
        private string city;
        private string street;
        private string postalCode;     

        public Address() { }
        public Address(string country, string state, string city, string street, string postalCode) { 
            City = city;    
            State = state;
            PostalCode = postalCode;
            Country = country;
            Street = street;
            
        }

        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public string PostalCode { get { return postalCode; } set { postalCode = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string Street { get { return street; } set { street = value; } }
        public override string ToString() { return $"Kraj: {Country}\nWojewództwo: {State}\nMiasto: {City}\nUlica: {Street}\nKod pocztowy: {PostalCode}"; }
    }
}
