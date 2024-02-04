using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Naziv sektora je neispravan")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Opis je obavezan")]
        public string Description { get; set; }
        public IEnumerable<Employee>? ListOfEmployees { get; set; }
        public IEnumerable<JobRole>? ListOfJobRoles { get; set; }
    }

}
