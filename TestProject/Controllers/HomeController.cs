using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestProject.BusinessLayer.Interfases;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBL _userBL;

        public HomeController(ILogger<HomeController> logger, IUserBL userBL)
        {
            _logger = logger;
            _userBL = userBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(Json(model));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}