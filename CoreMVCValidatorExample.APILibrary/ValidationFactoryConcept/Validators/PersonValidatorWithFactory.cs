using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.APILibrary.ValidationFactoryConcept.Validators
{
    public class PersonValidatorWithFactory : Interfaces.IValidatorFacConcept<PersonExample>
    {
        #region Implementation of IValidation<Person>

        public ValidationResultFacConcept Validate(PersonExample person)
        {
            return Validate(person, false);
        }

        public ValidationResultFacConcept Validate(PersonExample person, bool suppressWarnings)
        {
            var result = new ValidationResultFacConcept();

            //This code here would be replaced with a validation rules engine later

            if (person != null)
            {


                if (person != null)
                {
                    if (string.IsNullOrEmpty(person.FirstName))
                        result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample FirstName is required." });
                    if (string.IsNullOrEmpty(person.LastName))
                        result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessageFacConcept { Message = "PersonExample data is missing." });

            return result;
        }

        //public ValidationResultFacConcept Validate<T>(T? obj)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
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
