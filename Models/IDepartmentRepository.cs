namespace EmployeeManagementSystem.Models
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();
        Department GetDepartmentById(int id);
        void CreateDepart(Department department);
        void UpdateDepart(int id);
        void DeleteDepart(int id);
    }
}
