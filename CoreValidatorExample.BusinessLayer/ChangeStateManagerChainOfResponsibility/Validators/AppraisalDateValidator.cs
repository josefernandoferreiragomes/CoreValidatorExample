using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // AppraisalDateValidator.cs
    public class AppraisalDateValidator : IChangeStateValidatorHandler<Appraisal>
    {
        private IChangeStateValidatorHandler<Appraisal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Appraisal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Appraisal appraisal)
        {
            // Perform date validation
            if (appraisal.SubmissionDate > DateTime.Now)
            {
                throw new InvalidOperationException("Submission date is in the future.");
            }

            // Pass to the next handler if validation passes
            _nextHandler?.Handle(appraisal);
        }
    }

}
