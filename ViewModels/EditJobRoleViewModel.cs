using EmployeeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class EditJobRoleViewModel
    {
        public int JobRoleId { get; set; }
        [Display(Name = "Poslovna pozicija")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
