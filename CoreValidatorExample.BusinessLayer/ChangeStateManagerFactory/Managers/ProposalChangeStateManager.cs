using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.BusinessLayer.Models.Enums;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;
using CoreValidatorExample.BusinessLayer.Services;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ProposalChangeStateManager<T> : ChangeStateManagerBase<T>
        where T : Proposal
    {
        public ILogger<LoanPhaseOneOrchestrator> _logger { get; set; }
        public ILoanService _loanRepository { get; set; }
        public ICollateralService _collateralRepository { get; set; }
        public IAssetService _assetRepository { get; set; }
        WFValidationResult<T> Result;
        public ProposalChangeStateManager(int userId, int userCorporateUnitId, int proposalId, T proposal, ILogger<LoanPhaseOneOrchestrator> logger)
            : base(userCorporateUnitId, proposalId)
        {
            ProposalId = proposalId;
            Result = new WFValidationResult<T>(proposal); 
        }

        private int ProposalId { get; set; }

        public override WFValidationResult<T> ValidateAndExecute(int eventId)
        {
            switch (eventId)
            {
                case (int)ProposalEvents.Started:
                    ValidateExecuteProposalEventStarted();
                    break;
                //... remaining events
                default:
                    NoValidationsExecuteStateChange();
                    break;
            }
            Result.MessageList = ValidationMsgList;
            return Result;
        }

        private void ValidateExecuteProposalEventStarted()
        {
            var propertyValidatorExecuter = ValidatorExecuterFactory.GetObjectInstance<PropertyValidatorExecuter>();
            propertyValidatorExecuter.Validate(ObjectInstance.Status);

            var intervenerValidatorExecuter = (IntervenerValidatorExecuter)ValidatorExecuterFactory.GetObjectInstance<IntervenerValidatorExecuter>();
            intervenerValidatorExecuter.ValidateAge(ObjectInstance.ProponentBirthDate);

            //remaining validation or execution logic
            ExecuteChangeState();
        }

        public override void ExecuteChangeState()
        {
            //call service method ChangeState

        }

    }
}
