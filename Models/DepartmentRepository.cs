using EmployeeManagementSystem.DAL;

namespace EmployeeManagementSystem.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext _appDBContext;

        public DepartmentRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
    }
}
