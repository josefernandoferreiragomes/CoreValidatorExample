﻿using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ProposalTitleValidator.cs
    public class ProposalTitleValidator : IChangeStateValidatorHandler<Proposal>
    {
        private IChangeStateValidatorHandler<Proposal> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Proposal> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Proposal proposal)
        {
            if (string.IsNullOrEmpty(proposal.Title))
            {
                throw new InvalidOperationException("Proposal title is missing.");
            }

            _nextHandler?.Handle(proposal);
        }
    }

}
