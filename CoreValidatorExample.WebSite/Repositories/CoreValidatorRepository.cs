using CoreValidatorExample.WebApi.Sdk.Client;

namespace CoreValidatorExample.WebSite.Repositories
{
    public interface ICoreValidatorRepository
    {
        Task<AppraisalChangeStateSvcResponse> ProposalChangeState(AppraisalChangeStateSvcRequest request);
    }

    public class CoreValidatorRepository : ICoreValidatorRepository
    {
        private IConfiguration _configuration;
        private ILogger<CoreValidatorRepository> _logger;
        private string _url;
        public CoreValidatorRepository(IConfiguration configuration, ILogger<CoreValidatorRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _url = (string)_configuration.GetValue(typeof(string), "CoreValidatorExampleApi");
        }
            
        
        public async Task<AppraisalChangeStateSvcResponse> ProposalChangeState(AppraisalChangeStateSvcRequest request)
        {
            try
            {
                AppraisalChangeStateSvcResponse result;

                using (var httpClient = new HttpClient())                
                {
                    var client = new CoreValidatorExampleWebApiSdk(_url, httpClient);
                    result = await client.AppraisalChangeStateAsync(request);                   
                }
                return result;
            }
            catch (Exception ex)
            {
                //TODO handle exception
                throw ex;
            }
        }
    }
}
