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
    }
}
