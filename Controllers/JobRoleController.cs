using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
    public class JobRoleController : Controller
    {
        private IJobRoleRepository _jobRoleRepository;
        private IDepartmentRepository _departmentRepository;
        private readonly INotyfService _notyfService;

        public JobRoleController(IJobRoleRepository jobRoleRepository, IDepartmentRepository departmentRepository, INotyfService notyfService)
        {
            _jobRoleRepository = jobRoleRepository;
            _departmentRepository = departmentRepository;
            _notyfService = notyfService;
        }

        public IActionResult Index() 
        {
            var jobRoleList = _jobRoleRepository.GetJobRoles();
            return View(jobRoleList);
        }

        public IActionResult CreateJobRole()
        {
            var departments = _departmentRepository.GetDepartments();

            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CreateJobRole(JobRole jobRole) 
        {
            if (ModelState.IsValid)
            {
                var jobRoleDB = _jobRoleRepository.GetJobRoleById(jobRole.JobRoleId);

                if (jobRoleDB == null)
                {
                    _jobRoleRepository.CreateJobRole(jobRole);
                    _notyfService.Success("Uspešno ste uneli podatke");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Poslovna pozicija vec postoji.");
                    return View(jobRole);
                }
            }
            return RedirectToAction("CreateJobRole", jobRole);
        }

        public IActionResult EditJobRole(int id)
        {
            var jobRole = _jobRoleRepository.GetJobRoleById(id);

            var vm = new EditJobRoleViewModel()
            {
                JobRoleId = jobRole.JobRoleId,
                Title = jobRole.Title,
                Description = jobRole.Description
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditJobRole(EditJobRoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var jobRole = _jobRoleRepository.GetJobRoleById(vm.JobRoleId);
                jobRole.Title = vm.Title;
                jobRole.Description = vm.Description;

                _jobRoleRepository.UpdateJobRole(vm.JobRoleId);
                _notyfService.Success("Uspešno ste izmenili podatke");

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public IActionResult DeleteJobRole(int id) 
        {
            _jobRoleRepository.DeleteJobRole(id);
            _notyfService.Success("Uspešno ste obrisali podatke");

            return RedirectToAction("Index");
        }
    }
}
