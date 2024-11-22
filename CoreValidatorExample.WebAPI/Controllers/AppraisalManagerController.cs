using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreValidatorExample.Internal.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppraisalManagerController : ControllerBase
    {      

        private readonly ILogger<AppraisalManagerController> _logger;
        private IAppraisalService _service;
        public AppraisalManagerController(ILogger<AppraisalManagerController> logger, IAppraisalService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public AppraisalChangeStateSvcResponse AppraisalChangeState(AppraisalChangeStateSvcRequest request)
        {
            var response = new AppraisalChangeStateSvcResponse();

            response = _service.AppraisalChangeState(request);
            
            return response;

        }

        [HttpGet(Name = "TestMethod")]
        public string TestMethod(string request)
        {
            var response = $"You entered: {request}";          

            return response;

        }
    }
}
