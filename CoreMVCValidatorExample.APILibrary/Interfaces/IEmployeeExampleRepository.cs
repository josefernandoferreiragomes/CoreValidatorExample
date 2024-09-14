using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.APILibrary.Repository
{
    public interface IEmployeeExampleRepository
    {
        ValidationResultFacConcept AddEmployee(EmployeeExample employee);        
    }
}
