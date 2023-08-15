using CoreValidatorExample.WebAPIRef;
using CoreValidatorExample.WebSite.Data;

namespace CoreValidatorExample.WebSite.Repository
{
    public class SvcRepository
    {
        public static string GetDataFromApi()
        {
            string result = "";
            string address = @"http://localhost:5108/";
            HttpClient httpClient = new HttpClient();
            Uri addressUri = new Uri(address);
            httpClient.BaseAddress = addressUri;

            CoreWebAPIRef apiReference = new CoreWebAPIRef(address, httpClient);

            result = apiReference.GetWeatherForecastAsync().Result.ToString();
            return result;
        }

        public static ProposalSvcResponse ProposalChangeState(ProposalSvcRequest request)
        {
            //simulate success
            ProposalSvcResponse response = new ProposalSvcResponse();
            response.Success = true;
            return response;
        }

        public static DecisionSvcResponse DecisionChangeState(DecisionSvcRequest request)
        {
            //simulate success
            DecisionSvcResponse response = new DecisionSvcResponse();
            response.Success = true;
            return response;
        }
    }
}