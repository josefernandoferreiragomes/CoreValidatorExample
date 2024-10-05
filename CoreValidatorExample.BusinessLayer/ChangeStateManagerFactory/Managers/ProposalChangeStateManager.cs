using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Data.Enums;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ProposalChangeStateManager<T> : ChangeStateManagerBase<T>
        where T : Proposal
    {
        WFValidationResult<T> Result;
        public ProposalChangeStateManager(int userId, int userCorporateUnitId, int proposalId, T proposal)
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
