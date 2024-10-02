using CoreValidatorExample.ApiLibrary.Tests.Unit;
using CoreValidatorExample.BusinessLayer.Repository;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CoreValidatorExample.WebSite.Tests.Unit
{
    public class EmployeeExampleRepositoryTest
    {
        
        private ServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            // Create a new ServiceCollection to register services
            var serviceCollection = new ServiceCollection();

            // Register the real EmployeeValidator for IValidator<Employee>
            serviceCollection.AddTransient<IValidatorFacConcept<EmployeeExample>, EmployeeValidatorWithFactory>();

            // Register the SomeService class
            serviceCollection.AddTransient<EmployeeExampleRepository>();

            // Build the ServiceProvider
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose the service provider after each test to release resources
            if (_serviceProvider != null)
            {
                _serviceProvider.Dispose();
            }
        }

        [Test]
        public void EmployeeExampleRepositoryAddTest()
        {

            var employee = new EmployeeExample { Person = new PersonExample { FirstName = string.Empty, LastName = string.Empty } };
            var employeeExampleRepository = _serviceProvider.GetService<EmployeeExampleRepository>();
            var results = employeeExampleRepository.AddEmployee(employee);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.Valid);
            Assert.IsTrue(results.Messages.Count > 0);
        }
       

        [Test]
        public void InvalidPersonTest()
        {
            var person = new PersonExample { FirstName = string.Empty, LastName = string.Empty };

            var results = ValidationFactoryFacConcept.Validate(person);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.Valid);
            Assert.IsTrue(results.Messages.Count > 0);
        }
    }
}