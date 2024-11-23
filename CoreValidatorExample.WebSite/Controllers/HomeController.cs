using CoreMVCValidatorExample.Models;
using CoreValidatorExample.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CoreValidatorExample.WebApi.Sdk;
using CoreValidatorExample.WebApi.Sdk.Client;

namespace CoreMVCValidatorExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoreValidatorExample.WebApi.Sdk.Client.CoreValidatorExampleWebApiSdk _serviceClient;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, CoreValidatorExampleWebApiSdk proposalSvcRepository)
        {
            _logger = logger;
            _serviceClient = proposalSvcRepository;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            return View(model);
        }

        public IActionResult TestWorkflowAndApiCall()
        {
            HomeViewModel model = new HomeViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ProposalChangeState(HomeViewModel homeViewModel)
        {
            HomeModel homeModel = new HomeModel(_serviceClient);
            //validation
            AppraisalChangeStateSvcRequest request = new AppraisalChangeStateSvcRequest();
            request.AppraisalId = 1;
            request.UserId = 2;
            request.ActionName = 3;
            homeModel.ProposalChangeState(request);
            homeViewModel = homeModel.GenerateViewModel();

            return View("TestWorkflowAndApiCall", homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}