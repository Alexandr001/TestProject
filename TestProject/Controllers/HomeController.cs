using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TestProject.BusinessLayer.Interfases;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeBL _userBL;

        public HomeController(ILogger<HomeController> logger, IEmployeeBL userBL)
        {
            _logger = logger;
            _userBL = userBL;
        }
       
        #region Viev
        [HttpGet]
        public IActionResult Index() => View();
        [HttpGet]
        public IActionResult Create() => View();
        [HttpGet]
        public IActionResult Delete() => View();
        [HttpGet]
        public IActionResult Receive() => View();
        [HttpGet]
        public IActionResult Change() => View();
        #endregion

        [HttpPost]
        public IActionResult Receive(int idCompany)
        {
          
                _logger.LogDebug(Json(idCompany).ToString());
                return Json(_userBL.GetEmployeesByIdCompany(idCompany));
          
        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}