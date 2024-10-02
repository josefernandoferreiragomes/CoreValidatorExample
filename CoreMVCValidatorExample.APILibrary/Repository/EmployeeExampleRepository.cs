using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class EmployeeExampleRepository : IEmployeeExampleRepository
    {
        private readonly IValidatorFacConcept<EmployeeExample> _employeeValidator;

        public EmployeeExampleRepository(IValidatorFacConcept<EmployeeExample> employeeValidator)
        {
            _employeeValidator = employeeValidator;
        }

        public ValidationResultFacConcept AddEmployee(EmployeeExample employee)
        {
            var validationResult = _employeeValidator.Validate(employee);

            if (validationResult.Valid)
            {
                // Proceed with valid employee
            }
            else
            {
                // Handle invalid employee
            }
            return validationResult;
        }
    }
}
