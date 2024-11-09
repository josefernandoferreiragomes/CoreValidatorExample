using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Data.Enums;
using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class AppraisalChangeStateManager<T> : ChangeStateManagerBase<T>
        where T : Appraisal
    {
        WFValidationResult<T> result;

        public ILogger<LoanPhaseOneOrchestrator> _logger { get; set; }
        public IGenericRepository<Loan> _loanRepository { get; set; }
        public IGenericRepository<Collateral> _collateralRepository { get; set; }
        public IGenericRepository<Asset> _assetRepository { get; set; }
        private int AppraisalId {  get; set; }

        public AppraisalChangeStateManager(int userId, int userCorporateUnitId, int appraisalId, T appraisal, ILogger<LoanPhaseOneOrchestrator> logger, IGenericRepository<Loan> loanRepository, IGenericRepository<Collateral> collateralRepository, IGenericRepository<Asset> assetRepository) 
            : base (userCorporateUnitId, appraisalId)
        {
            AppraisalId = appraisalId;
            result = new WFValidationResult<T>(appraisal);
            _logger = logger;
            _loanRepository = loanRepository;
            _collateralRepository = collateralRepository;
            _assetRepository = assetRepository;
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
            var appraisalValidatorExecuter = this.ValidatorExecuterFactory.GetObjectInstance<AppraisalValidatorExecuter>();
            appraisalValidatorExecuter.Validate(ObjectInstance.SubmissionDate);
            //remaining validation or execution logic
            ExecuteChangeState();
        }
        
        public override void ExecuteChangeState()
        {
            //call service method ChangeState
        }
        
    }
}
