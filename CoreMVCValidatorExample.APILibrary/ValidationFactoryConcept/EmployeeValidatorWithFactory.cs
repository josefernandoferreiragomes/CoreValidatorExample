namespace CoreMVCValidatorExample.APILibrary.ValidationFactoryConcept
{
    public class EmployeeValidatorWithFactory : IValidatorWithFactory<EmployeeWithFactory>
    {
        #region Implementation of IValidation<Employee>

        public ValidationResultWithFactory Validate(EmployeeWithFactory employee)
        {
            return Validate(employee, false);
        }

        public ValidationResultWithFactory Validate(EmployeeWithFactory employee, bool suppressWarnings)
        {
            var result = new ValidationResultWithFactory();

            //This code here would be replaced with a validation rules engine later

            if (employee != null)
            {
                if (!suppressWarnings && employee.HireDate > DateTime.Now)
                    result.Messages.Add(new ValidationMessageWithFactory
                    {
                        Message = string.Format("EmployeeWithFactory hire date: {0} is set in the future.", employee.HireDate),
                        Warning = true
                    });

                if (employee.Person != null)
                {
                    if (string.IsNullOrEmpty(employee.Person.FirstName))
                        result.Messages.Add(new ValidationMessageWithFactory { Message = "EmployeeWithFactory FirstName is required." });
                    if (string.IsNullOrEmpty(employee.Person.LastName))
                        result.Messages.Add(new ValidationMessageWithFactory { Message = "EmployeeWithFactory LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessageWithFactory { Message = "EmployeeWithFactory person data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessageWithFactory { Message = "EmployeeWithFactory data is missing." });

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
