﻿using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.APILibrary.Repository
{
    public class PersonExampleRepository : IPersonExampleRepository
    {
        private readonly IValidatorFacConcept<PersonExample> _PersonValidator;

        public PersonExampleRepository(IValidatorFacConcept<PersonExample> PersonValidator)
        {
            _PersonValidator = PersonValidator;
        }

        public ValidationResultFacConcept AddPerson(PersonExample Person)
        {
            var validationResult = _PersonValidator.Validate(Person);

            if (validationResult.Valid)
            {
                // Proceed with valid Person
            }
            else
            {
                // Handle invalid Person
            }
            return validationResult;
        }
    }
}