namespace EmployeeManagementSystem.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> ListOfAllEmployees();
        void CreateEmp(Employee employee);
        void UpdateEmp(int id);
        void DeleteEmp(int id);
    }
}
