using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobRoleRepository _jobRoleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly INotyfService _notyfService;
        private readonly IUserRepository _userRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IJobRoleRepository jobRoleRepository, IDepartmentRepository departmentRepository, INotyfService notyfService, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _jobRoleRepository = jobRoleRepository;
            _departmentRepository = departmentRepository;
            _notyfService = notyfService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        { 
            var userCookie = Request.Cookies["User"];

            if (userCookie == null)
            {
                return RedirectToAction("Login", "User");
            }

            var user = JsonConvert.DeserializeObject<User>(userCookie!);

            if (user != null)
            {
                var employeeList = _employeeRepository.ListOfAllEmployees();
                return View(employeeList);
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var employeeList = _employeeRepository.ListOfAllEmployees();

            if (!string.IsNullOrEmpty(searchString))
            {
                employeeList = employeeList.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString)).ToList();
            }
            return View(employeeList);
        }

        public IActionResult CreateEmployee()
        {
            var departments = _departmentRepository.GetDepartments();
            var jobRoles = _jobRoleRepository.GetJobRoles();
      
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
            ViewBag.JobRoles = new SelectList(jobRoles, "JobRoleId", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee) 
        {
            if(ModelState.IsValid) 
            {
                var employeeDB = _employeeRepository.GetEmployeeByEmail(employee.Email);
                if (employeeDB == null)
                {
                    _employeeRepository.CreateEmp(employee);
                    _notyfService.Success("Uspešno ste uneli podatke");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Korisnik sa unetom email adresom je vec registrovan.");
                    return View(employee);
                }
                
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
                _notyfService.Success("Uspešno ste izmenili podatke");

                return RedirectToAction("Index");
            }
            
            return View(vm); 
        }

        public IActionResult DeleteEmployee(int id) 
        {
            _employeeRepository.DeleteEmp(id);
            _notyfService.Success("Uspešno ste obrisali podatke");

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
