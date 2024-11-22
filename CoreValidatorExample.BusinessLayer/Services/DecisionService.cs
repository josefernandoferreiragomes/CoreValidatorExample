using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface IDecisionService
    {

    }
    public class DecisionService
    {
        private ChangeStateManagerFactory<Decision> ChangeStateManagerFactory;

        public DecisionService(ChangeStateManagerFactory<Decision> changeStateManagerFactory)
        {
            this.ChangeStateManagerFactory = changeStateManagerFactory;
        }       

        //TO BE REFACTORED
        public DecisionChangeStateSvcResponse DecisionChangeState(DecisionChangeStateSvcRequest request)
        {
            WFValidationResult<Decision> result = new WFValidationResult<Decision>();
            //simulate success
            DecisionChangeStateSvcResponse response = new DecisionChangeStateSvcResponse();

            Decision decision = new Decision();
            ChangeStateManagerFactory.ObjectInstance = decision;
            DecisionChangeStateManager<Decision> manager = (DecisionChangeStateManager<Decision>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001);

            result = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }
    }
}
