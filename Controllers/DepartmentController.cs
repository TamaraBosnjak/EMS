using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
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

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public IActionResult DeleteDepartment(int id) 
        {
            _departmentRepository.DeleteDepart(id);
            return RedirectToAction("Index");
        }
    }
}
