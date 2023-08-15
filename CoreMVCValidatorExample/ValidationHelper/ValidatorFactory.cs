using System.ComponentModel.DataAnnotations;

namespace CoreValidatorExample.WebSite.ValidationHelper
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T obj);
        ValidationResult Validate(T obj, bool suppressWarnings);
    }

    public sealed class ValidationMessage
    {
        public string Message { get; internal set; }
        public bool Warning { get; internal set; }

        //Only allow creation internally or by ValidationResult class.
        internal ValidationMessage()
        {
        }
    }

    public sealed class ValidationResult
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

        public ValidationResult()
        {
            Messages = new List<ValidationMessage>();
        }

        public IList<ValidationMessage> Messages { get; internal set; }

        /// <summary>
        /// Adds the error. 
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void AddError(string errorMessage)
        {
            _dirty = true;
            Messages.Add(new ValidationMessage { Message = errorMessage });
        }

        /// <summary>
        /// Adds the warning. 
        /// </summary>
        /// <param name="warningMessage">The warning message.</param>
        public void AddWarning(string warningMessage)
        {
            //No need to mark collection dirty since warnings never generate validation changes
            Messages.Add(new ValidationMessage { Message = warningMessage, Warning = true });
        }
    }

    public class PersonValidator : IValidator<Person>
    {
        #region Implementation of IValidation<Person>

        public ValidationResult Validate(Person person)
        {
            return Validate(person, false);
        }

        public ValidationResult Validate(Person person, bool suppressWarnings)
        {
            var result = new ValidationResult();

            //This code here would be replaced with a validation rules engine later

            if (person != null)
            {
               

                if (person != null)
                {
                    if (string.IsNullOrEmpty(person.FirstName))
                        result.Messages.Add(new ValidationMessage { Message = "Person FirstName is required." });
                    if (string.IsNullOrEmpty(person.LastName))
                        result.Messages.Add(new ValidationMessage { Message = "Person LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessage { Message = "Person data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessage { Message = "Person data is missing." });

            return result;
        }

        //public ValidationResult Validate<T>(T? obj)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }

    public class EmployeeValidator : IValidator<Employee>
    {
        #region Implementation of IValidation<Employee>

        public ValidationResult Validate(Employee employee)
        {
            return Validate(employee, false);
        }

        public ValidationResult Validate(Employee employee, bool suppressWarnings)
        {
            var result = new ValidationResult();

            //This code here would be replaced with a validation rules engine later

            if (employee != null)
            {
                if (!suppressWarnings && employee.HireDate > DateTime.Now)
                    result.Messages.Add(new ValidationMessage
                    {
                        Message = string.Format("Employee hire date: {0} is set in the future.", employee.HireDate),
                        Warning = true
                    });

                if (employee.Person != null)
                {
                    if (string.IsNullOrEmpty(employee.Person.FirstName))
                        result.Messages.Add(new ValidationMessage { Message = "Employee FirstName is required." });
                    if (string.IsNullOrEmpty(employee.Person.LastName))
                        result.Messages.Add(new ValidationMessage { Message = "Employee LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessage { Message = "Employee person data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessage { Message = "Employee data is missing." });

            return result;
        }

        //public ValidationResult Validate<T>(T? obj)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }

    public class Employee
    {
        public Person Person { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class ValidationFactory
    {
        
        public static ValidationResult Validate<T>(T obj)
        {
            try
            {
                //var validator = ObjectFactory.GetInstance<IValidator<T>>();
                IValidator<T> validator = CustomObjectFactory.GetObjectInstance<T>();
                return validator.Validate(obj);
            }
            catch (Exception ex)
            {
                var messages = new List<ValidationMessage> {new ValidationMessage {
                Message = string.Format("Error validating {0}", obj)}};

                messages.AddRange(FlattenError(ex));

                var result = new ValidationResult { Messages = messages };
                return result;
            }
        }

        private static IEnumerable<ValidationMessage> FlattenError(Exception exception)
        {
            var messages = new List<ValidationMessage>();
            var currentException = exception;

            do
            {
                messages.Add(new ValidationMessage { Message = exception.Message });
                currentException = currentException.InnerException;
            } while (currentException != null);

            return messages;
        }
    }

    public static class CustomObjectFactory
    {
        //internal static IValidator<T> GetObjectInstance(T obj)
        //{
        //    return (IValidator<T>)Activator.CreateInstance(typeof(EmployeeValidator));//<T>(typeof(ProposalStateValidatorHelper));
        //}

        public static IValidator<T> GetObjectInstance<T>()
        {
            IValidator<T>? objInstance = Activator.CreateInstance(typeof(EmployeeValidator)) as IValidator<T>;
            switch (typeof(T).Name)
            {
                case "Employee":
                    objInstance = (IValidator<T>)Activator.CreateInstance(typeof(EmployeeValidator));
                    break;
                case "Person":
                    objInstance = (IValidator<T>)Activator.CreateInstance(typeof(PersonValidator));
                    break;
            }
            return objInstance;
        }
    }

    //snippets

    //ForRequestedType<IValidator<Employee>>().TheDefaultIsConcreteType<EmployeeValidator>();


    //public void InvalidEmployeeTest()
    //{
    //    var person = new Employee { Person = new Person { FirstName = string.Empty, LastName = string.Empty } };

    //    var results = ValidationFactory.Validate(person);

    //    Assert.IsNotNull(results);
    //    Assert.IsFalse(results.Valid);
    //    Assert.IsTrue(results.Messages.Count > 0);
    //}

    //public bool SaveEmployee()
    //{
    //    var person = View.Employee;

    //    var results = ValidationFactory.Validate(person);

    //    if (results.Valid)
    //        _controller.SaveEmployee(person);
    //    else
    //        View.Errors = results.Messages;
    //}


    //internal class CustomObjectFactory
    //{
    //    internal static IValidator<T> GetObjectInstance<T>(T obj)
    //    {
    //        return (IValidator<T>)Activator.CreateInstance(typeof(ProposalStateValidatorHelper), true, obj);//<T>(typeof(ProposalStateValidatorHelper));
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
    //    //ValidationResult validationResult = new ValidationResult();

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
