using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [BindNever]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Ime je neispravno")]
        [RegularExpression("^([a-zA-Z]{3,})", ErrorMessage = "Ime je neispravno")]
        [Display(Name = "Ime")]
        [StringLength(20, ErrorMessage = "Ime je predugacko")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je neispravno")]
        [RegularExpression("^([a-zA-Z]{3,})", ErrorMessage = "Prezime je neispravno")]
        [Display(Name = "Prezime")]
        [StringLength(20, ErrorMessage = "Prezime je predugacko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email adresa je neispravna")]
        [Display(Name = "Email adresa")]
        [StringLength(50, ErrorMessage = "Email adresa je predugacka")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Broj telefona je neispravan")]
        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^(\d{9,10})$", ErrorMessage ="Broj telefona nije validan!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Adresa je neispravna")]
        [Display(Name = "Adresa")]
        [StringLength(60, ErrorMessage = "Adresa je predugacka")]
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

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int JobRoleId { get; set; }
        public JobRole? JobRole { get; set; }
    }
}
