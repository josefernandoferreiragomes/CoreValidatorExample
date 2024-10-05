using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.WebAPI;
namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class DecisionSvcRepository
    {
        private ChangeStateManagerFactory<Decision> ChangeStateManagerFactory;

        public DecisionSvcRepository()
        {
            this.ChangeStateManagerFactory = new ChangeStateManagerFactory<Decision>();
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

        //TO BE REFACTORED
        public DecisionChangeStateSvcResponse DecisionChangeState(DecisionChangeStateSvcRequest request)
        {
            WFValidationResult<Decision> result = new WFValidationResult<Decision>();
            //simulate success
            DecisionChangeStateSvcResponse response = new DecisionChangeStateSvcResponse();
            
            Decision decision = new Decision();
            ChangeStateManagerFactory.ObjectInstance = decision;
            DecisionChangeStateManager<Decision> manager = (DecisionChangeStateManager<Decision>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001);
            
            result = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }
    }
}