using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.ViewModels
{
    public class UserRegisterViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "Email adresa")]
        [Required(ErrorMessage = "Email adresa je obavezna")]
        public string Email { get; set; }

        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna")]
        public string Password { get; set; }

        [Display(Name = "Potvrdite lozinku")]
        [Required(ErrorMessage = "Ponavljanje lozinke je obavezno")]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
