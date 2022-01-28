using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login_Register.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;



namespace Login_Register.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            
            return View("Index");
        }

        [HttpPost("Home/Register")]
        public IActionResult RegisterForm(Users newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {

            return View("Login");
        }

        [HttpPost("Home/LoginSubmit")]
        public IActionResult LoginForm(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                Users userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    Console.WriteLine("This was a BAD password");
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Login");
                }
                HttpContext.Session.SetString("UserId", $"{userInDb.UserId}");
                return RedirectToAction("Success");
            }
            return View("Login");
        }

        [HttpGet("success")]
        public IActionResult success()
        {
            string LoginSession = HttpContext.Session.GetString("UserId");
            if (LoginSession == null)
            {
                return RedirectToAction("Login");
            }
            return View("Success");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
