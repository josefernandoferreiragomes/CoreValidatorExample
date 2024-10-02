using System.ComponentModel.DataAnnotations;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;

using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;

namespace CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Validators
{

    public static class ValidationFactoryFacConcept
    {
        public static ValidationResultFacConcept Validate<T>(T obj)
        {
            try
            {
                //IValidatorFacConcept<T>? objInstance = Activator.CreateInstance(typeof(EmployeeValidatorWithFactory)) as IValidatorFacConcept<T>;
                var validator = Activator.CreateInstance<IValidatorFacConcept<T>>();
                return validator.Validate(obj);
            }
            catch (Exception ex)
            {
                var messages = new List<ValidationMessageFacConcept> {new ValidationMessageFacConcept {
                Message = string.Format("Error validating {0}", obj)}};

                messages.AddRange(FlattenError(ex));

                var result = new ValidationResultFacConcept { Messages = messages };
                return result;
            }
        }

        private static IEnumerable<ValidationMessageFacConcept> FlattenError(Exception exception)
        {
            var messages = new List<ValidationMessageFacConcept>();
            var currentException = exception;

            do
            {
                messages.Add(new ValidationMessageFacConcept { Message = exception.Message });
                currentException = currentException.InnerException;
            } while (currentException != null);

            return messages;
        }
    }
}
