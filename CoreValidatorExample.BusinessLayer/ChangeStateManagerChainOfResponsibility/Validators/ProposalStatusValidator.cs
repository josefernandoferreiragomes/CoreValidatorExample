using CoreValidatorExample.DataAccessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ProposalStatusValidator.cs
    public class ProposalStatusValidator : IChangeStateValidatorHandler<Proposal>
    {
        private IChangeStateValidatorHandler<Proposal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Proposal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Proposal proposal)
        {
            if (proposal.Status != ProposalStatus.Approved)
            {
                throw new InvalidOperationException("Proposal status is not approved.");
            }

            _nextHandler?.Handle(proposal);
        }
    }

}
