using CoreValidatorExample.APILibrary;
using CoreValidatorExample.APILibrary.WebAPI;
using CoreValidatorExample.APILibrary.Data;
using CoreValidatorExample.APILibrary.ChangeStateManager.Factory;
namespace CoreValidatorExample.APILibrary.Repository
{
    public class AppraisalSvcRepository
    {
        private ValidatorExecuterFactory ValidatorExecuterFactory;

        public AppraisalSvcRepository()
        {
            this.ValidatorExecuterFactory = new ValidatorExecuterFactory();
        }

        public string GetDataFromApi()
        {
            //example service call
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

        public AppraisalChangeStateSvcResponse AppraisalChangeState(AppraisalChangeStateSvcRequest request)
        {
            List<SvcValidationMsg> svcValidationMsgs = new List<SvcValidationMsg>();
            //simulate success
            AppraisalChangeStateSvcResponse response = new AppraisalChangeStateSvcResponse();

            AppraisalChangeStateManager manager = (AppraisalChangeStateManager)this.ValidatorExecuterFactory.GetObjectInstance<AppraisalChangeStateManager>();
            
            svcValidationMsgs = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }

    }
}