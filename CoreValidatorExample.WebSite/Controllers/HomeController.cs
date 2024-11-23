using CoreMVCValidatorExample.Models;
using CoreValidatorExample.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreMVCValidatorExample.Controllers
{
    public class HomeController : Controller
    {        
        //private readonly IProposalService _proposalSvcRepository;      
        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger, IProposalService proposalSvcRepository)
        //{
        //    _logger = logger;
        //    _proposalSvcRepository = proposalSvcRepository;
        //}

        //public IActionResult Index()
        //{
        //    HomeViewModel model = new HomeViewModel();

        //    return View(model);
        //}

        //public IActionResult TestWorkflowAndApiCall()
        //{
        //    HomeViewModel model = new HomeViewModel();            
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult ProposalChangeState(HomeViewModel homeViewModel)
        //{
        //    HomeModel homeModel = new HomeModel(_proposalSvcRepository);
        //    //validation
        //    ProposalChangeStateSvcRequest request = new ProposalChangeStateSvcRequest();
        //    request.ProposalId = 1;
        //    request.UserId = 2;
        //    request.ActionName = 3;
        //    homeModel.ProposalChangeState(request);
        //    homeViewModel = homeModel.GenerateViewModel();
            
        //    return View("TestWorkflowAndApiCall", homeViewModel);
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}