﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class User
    {
        [BindNever]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Password je obavezan!")]
        [Display(Name = "Lozinka")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Password mora da sadrzi najmanje po jedno veliko i malo slovo, broj i specijalan karakter i da bude duzine 8-15 karaktera")]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Potvrdi lozinku")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email je obavezan!")]
        [Display(Name = "Email adresa")]
        public string Email { get; set; }
        public int? EmployeeId { get; set; }
       
        public Employee? Employee { get; set; }
    }
}
