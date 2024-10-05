using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.WebAPI;
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

        //TO BE REFACTORED
        public ProposalChangeStateSvcResponse ProposalChangeState(ProposalChangeStateSvcRequest request)
        {
            
            WFValidationResult<Proposal> result = new WFValidationResult<Proposal>();
            //simulate success
            ProposalChangeStateSvcResponse response = new ProposalChangeStateSvcResponse();

            ProposalChangeStateManager<Proposal> manager = (ProposalChangeStateManager<Proposal>)this.ChangeStateManagerFactory.GetObjectInstance<ProposalChangeStateManager<Proposal>>(request.UserId, request.UserCorporateUnitId, request.ProposalId);

            result = manager.ValidateAndExecute(request.EventId);
            return response;
        }

    }
}