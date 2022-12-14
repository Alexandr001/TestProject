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
        private readonly IEmployeeBl _userBl;

        public HomeController(ILogger<HomeController> logger, IEmployeeBl userBl)
        {
            _logger = logger;
            _userBl = userBl;
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

        #region Receive

        [HttpPost("Home/Receive/idCompany")]
        public IActionResult Receive(int idCompany)
        {
            try {
                IEnumerable<EmployeeModel> models = _userBl.GetEmployeesByIdCompany(idCompany);
                return Json(models);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Home/Receive/departmentName")]
        public IActionResult Receive(string departmentName)
        {
            try {
                IEnumerable<EmployeeModel> models = _userBl.GetEmployeeByDepartment(departmentName);
                return Json(models);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        #endregion

        [HttpPost("Home/Create")]
        public IActionResult Create(EmployeeModel model)
        {
            try {
                int idEmployee = _userBl.CreateEmployee(model);
                return Json(idEmployee);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost("Home/Delete")]
        public IActionResult Delete(int id)
        {
            try {
                _userBl.DeleteEmployee(id);
                return Index();
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Home/Change")]
        public IActionResult Change(EmployeeModel model)
        {
            try {
                _userBl.UpdateEmployee(model.Id, model);
                return Index();
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*private JsonResult JsonCyrillic(object? data)
        {
            var options = new JsonSerializerOptions()
            {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true
            };
            return Json(data, options);
        }*/
    }
}