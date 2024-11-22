using CoreValidatorExample.DataAccessLayer.Models;

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
