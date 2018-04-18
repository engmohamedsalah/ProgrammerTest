using Programmer.DataRepository;
using System;

namespace Programmer
{
    public class Address :BaseEntity<Address>
    {
        public string Street { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string ZipCode { get; set; }
        //this for xml serialization
        public Address() { }


        //in case we will work with dependency injection, it must be sent repository parameter
        public Address(string street,string city,string state,string zipCode, IRepository repository=null) : base(repository)
        {
            
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        
        public override int GetHashCode()
        {
            return Tuple.Create(Street, City, State, ZipCode).GetHashCode();
        }
        //override Equals so that assert will know how to equal
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Address);
        }

        public bool Equals(Address addr)
        {
            if (Object.ReferenceEquals(addr, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, addr))
            {
                return true;
            }
            if (this.GetType() != addr.GetType())
            {
                return false;
            }
            return (Street == addr.Street) &&
                (City == addr.City) &&
                (State == addr.State) &&
                (ZipCode == addr.ZipCode);
        }

    }
}
