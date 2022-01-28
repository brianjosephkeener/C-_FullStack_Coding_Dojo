using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BrianKeener_exam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BrianKeener_exam.Controllers
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
                if(dbContext.User.Any(l => l.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
            }
            return View("Index");
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
                return RedirectToAction("Home");
            }
            return View("Index");
        }

[HttpGet("Home")]
public IActionResult Home()
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    ViewBag.UserId = HttpContext.Session.GetString("UserId");
    ViewBag.User = dbContext.User.FirstOrDefault(l => l.UserId == Int32.Parse(HttpContext.Session.GetString("UserId")));
    var Forums = dbContext.Forum.Include(u => u.Association).ThenInclude(l => l.User).OrderBy(w => w.ForumDate).ToList();
    return View("Home", Forums);
}
[HttpGet("createForum")]
public IActionResult CreateForum()
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    ViewBag.UserId = HttpContext.Session.GetString("UserId");
    return View("CreateForum");
}
[HttpGet("Forum/deleteForum/{ForumId}")]
public IActionResult DeleteForum(int ForumId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    Forum toDelete = dbContext.Forum.FirstOrDefault(w => w.ForumId == ForumId && w.UserId == Int32.Parse(HttpContext.Session.GetString("UserId")));
    if(toDelete == null)
    {
        return RedirectToAction("Index");
    }
    dbContext.Forum.Remove(toDelete);
    dbContext.SaveChanges();
    return RedirectToAction("Home");
}

        [HttpPost("AddForum")]
        public IActionResult AddAssociationForum(Forum newForum)
        {
            if(HttpContext.Session.GetString("UserId") == null)
                {
                    return RedirectToAction("Index");
                }
            if(ModelState.IsValid)
            {
                dbContext.Add(newForum);
                dbContext.SaveChanges();
                Association newAssociation = new Association();
                newAssociation.UserId = Int32.Parse(HttpContext.Session.GetString("UserId"));
                newAssociation.ForumId = newForum.ForumId;
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Home");                
            }
            return View("CreateForum");
        }

[HttpGet("Forum/addRSVP/{ForumId}")]
public IActionResult AddRSVP(int ForumId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    Association newAssociation = new Association()
    {
        ForumId = ForumId,
        UserId = Int32.Parse(HttpContext.Session.GetString("UserId"))
    };
    dbContext.Add(newAssociation);
    dbContext.SaveChanges();
    return RedirectToAction("Home");
}
[HttpGet("Forum/removeRSVP/{ForumId}")]
public IActionResult removeRSVP(int ForumId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    Association newAssociation = dbContext.Association.FirstOrDefault(l => l.UserId == Int32.Parse(HttpContext.Session.GetString("UserId")) && l.ForumId == ForumId);
    dbContext.Remove(newAssociation);
    dbContext.SaveChanges();
    return RedirectToAction("Home");
}

[HttpGet("Forum/{ForumId}")]
public IActionResult showForum(int ForumId)
{
    if(HttpContext.Session.GetString("UserId") == null)
    {
        return RedirectToAction("Index");
    }
    ViewBag.ShownForum = dbContext.Forum.Include(u => u.Association).ThenInclude(l => l.User).FirstOrDefault(c => c.ForumId == ForumId);
    var Forums = dbContext.Forum.Include(u => u.Association).ThenInclude(l => l.User).OrderByDescending(w => w.ForumDate).ToList();
    ViewBag.User = dbContext.User.FirstOrDefault(l => l.UserId == Int32.Parse(HttpContext.Session.GetString("UserId")));
    return View("ShowForum", Forums);
}
[HttpGet("loggout")]
public IActionResult loggout()
{
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }    
    
    }

}
