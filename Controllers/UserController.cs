﻿using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EmployeeManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly INotyfService _notyf;
        private readonly IEmployeeRepository _employeeRepository;


        public UserController(IUserRepository userRepository, INotyfService notyf, IEmployeeRepository employeeRepository)
        {
            _userRepository = userRepository;
            _notyf = notyf;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Register(User registerUser)
        {
            if (ModelState.IsValid)
            {
                var registeredUser = _userRepository.GetUserByEmail(registerUser.Email);    
                var employeeUser = _employeeRepository.GetEmployeeByEmail(registerUser.Email);

                if (registerUser != null && registeredUser == null)
                {
                    _userRepository.CreateUser(registerUser, employeeUser.EmployeeId);
                    _notyf.Success("Registracija uspešna!");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Korisnik sa email adresom " + registerUser.Email + " vec postoji.");
                    return View("Index");
                }
            }
            else
            {
                return View("Index", registerUser);
            }
        }

        public IActionResult Login()
        {
            var vm = new UserLoginViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel loginUser)
        {
            if (!ModelState.IsValid) 
            {
                return View("Login", "loginUser");
            }

            var user = _userRepository.GetUserByEmail(loginUser.Email);

            if (user != null)
            {
                var isPasswordOk = EncryptionHelper.Encrypt(loginUser.Password) == user.Password ? true : false;

                if (isPasswordOk)
                {
                    user.Password = "";
                    var cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddMinutes(30);
                    var serializedUser = JsonConvert.SerializeObject(user);
                    Response.Cookies.Append("User", serializedUser, cookieOptions);

                    _notyf.Success("Uspešno ste se ulogovali.");

                    return RedirectToAction("Index", "Home");
                }
            }

            _notyf.Error("Neispravni kredencijali!");

            return View("Login");
        }

        public IActionResult Logout() 
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Response.Cookies.Delete("User");
            }

            _notyf.Success("Uspešno ste se izlogovali!");
            return RedirectToAction("Index", "Home");
        }
    }
}
