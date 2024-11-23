using CoreValidatorExample.WebApi.Sdk.Client;

namespace CoreValidatorExample.WebSite.Models
{
    //to be removed direct references...and data accessd by API
    public class HomeModel
    {
        CoreValidatorExampleWebApiSdk _proposalSvcRepository;
        public HomeModel(CoreValidatorExampleWebApiSdk coreValidatorExampleWebApiSdkClient)
        {
            _proposalSvcRepository = coreValidatorExampleWebApiSdkClient;
            ChangeStateResultMessage = "State not changed yet";
        }


        public string ChangeStateResultMessage { get; set; }

        public async Task<AppraisalChangeStateSvcResponse> ProposalChangeState(AppraisalChangeStateSvcRequest request)
        {
            try
            {
                AppraisalChangeStateSvcResponse result;

                result = await _proposalSvcRepository.GetWeatherForecastAsync (request);

                if (result != null && result.Success)
                {
                    ChangeStateResultMessage = "State Change Successful";
                }
                else
                {
                    ChangeStateResultMessage = "Error on State Change";
                }
                return result;
            }
            catch (Exception ex)
            {
                //TODO handle exception
                throw ex;
            }

        }

        public HomeViewModel GenerateViewModel()
        {
            return new HomeViewModel()
            {
                ChangeStateResultMessage = this.ChangeStateResultMessage
            };
        }

    }
}
