using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.WebAPI;
using System.Net.Http.Headers;
namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class AppraisalSvcRepository
    {
        private ChangeStateManagerFactory<Appraisal> ChangeStateManagerFactory;

        public AppraisalSvcRepository(ChangeStateManagerFactory<Appraisal>  changeStateManagerFactory)
        {
            this.ChangeStateManagerFactory = changeStateManagerFactory;
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
        public AppraisalChangeStateSvcResponse AppraisalChangeState(AppraisalChangeStateSvcRequest request)
        {

            Appraisal appraisal = new Appraisal();
            WFValidationResult<Appraisal> svcValidationMsgs = new WFValidationResult<Appraisal>();
            //simulate success
            AppraisalChangeStateSvcResponse response = new AppraisalChangeStateSvcResponse();

            ChangeStateManagerFactory.ObjectInstance = appraisal;
            AppraisalChangeStateManager<Appraisal> manager = (AppraisalChangeStateManager<Appraisal>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001);


            svcValidationMsgs = manager.ValidateAndExecute(request.EventId);
            response.Success = true;
            return response;
        }

        public void AppraisalChangeStateChainOfResponsibility()
        {
            //MOCK
            int userID = 1;
            int corporateStructureID = 1;
            int appraisalID = 1;
            int eventID = 1;
            var appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1),  // Appraisal was submitted in the past
                AppraiserName = "John Doe",
                AppraiseeName = "Jane Smith",
                AppraisalScore = 4.5m
            };

            // This `appraisal` object would then be passed to the `ChangeStateValidatorManager` for validation.
            AppraisalChangeStateManager<Appraisal> manager = (AppraisalChangeStateManager<Appraisal>)ChangeStateManagerFactory.GetObjectInstance(userID, corporateStructureID, appraisalID);
            var result = manager.ValidateAndExecute(eventID);
            //TODO
        }
    }
}