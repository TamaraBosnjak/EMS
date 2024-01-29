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

        public List<Department> GetDepartments()
        {
            return _appDBContext.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _appDBContext.Departments.FirstOrDefault(d => d.DepartmentId == id)!;
        }
    }
}
