using Programmer.DataRepository;
using System;


namespace Programmer
{
    /// <summary>
    /// Company Class inherit form BaseEntity
    /// contains Address  Company
    /// </summary>
    public class Company : BaseEntity<Company>
    {
        public  Address Address { get; set; }
        public  string Name { get; set; }
        //this for xml serialization
        public Company() { }
        //in case we will work with dependency injection
       
        public Company(string name, Address address, IRepository repository=null ) : base(repository)
        {
            this.Name = name;
            this.Address = address;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Name, Address.GetHashCode()).GetHashCode();
        }
        //override Equals so that assert will know how to equal
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Company);
        }
        public bool Equals(Company company)
        {
            if (Object.ReferenceEquals(company, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, company))
            {
                return true;
            }

            if (company == null)
            {
                return false;
            }

            return company.Name.Equals(this.Name) && company.Address.Equals(this.Address);
        }
        public override string ToString()
        {
            return string.Join("", new[] {base.ToString(), this.Name, this.Address.ToString()});
        }

       
    }
}
