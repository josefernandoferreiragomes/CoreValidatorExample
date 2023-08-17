using CoreMVCValidatorExample.APILibrary.ValidationFactoryConcept;

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
            var employee = new EmployeeWithFactory { Person = new PersonWithFactory { FirstName = string.Empty, LastName = string.Empty } };

            var results = ValidationFactory.Validate(employee);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.Valid);
            Assert.IsTrue(results.Messages.Count > 0);
        }

        [Test]
        public void InvalidPersonTest()
        {
            var employee = new PersonWithFactory { FirstName = string.Empty, LastName = string.Empty };

            var results = ValidationFactory.Validate(employee);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.Valid);
            Assert.IsTrue(results.Messages.Count > 0);
        }
    }
}