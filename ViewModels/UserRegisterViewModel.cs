using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Email adresa")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        public string Email { get; set; }

        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna")]
        public string Password { get; set; }

        [Display(Name = "Potvrdite lozinku")]
        [Required(ErrorMessage = "Ponavljanje lozinke je obavezno")]
        public string ConfirmPassword { get; set; }
    }
}
