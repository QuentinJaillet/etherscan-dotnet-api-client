using System.Diagnostics;
using Etherscan.Api.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAccountClient _accountClient;

        public HomeController(ILogger<HomeController> logger, IAccountClient accountClient)
        {
            _logger = logger;
            _accountClient = accountClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EtherAddressViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var balance = _accountClient.GetEtherBalanceOfAddress(model.Address);

            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
