namespace EmployeeManagementSystem.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> Employees { get; }
    }
}
