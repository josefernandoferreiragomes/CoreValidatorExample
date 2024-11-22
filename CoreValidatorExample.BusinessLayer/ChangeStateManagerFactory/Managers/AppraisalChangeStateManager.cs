using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.BusinessLayer.Models.Enums;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class AppraisalChangeStateManager<T> : ChangeStateManagerBase<T>
        where T : Appraisal
    {
        WFValidationResult<T> result;

        public ILogger _logger { get; set; }      
        private int AppraisalId {  get; set; }

        public AppraisalChangeStateManager(int userId, int userCorporateUnitId, int appraisalId, T appraisal, ILogger logger) 
            : base (userCorporateUnitId, appraisalId)
        {
            AppraisalId = appraisalId;
            result = new WFValidationResult<T>(appraisal);
            _logger = logger;
            ObjectInstance = appraisal;
        }


        public override WFValidationResult<T> ValidateAndExecute(int eventId)
        {
            switch (eventId)
            {
                case (int)AppraisalEvents.Started:
                    ValidateExecuteAppraisalEventStarted();
                    break;
                case (int)AppraisalEvents.CompleteData:
                    ValidateExecuteAppraisalEventCompleteDate();
                    break;
                //... remaining events
                default:
                    NoValidationsExecuteStateChange();
                    break;
            }
            result.MessageList = this.ValidationMsgList;
            return result;
        }
        
        private void ValidateExecuteAppraisalEventStarted()
        {
            
            var appraisalValidatorExecuter = (AppraisalValidatorExecuter)ValidatorExecuterFactory.GetObjectInstance<AppraisalValidatorExecuter>();
            var intervenerValidatorExecuter = ValidatorExecuterFactory.GetObjectInstance<IntervenerValidatorExecuter>();
            appraisalValidatorExecuter.Validate(ObjectInstance.SubmissionDate);
            appraisalValidatorExecuter.ValidateMandatoryField(ObjectInstance);
            intervenerValidatorExecuter.Validate(ObjectInstance.AppraiseeName);
            //remaining validation or execution logic
            ExecuteChangeState();
        }
        private void ValidateExecuteAppraisalEventCompleteDate()
        {
            var appraisalValidatorExecuter = (AppraisalValidatorExecuter)this.ValidatorExecuterFactory.GetObjectInstance<AppraisalValidatorExecuter>();
            appraisalValidatorExecuter.Validate(ObjectInstance.SubmissionDate);
            appraisalValidatorExecuter.ValidateStatus(ObjectInstance);
            //remaining validation or execution logic
            ExecuteChangeState();
        }
        
        public override void ExecuteChangeState()
        {
            //call service method ChangeState
        }
        
    }
}
