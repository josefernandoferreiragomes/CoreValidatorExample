using System.ComponentModel.DataAnnotations;

namespace CoreValidatorExample.WebSite.ValidationHelper
{
    public interface IValidatorWithFactory<T>
    {
        ValidationResultWithFactory Validate(T obj);
        ValidationResultWithFactory Validate(T obj, bool suppressWarnings);
    }

    public sealed class ValidationMessageWithFactory
    {
        public string Message { get; internal set; }
        public bool Warning { get; internal set; }

        //Only allow creation internally or by ValidationResultWithFactory class.
        internal ValidationMessageWithFactory()
        {
        }
    }

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

    public class EmployeeWithFactory
    {
        public PersonWithFactory Person { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class PersonWithFactory
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

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

    public static class CustomObjectFactory
    {
        //internal static IValidatorWithFactory<T> GetObjectInstance(T obj)
        //{
        //    return (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(EmployeeValidatorWithFactory));//<T>(typeof(ProposalStateValidatorHelper));
        //}

        public static IValidatorWithFactory<T> GetObjectInstance<T>()
        {
            IValidatorWithFactory<T>? objInstance = Activator.CreateInstance(typeof(EmployeeValidatorWithFactory)) as IValidatorWithFactory<T>;
            switch (typeof(T).Name)
            {
                case "EmployeeWithFactory":
                    objInstance = (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(EmployeeValidatorWithFactory));
                    break;
                case "PersonWithFactory":
                    objInstance = (IValidatorWithFactory<T>)Activator.CreateInstance(typeof(PersonValidatorWithFactory));
                    break;
            }
            return objInstance;
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
