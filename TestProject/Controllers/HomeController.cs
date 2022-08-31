using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using TestProject.BusinessLayer.Interfases;
using TestProject.DataAccessLayer.Models;
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

        [HttpPost("Home/Receive/idCompany")]
        public IActionResult Receive(int idCompany)
        {
            return JsonCyrillic(_userBL.GetEmployeesByIdCompany(idCompany));
        }

        [HttpPost("Home/Receive/departmentName")]
        public IActionResult Receive(string departmentName)
        {
           return JsonCyrillic(_userBL.GetEmployeeByDepartment(departmentName));
        }
        [HttpPost("Home/Create/model")]
        public IActionResult Create(EmployeeModel model)
        {
            return JsonCyrillic(_userBL.CreateEmployee(model));
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