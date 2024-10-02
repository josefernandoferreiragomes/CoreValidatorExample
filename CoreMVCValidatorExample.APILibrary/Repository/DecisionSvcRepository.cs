using CoreValidatorExample.BusinessLayer;
using CoreValidatorExample.BusinessLayer.WebAPI;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ChangeStateManager.Factory;
namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class DecisionSvcRepository
    {
        private ValidatorExecuterFactory ValidatorExecuterFactory;

        public DecisionSvcRepository()
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

            CoreValidatorExample.BusinessLayer.WebAPI.WebAPIClassReference apiReference = new WebAPIClassReference(address, httpClient);

            WeatherForecast forecast = apiReference.GetWeatherForecastAsync().Result.First();
            result = string.Format("{0} {1}", forecast.Summary, forecast.TemperatureC);
            return result;
        }

        public DecisionChangeStateSvcResponse DecisionChangeState(DecisionChangeStateSvcRequest request)
        {
            List<SvcValidationMsg> svcValidationMsgs = new List<SvcValidationMsg>();
            //simulate success
            DecisionChangeStateSvcResponse response = new DecisionChangeStateSvcResponse();

            DecisionChangeStateManager manager = (DecisionChangeStateManager)this.ValidatorExecuterFactory.GetObjectInstance<DecisionChangeStateManager>();
            
            svcValidationMsgs = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }
    }
}