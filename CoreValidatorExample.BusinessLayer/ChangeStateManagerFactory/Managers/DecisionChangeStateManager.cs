using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Data.Enums;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class DecisionChangeStateManager<Decision> : ChangeStateManagerBase<Decision>
    {
        WFValidationResult<Decision> result;
        public DecisionChangeStateManager(int userId, int userCorporateUnitId, int decisionId, Decision decision)
            : base(userCorporateUnitId, decisionId)
        {
            DecisionId = decisionId;
            result = new WFValidationResult<Decision>(decision);

        }
        private int DecisionId {  get; set; }

        public override WFValidationResult<Decision> ValidateAndExecute(int eventId)
        {
            switch (eventId)
            {
                case (int)DecisionEvents.Started:
                    ValidateExecuteDecisionEventStarted();
                    break;
                //... remaining events
                default:
                    NoValidationsExecuteStateChange();
                    break;
            }
            result.MessageList = this.ValidationMsgList;
            return result;
        }
        
        private void ValidateExecuteDecisionEventStarted()
        {
            var intervenerValidatorExecuter = this.ValidatorExecuterFactory.GetObjectInstance<IntervenerValidatorExecuter>();
            intervenerValidatorExecuter.Validate();
            //remaining validation or execution logic
            ExecuteChangeState();
        }


        public override void ExecuteChangeState()
        {
            //call service method ChangeState
            
        }

    }
}
