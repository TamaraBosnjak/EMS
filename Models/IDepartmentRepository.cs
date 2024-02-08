using EmployeeManagementSystem.ViewModels;

namespace EmployeeManagementSystem.Models
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();
        Department GetDepartmentById(int? id);
        Department GetDepartmentByName(string name);
        void CreateDepart(Department department);
        void UpdateDepart(int? id);
        void DeleteDepart(int id);
    }
}
