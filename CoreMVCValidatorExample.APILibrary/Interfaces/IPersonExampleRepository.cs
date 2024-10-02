using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Repository
{
    public interface IPersonExampleRepository
    {
        ValidationResultFacConcept AddPerson(PersonExample Person);        
    }
}
