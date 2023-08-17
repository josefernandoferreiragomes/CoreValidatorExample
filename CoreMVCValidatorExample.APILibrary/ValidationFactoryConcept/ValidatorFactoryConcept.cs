using System.ComponentModel.DataAnnotations;

namespace CoreMVCValidatorExample.APILibrary.ValidationFactoryConcept
{

    public static class ValidationFactory
    {

        public static ValidationResultWithFactory Validate<T>(T obj)
        {
            try
            {
                //var validator = ObjectFactory.GetInstance<IValidatorWithFactory<T>>();
                IValidatorWithFactory<T> validator = CustomObjectFactory.GetObjectInstance<T>();
                return validator.Validate(obj);
            }
            catch (Exception ex)
            {
                var messages = new List<ValidationMessageWithFactory> {new ValidationMessageWithFactory {
                Message = string.Format("Error validating {0}", obj)}};

                messages.AddRange(FlattenError(ex));

                var result = new ValidationResultWithFactory { Messages = messages };
                return result;
            }
        }

        private static IEnumerable<ValidationMessageWithFactory> FlattenError(Exception exception)
        {
            var messages = new List<ValidationMessageWithFactory>();
            var currentException = exception;

            do
            {
                messages.Add(new ValidationMessageWithFactory { Message = exception.Message });
                currentException = currentException.InnerException;
            } while (currentException != null);

            return messages;
        }
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
