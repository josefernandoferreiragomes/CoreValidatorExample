using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.BusinessLayer.Repository;
using CoreValidatorExample.DataAccessLayer.Interfaces;
using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface IAppraisalService
    {
        public AppraisalChangeStateSvcResponse AppraisalChangeState(AppraisalChangeStateSvcRequest request);
        public void AppraisalChangeStateChainOfResponsibility();
    }
    public class AppraisalService : IAppraisalService
    {
        private IChangeStateManagerFactory<Appraisal> ChangeStateManagerFactory;
        private IGenericRepository<Appraisal> _appraisalRepository;

        public AppraisalService(IChangeStateManagerFactory<Appraisal> changeStateManagerFactory, IGenericRepository<Appraisal> appraisalRepository)
        {
            this.ChangeStateManagerFactory = changeStateManagerFactory;
            _appraisalRepository = appraisalRepository;
        }

        //TO BE REFACTORED
        public AppraisalChangeStateSvcResponse AppraisalChangeState(AppraisalChangeStateSvcRequest request)
        {

            var appraisal = _appraisalRepository.GetByIdAsync(request.AppraisalId);

            WFValidationResult<Appraisal> svcValidationMsgs = new WFValidationResult<Appraisal>();
            //simulate success
            AppraisalChangeStateSvcResponse response = new AppraisalChangeStateSvcResponse();

            //_changeStateManagerFactory.ObjectInstance = appraisal;
            AppraisalChangeStateManager<Appraisal> manager = (AppraisalChangeStateManager<Appraisal>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001, appraisal.Result);
          
            svcValidationMsgs = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }

        public void AppraisalChangeStateChainOfResponsibility()
        {
            //MOCK
            int userID = 1;
            int corporateStructureID = 1;
            int appraisalID = 1;
            int eventID = 1;
            var appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1),  // Appraisal was submitted in the past
                AppraiserName = "John Doe",
                AppraiseeName = "Jane Smith",
                AppraisalScore = 4.5m
            };

            // This `appraisal` object would then be passed to the `ChangeStateValidatorManager` for validation.
            AppraisalChangeStateManager<Appraisal> manager = (AppraisalChangeStateManager<Appraisal>)ChangeStateManagerFactory.GetObjectInstance(userID, corporateStructureID, appraisalID, appraisal);
            var result = manager.ValidateAndExecute(eventID);
            //TODO
        }
    }
}
