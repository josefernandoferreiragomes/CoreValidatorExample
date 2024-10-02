using CoreValidatorExample.BusinessLayer.ChangeStateManager;
using CoreValidatorExample.BusinessLayer.ChangeStateManager.Factory;
using CoreValidatorExample.BusinessLayer.ChangeStateManager.ValidatorExecuters;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer
{
    public class AppraisalChangeStateManager : ChangeStateManagerBase
    {

        public AppraisalChangeStateManager(int userId, int userCorporateUnitId, int appraisalId) 
            : base (userCorporateUnitId, appraisalId)
        {
            AppraisalId = appraisalId;
        }

        private int AppraisalId {  get; set; }

        public override List<SvcValidationMsg> ValidateAndExecute(int eventId)
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
            return this.ValidationMsgList;
        }
        
        private void ValidateExecuteAppraisalEventStarted()
        {
            var intervenerValidatorExecuter = ValidatorExecuterFactory.GetObjectInstance<IntervenerValidatorExecuter>();
            intervenerValidatorExecuter.Validate();
            //remaining validation or execution logic
            ExecuteChangeState();
        }
        private void ValidateExecuteAppraisalEventCompleteDate()
        {
            var appraisalValidatorExecuter = this.ValidatorExecuterFactory.GetObjectInstance<AppraisalValidatorExecuter>();
            appraisalValidatorExecuter.Validate();
            //remaining validation or execution logic
            ExecuteChangeState();
        }
        
        public override void ExecuteChangeState()
        {
            //call service method ChangeState
        }
        
    }
}
