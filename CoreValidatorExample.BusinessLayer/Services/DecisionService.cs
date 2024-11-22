using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Interfaces;
using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface IDecisionService
    {

    }
    public class DecisionService
    {
        private ChangeStateManagerFactory<Decision> _changeStateManagerFactory;
        private IGenericRepository<Decision> _decisionRepository;

        public DecisionService(ChangeStateManagerFactory<Decision> changeStateManagerFactory, IGenericRepository<Decision> _decisionRepository)
        {
            _changeStateManagerFactory = changeStateManagerFactory;
            _decisionRepository = _decisionRepository;
        }       

        //TO BE REFACTORED
        public DecisionChangeStateSvcResponse DecisionChangeState(DecisionChangeStateSvcRequest request)
        {
            
            var decision = _decisionRepository.GetByIdAsync(request.DecisionId);

            WFValidationResult<Decision> result = new WFValidationResult<Decision>();
            //simulate success
            DecisionChangeStateSvcResponse response = new DecisionChangeStateSvcResponse();

            
            DecisionChangeStateManager<Decision> manager = (DecisionChangeStateManager<Decision>)_changeStateManagerFactory.GetObjectInstance(1, 101, 1001, decision.Result);

            result = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }
    }
}
