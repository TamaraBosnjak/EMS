using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? EmploymentStartDate { get; set; }
        [RegularExpression(@"[0-9]{2}/[0-9]{2}/ [0 - 9]{ 4}", ErrorMessage = "Datum nije validan")]
        public DateTime? EmploymentEndDate { get; set; }
        //public JobRole? JobRole { get; set; }
        //public Department? Department { get; set; }
    }
}
