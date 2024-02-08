using EmployeeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModels
{
    public class EditEmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Display(Name = "Email adresa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Broj telefona")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum rodjenja")]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum zaposlenja")]
        public DateTime? EmploymentStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum prestanka radnog odnosa")]
        public DateTime? EmploymentEndDate { get; set; }
    }
}
