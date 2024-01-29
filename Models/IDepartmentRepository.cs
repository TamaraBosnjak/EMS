namespace EmployeeManagementSystem.Models
{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();
        Department GetDepartmentById(int id);
    }
}
