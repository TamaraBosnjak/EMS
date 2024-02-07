using EmployeeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class EditJobRoleViewModel
    {
        public int JobRoleId { get; set; }
        [Required(ErrorMessage = "Poslovna pozicija je obavezna")]
        [Display(Name = "Poslovna pozicija")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Opis je obavezan")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
