using CoreValidatorExample.DataAccessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ProposalDateValidator.cs
    public class ProposalDateValidator : IChangeStateValidatorHandler<Proposal>
    {
        private IChangeStateValidatorHandler<Proposal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Proposal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Proposal proposal)
        {
            if (proposal.SubmissionDate > DateTime.Now)
            {
                throw new InvalidOperationException("Proposal submission date cannot be in the future.");
            }

            _nextHandler?.Handle(proposal);
        }
    }

}
