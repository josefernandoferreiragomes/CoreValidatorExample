using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // DecisionOutcomeValidator.cs
    public class DecisionOutcomeValidator : IChangeStateValidatorHandler<Decision>
    {
        private IChangeStateValidatorHandler<Decision> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Decision> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Decision decision)
        {
            if (decision.Outcome == DecisionOutcome.Pending)
            {
                throw new InvalidOperationException("Decision outcome is still pending.");
            }

            _nextHandler?.Handle(decision);
        }
    }

}
