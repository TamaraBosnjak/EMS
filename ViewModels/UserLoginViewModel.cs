using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "Email adresa")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        public string Email { get; set; }
        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna")]
        public string Password { get; set; }
    }
}
