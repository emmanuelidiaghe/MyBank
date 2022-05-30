using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBank.Models;
using Microsoft.AspNetCore.Mvc;
using MyBank.Data.Repository.User;
using MyBank.Data.Repository.Login;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBank.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly ILoginRepository _loginRepository;
        Compute compute = new Compute();

        public AccountsController(IRegisterRepository registerRepository, ILoginRepository loginRepository)
        {
            _registerRepository = registerRepository;
            _loginRepository = loginRepository;
        }

        public IActionResult Register(User user)
        {
            if(string.IsNullOrEmpty(user.Email)) return View(user);

            int userCount =  _registerRepository.GetUserCount(user.Email);
            if(userCount > 0) 
            {
                return RedirectToAction("Register", new Login { LoginError = "This user already exists" });
            }
            
            user.DateCreated = DateTime.Now;
            _registerRepository.CreateUser(user);
            return RedirectToAction("CreatePassword");
        }

        public IActionResult Login(Login login)
        {
            if(string.IsNullOrEmpty(login.Email)) return View(login);

            int userCount =  _registerRepository.GetUserCount(login.Email);

            if(userCount > 0) 
            {
                bool loginExists = _loginRepository.GetLogin(login.Email, compute.ComputeMd5Hash(login.Password), true);
                if(loginExists)
                {
                    return Ok("User successfully logged in");
                }
                
                return RedirectToAction("Login", new Login { LoginError = "Invalid login credentials"});
            }

            return RedirectToAction("Login", new Login { LoginError = "User doesn't exist"});
        }

        public IActionResult CreatePassword(Login login)
        {
            if(string.IsNullOrEmpty(login.Email)) return View();

            login.Password = compute.ComputeMd5Hash(login.Password);
            _loginRepository.Createlogin(login);
            return RedirectToAction("Login");
        }

        public IActionResult Error(string errorMessage)
        {
            return View(new ErrorViewModel { ErrorMessage = errorMessage});
        } 
    }
}