namespace EmployeeManagementSystem.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees { get; }
        void CreateEmp(Employee employee);
        void UpdateEmp(int id);
        void DeleteEmp(int id);
    }
}
