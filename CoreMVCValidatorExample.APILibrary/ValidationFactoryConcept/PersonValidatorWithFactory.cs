namespace CoreMVCValidatorExample.APILibrary.ValidationFactoryConcept
{
    public class PersonValidatorWithFactory : IValidatorWithFactory<PersonWithFactory>
    {
        #region Implementation of IValidation<Person>

        public ValidationResultWithFactory Validate(PersonWithFactory person)
        {
            return Validate(person, false);
        }

        public ValidationResultWithFactory Validate(PersonWithFactory person, bool suppressWarnings)
        {
            var result = new ValidationResultWithFactory();

            //This code here would be replaced with a validation rules engine later

            if (person != null)
            {


                if (person != null)
                {
                    if (string.IsNullOrEmpty(person.FirstName))
                        result.Messages.Add(new ValidationMessageWithFactory { Message = "PersonWithFactory FirstName is required." });
                    if (string.IsNullOrEmpty(person.LastName))
                        result.Messages.Add(new ValidationMessageWithFactory { Message = "PersonWithFactory LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessageWithFactory { Message = "PersonWithFactory data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessageWithFactory { Message = "PersonWithFactory data is missing." });

            return result;
        }

        //public ValidationResultWithFactory Validate<T>(T? obj)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }

    //snippets

    //ForRequestedType<IValidatorWithFactory<EmployeeWithFactory>>().TheDefaultIsConcreteType<EmployeeValidatorWithFactory>();


    //public void InvalidEmployeeTest()
    //{
    //    var person = new EmployeeWithFactory { PersonWithFactory = new PersonWithFactory { FirstName = string.Empty, LastName = string.Empty } };

    //    var results = ValidationFactory.Validate(person);

    //    Assert.IsNotNull(results);
    //    Assert.IsFalse(results.Valid);
    //    Assert.IsTrue(results.Messages.Count > 0);
    //}

    //public bool SaveEmployee()
    //{
    //    var person = View.EmployeeWithFactory;

    //    var results = ValidationFactory.Validate(person);

    //    if (results.Valid)
    //        _controller.SaveEmployee(person);
    //    else
    //        View.Errors = results.Messages;
    //}


    //internal class CustomObjectFactory
    //{
    //    internal static IValidatorWithFactory<T> GetObjectInstance<T>(T obj)
    //    {
    //        return (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(ProposalStateValidatorHelper), true, obj);//<T>(typeof(ProposalStateValidatorHelper));
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
    //    //ValidationResultWithFactory validationResult = new ValidationResultWithFactory();

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
