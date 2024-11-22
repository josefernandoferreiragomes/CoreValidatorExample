using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ChangeStateValidatorManager.cs
    public class AppraisalChangeStateValidatorManager
    {
        private readonly IChangeStateValidatorHandler<Appraisal> _firstHandler;

        public AppraisalChangeStateValidatorManager()
        {
            // Setup the chain of responsibility
            var mandatoryFieldValidator = new AppraisalMandatoryFieldValidator();
            var statusValidator = new AppraisalStatusValidator();
            var dateValidator = new AppraisalDateValidator();

            // Chain the validators
            mandatoryFieldValidator.SetNext(statusValidator);
            statusValidator.SetNext(dateValidator);

            _firstHandler = mandatoryFieldValidator;
        }

        public void Validate(Appraisal appraisal)
        {
            _firstHandler.Handle(appraisal);
        }
    }

}
