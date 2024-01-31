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

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee) 
        {
            if(ModelState.IsValid) 
            {
                _employeeRepository.CreateEmp(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


    }
}
