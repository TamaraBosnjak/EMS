namespace EmployeeManagementSystem.Models
{
    public class JobRole
    {
        public int JobRoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Department Department { get; set; }
        
    }
}
