using CoreValidatorExample.APILibrary.WebAPI;
using CoreMVCValidatorExample.APILibrary.Data;

namespace CoreMVCValidatorExample.APILibrary.Repository
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

            CoreValidatorExample.APILibrary.WebAPI.WebAPIClassReference apiReference = new WebAPIClassReference(address, httpClient);

            WeatherForecast forecast = apiReference.GetWeatherForecastAsync().Result.First();
            result = string.Format("{0} {1}", forecast.Summary, forecast.TemperatureC);
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