using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Email adresa")]
        public string Email { get; set; }
        [Display(Name = "Lozinka")]
        public string Password { get; set; }
        [Display(Name = "Potvrdite lozinku")]
        public string ConfirmPassword { get; set; }
    }
}
