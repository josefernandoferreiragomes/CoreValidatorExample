using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface IAppraisalService
    {

    }
    public class AppraisalService
    {
        private IChangeStateManagerFactory<Appraisal> ChangeStateManagerFactory;

        public AppraisalService(IChangeStateManagerFactory<Appraisal> changeStateManagerFactory)
        {
            this.ChangeStateManagerFactory = changeStateManagerFactory;
        }

        //TO BE REFACTORED
        public AppraisalChangeStateSvcResponse AppraisalChangeState(AppraisalChangeStateSvcRequest request)
        {

            Appraisal appraisal = new Appraisal();
            WFValidationResult<Appraisal> svcValidationMsgs = new WFValidationResult<Appraisal>();
            //simulate success
            AppraisalChangeStateSvcResponse response = new AppraisalChangeStateSvcResponse();

            //ChangeStateManagerFactory.ObjectInstance = appraisal;
            AppraisalChangeStateManager<Appraisal> manager = (AppraisalChangeStateManager<Appraisal>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001);


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
            AppraisalChangeStateManager<Appraisal> manager = (AppraisalChangeStateManager<Appraisal>)ChangeStateManagerFactory.GetObjectInstance(userID, corporateStructureID, appraisalID);
            var result = manager.ValidateAndExecute(eventID);
            //TODO
        }
    }
}
