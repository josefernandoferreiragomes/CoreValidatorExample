using CoreMVCValidatorExample.Models;
using CoreValidatorExample.WebSite.Data;
using CoreValidatorExample.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace CoreMVCValidatorExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            HomeModel model = new HomeModel();
            model.GetDataFromApi();
            return View(model);
        }
        public IActionResult Save(HomeModel model) 
        {

            return View("Privacy", model);
        }

        public IActionResult ProposalChangeState(HomeModel model)
        {
            //validation
            ProposalSvcRequest request = new ProposalSvcRequest();
            request.ProposalId = 1;
            request.UserId = 2;
            request.ActionName = 3;
            model.ProposalChangeState(request);

            return View("Privacy", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}