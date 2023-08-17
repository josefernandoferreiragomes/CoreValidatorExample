namespace CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data
{
    public class EmployeeExample
    {
        public PersonExample Person { get; set; }
        public DateTime HireDate { get; set; }
    }

    //snippets

    //ForRequestedType<IValidatorFacConcept<EmployeeExample>>().TheDefaultIsConcreteType<EmployeeValidatorWithFactory>();


    //public void InvalidEmployeeTest()
    //{
    //    var person = new EmployeeExample { PersonExample = new PersonExample { FirstName = string.Empty, LastName = string.Empty } };

    //    var results = ValidationFactoryFacConcept.Validate(person);

    //    Assert.IsNotNull(results);
    //    Assert.IsFalse(results.Valid);
    //    Assert.IsTrue(results.Messages.Count > 0);
    //}

    //public bool SaveEmployee()
    //{
    //    var person = View.EmployeeExample;

    //    var results = ValidationFactoryFacConcept.Validate(person);

    //    if (results.Valid)
    //        _controller.SaveEmployee(person);
    //    else
    //        View.Errors = results.Messages;
    //}


    //internal class CustomObjectFactoryFacConcept
    //{
    //    internal static IValidatorFacConcept<T> GetObjectInstance<T>(T obj)
    //    {
    //        return (IValidatorFacConcept<T>)Activator.CreateInstance(typeof(ProposalStateValidatorHelper), true, obj);//<T>(typeof(ProposalStateValidatorHelper));
    //    }
    //}

    //public static class ValidatorFactory
    //{
    //public static T CreateValidator<T>( obj) where T : class
    //{
    //    return Activator.CreateInstance<T>(obj);
    //}
    //public static T Validate<T>(T obj) where T : class
    //{
    //    //ValidationResultFacConcept validationResult = new ValidationResultFacConcept();

    //    switch ((typeof(T)).Name )
    //    {
    //        case "ProposalSvcRequest":
    //            return Activator.CreateInstance<T>();
    //            //validationResult = validator.Validate(obj);
    //            break;
    //        case "DecisionSvcRequest":
    //            var validator2 = Activator.CreateInstance<DecisionStateValidatorHelper>();
    //            //validationResult = validator2.Validate(obj);
    //            break;

    //    }

    //    //return validationResult;
    //    return T;
    //}
    //}
}
