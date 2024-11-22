using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // AppraisalStatusValidator.cs
    public class AppraisalStatusValidator : IChangeStateValidatorHandler<Appraisal>
    {
        private IChangeStateValidatorHandler<Appraisal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Appraisal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Appraisal appraisal)
        {
            // Perform status validation
            if (appraisal.Status != AppraisalStatus.Approved)
            {
                throw new InvalidOperationException("Appraisal status is invalid.");
            }

            // Pass to the next handler if validation passes
            _nextHandler?.Handle(appraisal);
        }
    }

}
