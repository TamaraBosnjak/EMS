namespace EmployeeManagementSystem.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees { get; }
        void CreateEmp(Employee employee);
    }
}
