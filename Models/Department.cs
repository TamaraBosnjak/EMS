using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [BindNever]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Naziv sektora je neispravan")]
        [Display(Name = "Sektor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Opis je obavezan")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
