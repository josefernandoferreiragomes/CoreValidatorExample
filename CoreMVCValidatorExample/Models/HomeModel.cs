using CoreValidatorExample.APILibrary.Data;
//using CoreValidatorExample.WebSite.Repository;
using CoreValidatorExample.APILibrary.Repository;

namespace CoreValidatorExample.WebSite.Models
{
    public class HomeModel //: SvcRepository
    {
        ProposalSvcRepository ProposalSvcRepository;
        public HomeModel()
        {
            DataFromModel = "example string from model";
            ProposalSvcRepository = new ProposalSvcRepository();
        }

        public string DataFromModel { get; set; }

        public string Designation { get; set; }

        public string ChangeStateResultMessage { get; set; }
        public void GetDataFromApi()
        {
            this.DataFromModel = ProposalSvcRepository.GetDataFromApi();
        }

        public ProposalChangeStateSvcResponse ProposalChangeState(ProposalChangeStateSvcRequest request)
        {
            ProposalChangeStateSvcResponse result = new ProposalChangeStateSvcResponse();

            var validationResult = ProposalSvcRepository.ProposalChangeState(request);

            return result;
        }

    }
}
