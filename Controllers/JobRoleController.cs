using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class JobRoleController : Controller
    {
        private IJobRoleRepository _jobRoleRepository;

        public JobRoleController(IJobRoleRepository jobRoleRepository)
        {
            _jobRoleRepository = jobRoleRepository;
        }

        public IActionResult Index() 
        {
            return View();
        }
    }
}
