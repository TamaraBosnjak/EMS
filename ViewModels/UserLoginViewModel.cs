using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "Email adresa")]
        public string Email { get; set; }
        [Display(Name = "Lozinka")]
        public string Password { get; set; }
    }
}
