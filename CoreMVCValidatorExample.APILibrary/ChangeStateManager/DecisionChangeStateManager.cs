using CoreValidatorExample.APILibrary.ChangeStateManager;
using CoreValidatorExample.APILibrary.ChangeStateManager.Factory;
using CoreValidatorExample.APILibrary.ChangeStateManager.ValidatorExecuters;
using CoreValidatorExample.APILibrary.Data;
using CoreValidatorExample.APILibrary.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.APILibrary
{
    public abstract class DecisionChangeStateManager : ChangeStateManagerBase
    {
        protected DecisionChangeStateManager(int userId, int userCorporateUnitId, int decisionId)
            : base(userCorporateUnitId, decisionId)
        {
            DecisionId = decisionId;
        }
        private int DecisionId {  get; set; }

        public override List<SvcValidationMsg> ValidateAndExecute(int eventId)
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
            return this.ValidationMsgList;
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
