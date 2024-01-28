namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly EmploymentStartDate { get; set; }
        public DateOnly EmploymentEndDate { get; set; }
        public JobRole JobRole { get; set; }
        public Department Department { get; set; }
    }
}
