using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
        public IActionResult Index(int idCompany)
        {
            return JsonCyrillic(_userBL.GetEmployeesByIdCompany(idCompany));
        }

        [HttpPost]
        public IActionResult Index(string departmentName)
        {
            return JsonCyrillic(_userBL.GetEmployeeByDepartment(departmentName));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private JsonResult JsonCyrillic(object? data)
        {
            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            return Json(data, options);
        }
    }
}