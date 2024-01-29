using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employList = _employeeRepository.GetAllEmployees;
            return View(employList);
        }

        public ViewResult List()
        {
            return View();
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }
    }
}
