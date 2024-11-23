using CoreValidatorExample.WebApi.Sdk.Client;
using CoreValidatorExample.WebSite.Repositories;

namespace CoreValidatorExample.WebSite.Models
{
    
    public class HomeModel
    {
        ICoreValidatorRepository _proposalSvcRepository;
        public HomeModel(ICoreValidatorRepository coreValidatorExampleWebApiSdkClient)
        {
            _proposalSvcRepository = coreValidatorExampleWebApiSdkClient;
            ChangeStateResultMessage = "State not changed yet";
        }


        public string ChangeStateResultMessage { get; set; }

        public async Task<AppraisalChangeStateSvcResponse> ProposalChangeState(AppraisalChangeStateSvcRequest request)
        {
            var result = await _proposalSvcRepository.ProposalChangeState(request);
            if (result != null && result.Success)
            {
                ChangeStateResultMessage = "State Change Successful";
            }
            else
            {
                ChangeStateResultMessage = $"Error on State Change: {result.SvcErrorMsgs.FirstOrDefault()}";
            }
            return result;
        }

        public HomeViewModel GenerateViewModel()
        => new HomeViewModel() { ChangeStateResultMessage = this.ChangeStateResultMessage };        

    }
}
