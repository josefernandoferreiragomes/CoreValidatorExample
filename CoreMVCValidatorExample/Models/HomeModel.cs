using CoreValidatorExample.WebAPIRef;
using CoreValidatorExample.WebSite.Data;
using CoreValidatorExample.WebSite.Repository;
using CoreValidatorExample.WebSite.ValidationHelper;

namespace CoreValidatorExample.WebSite.Models
{
    public class HomeModel : SvcRepository
    {
        public HomeModel()
        {
            DataFromModel = "example string from model";
        }

        public string DataFromModel { get; set; }

        public string Designation { get; set; }

        public string ChangeStateResultMessage { get; set; }
        public void GetDataFromApi()
        {
            this.DataFromModel = SvcRepository.GetDataFromApi();
        }

        public ProposalSvcResponse ProposalChangeState(ProposalSvcRequest request)
        {
            ProposalSvcResponse result = new ProposalSvcResponse();

            ProposalStateValidatorHelper helper = new ProposalStateValidatorHelper(request);
            if (helper.ValidateSimple(request).IsSuccess)
            {
                result = SvcRepository.ProposalChangeState(request);
            }
            
           
            return result;
        }

        //would be in a different controller
        public DecisionSvcResponse DecisionChangeState(DecisionSvcRequest request)
        {
            DecisionSvcResponse result = new DecisionSvcResponse();
            //if (ValidatorFactory.Validate<DecisionSvcRequest>(request).IsSuccess)
            //{
            //    result = SvcRepository.DecisionChangeState(request);
            //}
            return result;
        }
    }
}
