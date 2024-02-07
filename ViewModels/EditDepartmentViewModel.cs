using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class EditDepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Sektor je obavezan")]
        [Display(Name = "Sektor")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Opis je obavezan")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
