using CoreValidatorExample.BusinessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // DecisionReasonValidator.cs
    public class DecisionReasonValidator : IChangeStateValidatorHandler<Decision>
    {
        private IChangeStateValidatorHandler<Decision> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Decision> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Decision decision)
        {
            if (string.IsNullOrEmpty(decision.Reason))
            {
                throw new InvalidOperationException("Decision reason is missing.");
            }

            _nextHandler?.Handle(decision);
        }
    }

}
