using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Address : IListObject<Address>, IRepositoryCRUD<Address>
    {
        private readonly List<Address> list = new List<Address>();

        private string country;
        private string state;
        private string city;
        private string street;
        private string postalCode;     

        public Address() {
            Country = "Not specified";
            State = "Not specified";
            City = "Not specified";
            Street = "Not specified";
            PostalCode = "Not specified";
        }
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

        public void Add(Address obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address obj)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAll()
        {
            return list;
        }

        public override string ToString() { return $"Kraj: {Country}\nWojewództwo: {State}\nMiasto: {City}\nUlica: {Street}\nKod pocztowy: {PostalCode}"; }

        public void Update(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}
