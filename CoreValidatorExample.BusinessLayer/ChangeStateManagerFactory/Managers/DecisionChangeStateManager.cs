using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.BusinessLayer.Models.Enums;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class DecisionChangeStateManager<T> : ChangeStateManagerBase<T>
        where T : Decision
    {
        public ILogger<LoanPhaseOneOrchestrator> _logger { get; set; }

        LoanPhaseOneOrchestrator _loanPhaseOneOrchestrator;

        WFValidationResult<T> result;
        public DecisionChangeStateManager(int userId, int userCorporateUnitId, int decisionId, T decision, ILogger<LoanPhaseOneOrchestrator> logger, LoanPhaseOneOrchestrator loanPhaseOneOrchestrator)
            : base(userCorporateUnitId, decisionId)
        {
            DecisionId = decisionId;
            result = new WFValidationResult<T>(decision);
            _logger = logger;           

        }
        private int DecisionId {  get; set; }

        public override WFValidationResult<T> ValidateAndExecute(int eventId)
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
            
            intervenerValidatorExecuter.Validate(ObjectInstance.DecisionDate);            
            //remaining validation or execution logic
            ExecuteChangeState();
            
            _loanPhaseOneOrchestrator.Orchestrate(new BaseOrchestratorRequest()
            {
                //refactor to get user name
                UserName = UserId.ToString()
            });
        }


        public override void ExecuteChangeState()
        {
            //call service method ChangeState
            
        }

    }
}
