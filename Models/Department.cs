namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee>? ListOfEmployees { get; set; }
        public IEnumerable<JobRole>? JobRoles { get; set; }
    }
}
