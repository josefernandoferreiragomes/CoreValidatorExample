using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;

namespace CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Validators
{
    public class EmployeeValidatorWithFactory : IValidatorFacConcept<EmployeeExample>
    {
        #region Implementation of IValidation<Employee>

        public ValidationResultFacConcept Validate(EmployeeExample employee)
        {
            return Validate(employee, false);
        }

        public ValidationResultFacConcept Validate(EmployeeExample employee, bool suppressWarnings)
        {
            var result = new ValidationResultFacConcept();

            //This code here would be replaced with a validation rules engine later

            if (employee != null)
            {
                if (!suppressWarnings && employee.HireDate > DateTime.Now)
                    result.Messages.Add(new ValidationMessageFacConcept
                    {
                        Message = string.Format("EmployeeExample hire date: {0} is set in the future.", employee.HireDate),
                        Warning = true
                    });

                if (employee.Person != null)
                {
                    if (string.IsNullOrEmpty(employee.Person.FirstName))
                        result.Messages.Add(new ValidationMessageFacConcept { Message = "EmployeeExample FirstName is required." });
                    if (string.IsNullOrEmpty(employee.Person.LastName))
                        result.Messages.Add(new ValidationMessageFacConcept { Message = "EmployeeExample LastName is required." });
                }
                else
                    result.Messages.Add(new ValidationMessageFacConcept { Message = "EmployeeExample person data is missing." });
            }
            else
                result.Messages.Add(new ValidationMessageFacConcept { Message = "EmployeeExample data is missing." });

            return result;
        }

      

        #endregion
    }

    
}
