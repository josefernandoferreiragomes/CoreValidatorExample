using CoreValidatorExample.ApiLibrary.Tests.Unit;
using CoreValidatorExample.APILibrary.Repository;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CoreValidatorExample.WebSite.Tests.Unit
{
    public class PersonExampleRepositoryTest
    {
        
        private ServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            // Create a new ServiceCollection to register services
            var serviceCollection = new ServiceCollection();

            // Register the real PersonValidator for IValidator<Person>
            serviceCollection.AddTransient<IValidatorFacConcept<PersonExample>, PersonValidatorWithFactory>();

            // Register the SomeService class
            serviceCollection.AddTransient<PersonExampleRepository>();

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
        public void PersonExampleRepositoryAddTest()
        {

            var Person = new PersonExample {  FirstName = string.Empty, LastName = string.Empty } ;
            var PersonExampleRepository = _serviceProvider.GetService<PersonExampleRepository>();
            var results = PersonExampleRepository.AddPerson(Person);
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