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

        [HttpGet(Name = "GetWeatherForecast")]
        public AppraisalChangeStateSvcResponse Get(AppraisalChangeStateSvcRequest request)
        {
            var response = new AppraisalChangeStateSvcResponse();

            response = _service.AppraisalChangeState(request);
            
            return response;

        }
    }
}
