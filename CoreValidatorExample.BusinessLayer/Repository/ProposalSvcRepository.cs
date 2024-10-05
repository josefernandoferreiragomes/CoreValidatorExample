using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.WebAPI;
namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class ProposalSvcRepository
    {
        private ChangeStateManagerFactory<Proposal> ChangeStateManagerFactory;

        public ProposalSvcRepository()
        {
            //TODO add default IoC behaviour
            this.ChangeStateManagerFactory = new ChangeStateManagerFactory<Proposal>();
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
        public ProposalChangeStateSvcResponse ProposalChangeState(ProposalChangeStateSvcRequest request)
        {
            
            WFValidationResult<Proposal> result = new WFValidationResult<Proposal>();
            //simulate success
            ProposalChangeStateSvcResponse response = new ProposalChangeStateSvcResponse();
            Proposal proposal = new Proposal();
            ProposalChangeStateManager<Proposal> manager = (ProposalChangeStateManager<Proposal>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001);

            result = manager.ValidateAndExecute(request.EventId);
            return response;
        }

    }
}