using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Data.Enums;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ProposalChangeStateManager<Proposal> : ChangeStateManagerBase<Proposal>
    {
        WFValidationResult<Proposal> Result;
        public ProposalChangeStateManager(int userId, int userCorporateUnitId, int proposalId, Proposal proposal)
            : base(userCorporateUnitId, proposalId)
        {
            ProposalId = proposalId;
            Result = new WFValidationResult<Proposal>(proposal); 
        }

        private int ProposalId { get; set; }

        public override WFValidationResult<Proposal> ValidateAndExecute(int eventId)
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
            propertyValidatorExecuter.Validate();
            //remaining validation or execution logic
            ExecuteChangeState();
        }

        public override void ExecuteChangeState()
        {
            //call service method ChangeState

        }

    }
}
