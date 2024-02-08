using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
