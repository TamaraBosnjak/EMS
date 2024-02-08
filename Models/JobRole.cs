using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class JobRole
    {
        //[BindNever]
        public int? JobRoleId { get; set; }
        [Required(ErrorMessage = "Naziv poslovne pozicije je neispravan")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Opis je obavezan")]
        public string Description { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
