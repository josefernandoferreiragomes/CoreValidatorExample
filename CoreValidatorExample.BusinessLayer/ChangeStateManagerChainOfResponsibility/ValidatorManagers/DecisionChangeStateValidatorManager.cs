using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // DecisionChangeStateValidatorManager.cs
    public class DecisionChangeStateValidatorManager
    {
        private readonly IChangeStateValidatorHandler<Decision> _firstHandler;

        public DecisionChangeStateValidatorManager()
        {
            // Setup the chain of responsibility
            var reasonValidator = new DecisionReasonValidator();
            var outcomeValidator = new DecisionOutcomeValidator();
            var dateValidator = new DecisionDateValidator();

            // Chain the validators
            reasonValidator.SetNext(outcomeValidator);
            outcomeValidator.SetNext(dateValidator);

            _firstHandler = reasonValidator;
        }

        public void Validate(Decision decision)
        {
            _firstHandler.Handle(decision);
        }
    }

}
