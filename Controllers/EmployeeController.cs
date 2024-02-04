using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobRoleRepository _jobRoleRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IJobRoleRepository jobRoleRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _jobRoleRepository = jobRoleRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var employeeList = _employeeRepository.ListOfAllEmployees();
            return View(employeeList);
        }

        public IActionResult CreateEmployee()
        {
            var departments = _departmentRepository.GetDepartments();
      
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
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
            if (ModelState.IsValid) 
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

                return RedirectToAction("Index");
            }
            //proveriti ovo
            return View(vm); 
        }

        public IActionResult DeleteEmployee(int id) 
        {
            _employeeRepository.DeleteEmp(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if(ModelState.IsValid) 
            {
                var employee = _employeeRepository.GetEmployeeById(id);
                return View(employee);
            }

            return RedirectToAction("Index");
          
        }
    }
}
