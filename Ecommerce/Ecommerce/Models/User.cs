using System.Net;
using System.Xml.Linq;

namespace Ecommerce.Models
{
    public class User
    {
        public Address Address { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public string Phone { get; set; }
        public int __v { get; set; }
    }

    public class Address
    {
        public Geolocation Geolocation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
    }

    public class Geolocation
    {
        public string Lat { get; set; }
        public string Long { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }

    }
}
