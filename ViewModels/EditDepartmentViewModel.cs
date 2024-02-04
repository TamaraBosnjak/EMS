using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class EditDepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Display(Name = "Sektor")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
