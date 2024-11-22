using CoreValidatorExample.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // DecisionChangeStateManager.cs
    public class DecisionChangeStateManager
    {
        private readonly DecisionChangeStateValidatorManager _validatorManager;

        public DecisionChangeStateManager()
        {
            _validatorManager = new DecisionChangeStateValidatorManager();
        }

        public void ChangeState(Decision decision)
        {
            // Perform validation
            _validatorManager.Validate(decision);

            // Change state logic for decision...
            // Example: Mark the decision as "Finalized" after validation.
        }
    }

}
