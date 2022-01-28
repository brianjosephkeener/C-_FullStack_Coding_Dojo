using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wedding_Planner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
    public class ViewModel
        {
        public IEnumerable<User> User { get; set; }
        public IEnumerable<LoginUser> LoginUser { get; set; }
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            
            return View("Index");
        }
        [HttpPost("Home/Register")]
        public IActionResult RegisterForm(User newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
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
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetString("UserId", $"{userInDb.UserId}");
                return RedirectToAction("dashboard");
            }
            return View("Index");
        }

[HttpGet("dashboard")]
public IActionResult Dashboard()
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    ViewBag.UserId = HttpContext.Session.GetString("UserId");
    var weddings = dbContext.Wedding.Include(u => u.Association).ThenInclude(l => l.User).OrderByDescending(w => w.WeddingDate).ToList();
    return View("Dashboard", weddings);
}
[HttpGet("createwedding")]
public IActionResult CreateWedding()
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    ViewBag.UserId = HttpContext.Session.GetString("UserId");
    return View("CreateWedding");
}
[HttpGet("deleteWedding/{weddingId}")]
public IActionResult DeleteWedding(int weddingId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    Wedding toDelete = dbContext.Wedding.FirstOrDefault(w => w.WeddingId == weddingId && w.UserId == Int32.Parse(HttpContext.Session.GetString("UserId")));
    if(toDelete == null)
    {
        return RedirectToAction("Index");
    }
    dbContext.Wedding.Remove(toDelete);
    dbContext.SaveChanges();
    return RedirectToAction("Dashboard");
}

        [HttpPost("AddWedding")]
        public IActionResult AddAssociationWedding(Wedding newWedding)
        {
            if(HttpContext.Session.GetString("UserId") == null)
                {
                    return RedirectToAction("Index");
                }
            if(ModelState.IsValid)
            {
                dbContext.Add(newWedding);
                dbContext.SaveChanges();
                Association newAssociation = new Association();
                newAssociation.UserId = Int32.Parse(HttpContext.Session.GetString("UserId"));
                newAssociation.WeddingId = newWedding.WeddingId;
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");                
            }
            return RedirectToAction("CreateWedding");
        }

[HttpGet("addRSVP/{weddingId}")]
public IActionResult AddRSVP(int weddingId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    Association newAssociation = new Association()
    {
        WeddingId = weddingId,
        UserId = Int32.Parse(HttpContext.Session.GetString("UserId"))
    };
    dbContext.Add(newAssociation);
    dbContext.SaveChanges();
    return RedirectToAction("Dashboard");
}
[HttpGet("removeRSVP/{weddingId}")]
public IActionResult removeRSVP(int weddingId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    Association newAssociation = dbContext.Association.FirstOrDefault(l => l.UserId == Int32.Parse(HttpContext.Session.GetString("UserId")) && l.WeddingId == weddingId);
    dbContext.Remove(newAssociation);
    dbContext.SaveChanges();
    return RedirectToAction("Dashboard");
}

[HttpGet("wedding/{weddingId}")]
public IActionResult showWedding(int weddingId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    ViewBag.ShownWedding = dbContext.Wedding.Include(u => u.Association).ThenInclude(l => l.User).FirstOrDefault(c => c.WeddingId == weddingId);
    return View("ShowWedding");
}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }    
    
    }

}
