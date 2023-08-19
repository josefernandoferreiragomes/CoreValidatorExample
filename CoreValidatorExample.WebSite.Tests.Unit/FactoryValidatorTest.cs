using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Validators;

namespace CoreValidatorExample.WebSite.Tests.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InvalidEmployeeTest()
        {
            var employee = new EmployeeExample { Person = new PersonExample { FirstName = string.Empty, LastName = string.Empty } };

            var results = ValidationFactoryFacConcept.Validate(employee);

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