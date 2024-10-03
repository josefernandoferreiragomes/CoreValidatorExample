using CoreValidatorExample.BusinessLayer.ChangeStateManager;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManager.ValidatorExecuters
{
    public abstract class ValidatorExecuterBase : IValidatorExecuterBase
    {
        public abstract List<SvcValidationMsg> Validate();


    }
}
