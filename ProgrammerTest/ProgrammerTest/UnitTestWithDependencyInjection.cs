using NUnit.Framework;
using Programmer;
using Programmer.DataRepository;

namespace ProgrammerTest
{
    /// <summary>
    /// This is Unit test that was required on the task at web page
    /// http://www.alliancereservations.com/developer-test.html
    /// </summary>
    [TestFixture]
    public class UnitTestWithDependencyInjection
    {
        [TestCase]
        public void ProgrammerTestWithDI()
        {
            //we can inject Repository to the classess to spicify how to deal with the data
            //for example we can  Add new Database Repository that implement IReposirtory 
            //and inject it  or we can inject FileRepository

            IRepository Irepository = new FileRepository();

            var address = new Address("56 Main St", "Mesa", "AZ", "38574", Irepository);
            var customer = new Customer("John", "Doe", address, Irepository);
            var company = new Company("Google", address, Irepository);

            Assert.IsNullOrEmpty(customer.Id);
            customer.Save();
            Assert.IsNotNullOrEmpty(customer.Id);

            Assert.IsNullOrEmpty(company.Id);
            company.Save();
            Assert.IsNotNullOrEmpty(company.Id);

            Customer savedCustomer = Customer.Find(customer.Id);
            Assert.IsNotNull(savedCustomer);
            Assert.AreSame(customer.Address, address);
            Assert.AreEqual(savedCustomer.Address, address);
            Assert.AreEqual(customer.Id, savedCustomer.Id);
            Assert.AreEqual(customer.FirstName, savedCustomer.FirstName);
            Assert.AreEqual(customer.LastName, savedCustomer.LastName);
            Assert.AreEqual(customer, savedCustomer);
            Assert.AreNotSame(customer, savedCustomer);

            Company savedCompany = Company.Find(company.Id);
            Assert.IsNotNull(savedCompany);
            Assert.AreSame(company.Address, address);
            Assert.AreEqual(savedCompany.Address, address);
            Assert.AreEqual(company.Id, savedCompany.Id);
            Assert.AreEqual(company.Name, savedCompany.Name);
            Assert.AreEqual(company, savedCompany);
            Assert.AreNotSame(company, savedCompany);

            customer.Delete();
            Assert.IsNullOrEmpty(customer.Id);
            Assert.IsNull(Customer.Find(customer.Id));

            company.Delete();
            Assert.IsNullOrEmpty(company.Id);
            Assert.IsNull(Company.Find(company.Id));
        }

    }
}
