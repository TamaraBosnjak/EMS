using EmployeeManagementSystem.DAL;

namespace EmployeeManagementSystem.Models
{
    public class JobRoleRepository : IJobRoleRepository
    {
        private AppDBContext _appDBContext;

        public JobRoleRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public JobRole GetJobRoleById(int id) 
        {
            return _appDBContext.JobRoles.FirstOrDefault(jr => jr.JobRoleId == id)!;
        }

        public List<JobRole> GetJobRoles() 
        {
            return _appDBContext.JobRoles.ToList();
        }
    }
}
