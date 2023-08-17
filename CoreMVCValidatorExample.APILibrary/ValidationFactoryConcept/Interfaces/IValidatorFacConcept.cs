using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces
{
    public interface IValidatorFacConcept<T>
    {
        ValidationResultFacConcept Validate(T obj);
        ValidationResultFacConcept Validate(T obj, bool suppressWarnings);
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
