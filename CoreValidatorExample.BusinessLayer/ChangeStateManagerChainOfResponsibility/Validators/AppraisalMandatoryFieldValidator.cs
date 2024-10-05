using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // AppraisalMandatoryFieldValidator.cs
    public class AppraisalMandatoryFieldValidator : IChangeStateValidatorHandler<Appraisal>
    {
        private IChangeStateValidatorHandler<Appraisal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Appraisal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Appraisal appraisal)
        {
            // Perform mandatory field validation
            if (string.IsNullOrEmpty(appraisal.MandatoryField))
            {
                throw new InvalidOperationException("Mandatory field is missing.");
            }

            // Pass to the next handler if validation passes
            _nextHandler?.Handle(appraisal);
        }
    }

}
