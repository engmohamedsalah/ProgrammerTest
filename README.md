In C# create a single class that when subclassed allows this sample test code to run using only the file system for storage, no pre-built database allowed; use files.  Create all classes required to compile and pass the test case; you may not modify the test.  The Id, Save, Delete, and Find methods must be in the base class only; subclasses must not have to write any persistence code and may not override any base class persistence methods. 

Choose whatever types you feel appropriate, the purpose of the exercise is to see some of your code and discuss with you the solution you came up with and the choices you made.  Your resume will not be looked at without code that passes this test. Submit your solution as a passing nUnit test case along with your resume to jobs@allresnet.com.  We'll let you know whether your code interests us or not.


    [TestCase]
    public void ProgrammerTest() {
    
    var address = new Address("56 Main St", "Mesa", "AZ", "38574");
    var customer = new Customer("John", "Doe", address);
    var company = new Company("Google", address);
    
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
