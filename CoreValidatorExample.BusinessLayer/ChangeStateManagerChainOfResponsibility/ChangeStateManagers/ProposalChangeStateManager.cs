using CoreValidatorExample.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ProposalChangeStateManager.cs
    public class ProposalChangeStateManager
    {
        private readonly ProposalChangeStateValidatorManager _validatorManager;

        public ProposalChangeStateManager()
        {
            _validatorManager = new ProposalChangeStateValidatorManager();
        }

        public void ChangeState(Proposal proposal)
        {
            // Perform validation
            _validatorManager.Validate(proposal);

            // Change state logic for proposal...
            // For example, change the proposal state to "Completed" after validation.
        }
    }

}
