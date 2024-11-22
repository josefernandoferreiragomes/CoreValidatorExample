using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // ProposalChangeStateValidatorManager.cs
    public class ProposalChangeStateValidatorManager
    {
        private readonly IChangeStateValidatorHandler<Proposal> _firstHandler;

        public ProposalChangeStateValidatorManager()
        {
            var titleValidator = new ProposalTitleValidator();   // Title validator for Proposal
            var amountValidator = new ProposalAmountValidator();  // Amount validator for Proposal
            var statusValidator = new ProposalStatusValidator();  // Status validator for Proposal
            var dateValidator = new ProposalDateValidator();  // Date validator for Proposal

            // Chain the validators for Proposal
            titleValidator.SetNext(amountValidator);
            amountValidator.SetNext(statusValidator);
            statusValidator.SetNext(dateValidator);

            _firstHandler = titleValidator;
        }

        public void Validate(Proposal proposal)
        {
            _firstHandler.Handle(proposal);
        }
    }

}
