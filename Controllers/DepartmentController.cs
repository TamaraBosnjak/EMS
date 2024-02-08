using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly INotyfService _notyfService;
        private readonly IUserRepository _userRepository;

        public DepartmentController(IDepartmentRepository departmentRepository, INotyfService notyfService, IUserRepository userRepository)
        {
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
                var departmentList = _departmentRepository.GetDepartments();
                return View(departmentList);
            }
            return RedirectToAction("Login", "User");
        }   

        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department department) 
        {
            if(ModelState.IsValid)
            {
                var departmentDB = _departmentRepository.GetDepartmentByName(department.Name);

                if (departmentDB == null)
                {
                    _departmentRepository.CreateDepart(department);
                    _notyfService.Success("Uspešno ste uneli podatke");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sektor vec postoji.");
                    return View(department);
                }
            }
            ModelState.AddModelError("", "Nedovoljan unos podataka. Obratite se IT podrsci.");
            return View(department);
        }

        public IActionResult EditDepartment(int id) 
        {
            var department = _departmentRepository.GetDepartmentById(id);

            var vm = new EditDepartmentViewModel()
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Description = department.Description
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditDepartment(EditDepartmentViewModel vm) 
        {
            if(ModelState.IsValid)
            {
                var department = _departmentRepository.GetDepartmentById(vm.DepartmentId);
                department.Name = vm.Name;
                department.Description = vm.Description;

                _departmentRepository.UpdateDepart(vm.DepartmentId);
                _notyfService.Success("Uspešno ste izmenili podatke");

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public IActionResult DeleteDepartment(int id) 
        {
            _departmentRepository.DeleteDepart(id);
            _notyfService.Success("Uspešno ste obrisali podatke");

            return RedirectToAction("Index");
        }
    }
}
