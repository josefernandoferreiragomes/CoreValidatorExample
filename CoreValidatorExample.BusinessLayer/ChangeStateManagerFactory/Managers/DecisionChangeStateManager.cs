using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Data.Enums;
using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class DecisionChangeStateManager<T> : ChangeStateManagerBase<T>
        where T : Decision
    {
        public ILogger<LoanPhaseOneOrchestrator> _logger { get; set; }
        public IGenericRepository<Loan> _loanRepository { get; set; }
        public IGenericRepository<Collateral> _collateralRepository { get; set; }
        public IGenericRepository<Asset> _assetRepository { get; set; }
        WFValidationResult<T> result;
        public DecisionChangeStateManager(int userId, int userCorporateUnitId, int decisionId, T decision, ILogger<LoanPhaseOneOrchestrator> logger, IGenericRepository<Loan> loanRepository, IGenericRepository<Collateral> collateralRepository, IGenericRepository<Asset> assetRepository)
            : base(userCorporateUnitId, decisionId)
        {
            DecisionId = decisionId;
            result = new WFValidationResult<T>(decision);
            _logger = logger;
            _loanRepository = loanRepository;
            _collateralRepository = collateralRepository;
            _assetRepository = assetRepository;

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

            LoanPhaseOneOrchestrator loanPhaseOneOrchestrator = new LoanPhaseOneOrchestrator(new BaseOrchestratorRequest()
            {
                //refactor to get user name
                UserName = UserId.ToString()
            }, _logger, _loanRepository, _collateralRepository, _assetRepository);
        }


        public override void ExecuteChangeState()
        {
            //call service method ChangeState
            
        }

    }
}
