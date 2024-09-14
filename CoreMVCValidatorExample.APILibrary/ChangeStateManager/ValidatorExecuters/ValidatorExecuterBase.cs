using CoreValidatorExample.APILibrary.ChangeStateManager;
using CoreValidatorExample.APILibrary.Data;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.APILibrary.ChangeStateManager.ValidatorExecuters
{
    public abstract class ValidatorExecuterBase : IValidatorExecuterBase
    {
        public abstract List<SvcValidationMsg> Validate();


    }
}
