using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Chefs_Dishes.Models;

namespace Chefs_Dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllChefs = dbContext.Chefs.OrderByDescending(l => l.CreatedAt).Include(t => t.CreatedDishes).ToList();
            return View("Index");
        }

        [HttpGet("newChef")]
        public IActionResult CreateChef()
        {

            return View("AddChef");
        }
        [HttpPost("Home/Submit")]
        public IActionResult CreateChefSubmit(Chef newChef)
        {
            dbContext.Add(newChef);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("newDish")]
        public IActionResult CreateDish()
        {
            ViewBag.Chefs = dbContext.Chefs.ToList();
            return View("AddDish");
        }

        [HttpPost("Home/Submit/Dish")]
        public IActionResult CreateDishSubmit(Dish newDish)
        {
            dbContext.Add(newDish);
            dbContext.SaveChanges();
            return RedirectToAction("Dishes");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            //ViewBag.AllDishes = dbContext.Dishes.OrderByDescending(l => l.CreatedAt).ToList();
            ViewBag.Dishes = dbContext.Dishes.Include(dish => dish.Creator).ToList();
            return View("Dishes");
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
