using CoreValidatorExample.BusinessLayer;
using CoreValidatorExample.BusinessLayer.WebAPI;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ChangeStateManager.Factory;
namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class ProposalSvcRepository
    {
        private ChangeStateManagerFactory ChangeStateManagerFactory;

        public ProposalSvcRepository()
        {
            //TODO add default IoC behaviour
            this.ChangeStateManagerFactory = new ChangeStateManagerFactory();
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

        public ProposalChangeStateSvcResponse ProposalChangeState(ProposalChangeStateSvcRequest request)
        {
            List<SvcValidationMsg> svcValidationMsgs = new List<SvcValidationMsg>();
            //simulate success
            ProposalChangeStateSvcResponse response = new ProposalChangeStateSvcResponse();

            ProposalChangeStateManager manager = (ProposalChangeStateManager)this.ChangeStateManagerFactory.GetObjectInstance<ProposalChangeStateManager>(request.UserId, request.UserCorporateUnitId, request.ProposalId);

            svcValidationMsgs = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }

    }
}