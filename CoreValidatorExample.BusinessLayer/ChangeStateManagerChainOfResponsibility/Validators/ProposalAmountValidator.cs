using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ProposalAmountValidator.cs
    public class ProposalAmountValidator : IChangeStateValidatorHandler<Proposal>
    {
        private IChangeStateValidatorHandler<Proposal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Proposal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Proposal proposal)
        {
            if (proposal.Amount <= 0)
            {
                throw new InvalidOperationException("Proposal amount must be greater than zero.");
            }

            _nextHandler?.Handle(proposal);
        }
    }

}
