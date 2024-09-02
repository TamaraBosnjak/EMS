using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmployeeManagementSystem.Controllers
{
    public class JobRoleController : Controller
    {
        private readonly IJobRoleRepository _jobRoleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly INotyfService _notyfService;
        private readonly IUserRepository _userRepository;

        public JobRoleController(IJobRoleRepository jobRoleRepository, IDepartmentRepository departmentRepository, INotyfService notyfService, IUserRepository userRepository)
        {
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
                var jobRoleList = _jobRoleRepository.GetJobRoles();
                return View(jobRoleList);
            }

            return RedirectToAction("Login", "User");
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
            //var departments = _departmentRepository.GetDepartments();
            var departments = _departmentRepository.GetDepartmentById(jobRole.DepartmentId);

            //ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
            ViewBag.Departments = departments;

            if (ModelState.IsValid)
            {
                var jobRoleDB = _jobRoleRepository.GetJobRoleByName(jobRole.Title);

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

            return RedirectToAction();
        }

        public IActionResult EditJobRole(int id)
        {
            var departments = _departmentRepository.GetDepartments();


            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            var jobRole = _jobRoleRepository.GetJobRoleById(id);

            var vm = new EditJobRoleViewModel()
            {
                JobRoleId = jobRole.JobRoleId,
                Title = jobRole.Title,
                Description = jobRole.Description,
                DepartmentId = jobRole.DepartmentId
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
                jobRole.DepartmentId = vm.DepartmentId;

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
