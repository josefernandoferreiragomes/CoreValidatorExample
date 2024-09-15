using CoreValidatorExample.APILibrary.ChangeStateManager;
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
    public class ProposalChangeStateManager : ChangeStateManagerBase
    {
        public ProposalChangeStateManager(int userId, int userCorporateUnitId, int proposalId) 
            : base (userCorporateUnitId, proposalId)
        {
            ProposalId = proposalId;
        }

        private int ProposalId {  get; set; }

        public override List<SvcValidationMsg> ValidateAndExecute(int eventId)
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
            return this.ValidationMsgList;
        }
        
        private void ValidateExecuteProposalEventStarted()
        {
            var propertyValidatorExecuter = this.ValidatorExecuterFactory.GetObjectInstance<PropertyValidatorExecuter>();
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
