using BilgeAdam.Contracts;
using BilgeAdam.Services;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVC.QuickStart.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var service = new EmployeeService();
            var result = service.GetEmployees();
            return Json(result);
        }

        [HttpPost]
        public IActionResult Save([FromBody]NewEmployeeInputModel model)
        {
            var service = new EmployeeService();
            var result = service.Insert(model);
            return Json(result);
        }
    }
}