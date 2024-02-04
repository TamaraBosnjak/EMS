using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class JobRole
    {
        public int JobRoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
    }
}
