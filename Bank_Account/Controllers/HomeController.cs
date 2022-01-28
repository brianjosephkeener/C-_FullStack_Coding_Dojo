using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank_Account.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Bank_Account.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult RegisterForm(User newUser, Transaction ZeroAccount)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                ZeroAccount.UserId = newUser.UserId;
                ZeroAccount.Decimal = 0;
                dbContext.Add(ZeroAccount);
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
                User userInDb = dbContext.User.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Login");
                }
                HttpContext.Session.SetString("UserId", $"{userInDb.UserId}");
                return RedirectToAction("Account", new { Id = $"{userInDb.UserId}"});
            }
            return View("Login");
        }

        [HttpGet("account/{Id}")]
        public IActionResult Account(int Id)
        {
            string LoginSession = HttpContext.Session.GetString("UserId");
            if (LoginSession == null)
            {
                return RedirectToAction("Login");
            } 
            ViewBag.ShownUser = dbContext.Transaction.Where(l => l.UserId == Id).Include(u => u.Creator).ToList();
            return View("Account");
        }

        [HttpPost("SubmitTransaction")]
        public IActionResult SubmitTransaction(Transaction newTransaction)
        {
            List<Transaction> compare = dbContext.Transaction.Where(l => l.UserId == newTransaction.UserId).ToList();
            if ((newTransaction.Decimal + compare[0].Decimal) < 0)
            {
                return RedirectToAction("Account", new { Id = newTransaction.UserId});
            }
            dbContext.Add(newTransaction);
            dbContext.SaveChanges();
            return RedirectToAction("Account", new { Id = newTransaction.UserId});
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
