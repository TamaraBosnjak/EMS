using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.ViewModels;

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

        public Department GetDepartmentById(int? id)
        {
            return _appDBContext.Departments.FirstOrDefault(d => d.DepartmentId == id)!;
        }

        public Department GetDepartmentByName(string name)
        {
            return _appDBContext.Departments.FirstOrDefault(d => d.Name == name)!;
        }

        public void CreateDepart(Department department)
        {
            _appDBContext.Add(department);
            _appDBContext.SaveChanges();
        }

        public void UpdateDepart(int? id) 
        {
            var updDepart = _appDBContext.Departments.FirstOrDefault(d => d.DepartmentId == id);
            _appDBContext.Update(updDepart);
            _appDBContext.SaveChanges();
        }

        public void DeleteDepart(int id) 
        {
            var delDepart = _appDBContext.Departments.FirstOrDefault(d => d.DepartmentId == id);
            _appDBContext.Remove(delDepart);
            _appDBContext.SaveChanges();
        }
    }
}
