using Programmer.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programmer
{
    /// <summary>
    /// Customer Class inherit form BaseEntity
    /// contains Address , FirstName and LastName
    /// </summary>
    public class Customer : BaseEntity<Customer>
    {
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //this for xml serialization
        public Customer() { }
        //in case we will work with dependency injection
        public Customer(string firstName, string lastName, Address address, IRepository repository=null) : base(repository)
        {
           
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(FirstName, LastName, Address.GetHashCode()).GetHashCode();
        }
        //override Equals so that assert will know how to equal
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Customer);
        }
        public bool Equals(Customer customer)
        {
            if (Object.ReferenceEquals(customer, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, customer))
            {
                return true;
            }

            if (customer == null)
            {
                return false;
            }

            return customer.FirstName.Equals(this.FirstName) && customer.LastName.Equals(this.LastName) && customer.Address.Equals(this.Address);
        }
        
    
    }
}
