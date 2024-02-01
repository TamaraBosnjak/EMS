using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
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

        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            var vm = new EditEmployeeViewModel()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                BirthDate = employee.BirthDate,
                EmploymentStartDate = employee.EmploymentStartDate,
                EmploymentEndDate = employee.EmploymentEndDate
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditEmployee(EditEmployeeViewModel vm)
        {
            var employee = _employeeRepository.GetEmployeeById(vm.EmployeeId);
            employee.FirstName = vm.FirstName;
            employee.LastName = vm.LastName;    
            employee.Email = vm.Email;
            employee.Address = vm.Address;
            employee.PhoneNumber = vm.PhoneNumber;
            employee.BirthDate = vm.BirthDate;
            employee.EmploymentStartDate = vm.EmploymentStartDate;
            employee.EmploymentEndDate = vm.EmploymentEndDate;

            _employeeRepository.UpdateEmp(vm.EmployeeId);

            return RedirectToAction("Index", "Employee");
            
        }

        public IActionResult DeleteEmployee(int id) 
        {
            _employeeRepository.DeleteEmp(id);

            return View();
        }
    }
}
