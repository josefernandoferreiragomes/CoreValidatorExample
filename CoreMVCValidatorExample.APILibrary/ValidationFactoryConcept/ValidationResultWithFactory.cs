namespace CoreMVCValidatorExample.APILibrary.ValidationFactoryConcept
{
    public sealed class ValidationResultWithFactory
    {
        private bool _dirty = true;
        private bool _valid;

        public bool Valid
        {
            get
            {
                //theoretically O(n) time but in pratice will be constant time
                //Still, no need for multiple traversals, Traverse only if it's changed
                if (_dirty)
                {
                    _valid = Messages.FirstOrDefault(msg => msg.Warning == false) == null;
                    _dirty = false;
                }

                return _valid;
            }
        }

        public ValidationResultWithFactory()
        {
            Messages = new List<ValidationMessageWithFactory>();
        }

        public IList<ValidationMessageWithFactory> Messages { get; internal set; }

        /// <summary>
        /// Adds the error. 
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void AddError(string errorMessage)
        {
            _dirty = true;
            Messages.Add(new ValidationMessageWithFactory { Message = errorMessage });
        }

        /// <summary>
        /// Adds the warning. 
        /// </summary>
        /// <param name="warningMessage">The warning message.</param>
        public void AddWarning(string warningMessage)
        {
            //No need to mark collection dirty since warnings never generate validation changes
            Messages.Add(new ValidationMessageWithFactory { Message = warningMessage, Warning = true });
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
