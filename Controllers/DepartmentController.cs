using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly INotyfService _notyfService;

        public DepartmentController(IDepartmentRepository departmentRepository, INotyfService notyfService)
        {
            _departmentRepository = departmentRepository;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            var departmentList = _departmentRepository.GetDepartments();
            return View(departmentList);
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
                _departmentRepository.CreateDepart(department);
                _notyfService.Success("Uspešno ste uneli podatke");

                return RedirectToAction("Index");
            }    
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
