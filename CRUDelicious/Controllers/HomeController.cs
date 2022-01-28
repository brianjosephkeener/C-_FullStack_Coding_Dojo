using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
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
            ViewBag.AllDishes = dbContext.Dishes.OrderByDescending(l => l.CreatedAt).ToList();
            return View("Index");
        }

        [HttpGet("new")]
        public IActionResult CreateDish()
        {
            return View("New");
        }

        [HttpPost("Home/Submit")]
        public IActionResult CreateDishSubmit(Dishes newDish)
        {
            if (ModelState.IsValid)
            {
            dbContext.Add(newDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");                
            }
            return RedirectToAction("Index");
        }

        [HttpGet("view/{DishId}")]
        public IActionResult ViewDish(int DishId)
        {
            Dishes RetrivedDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
            ViewBag.ShownDish = RetrivedDish;

            return View("View");
        }

        [HttpGet("edit/{DishId}")]
        public IActionResult UpdateDish(int DishId)
        {
            Dishes RetrivedDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
            ViewBag.ShownDish = RetrivedDish;

            return View("Edit");
        }

        [HttpPost("Home/EditDish")]
        public IActionResult UpdateDishSubmit(Dishes editDish)
        {
            Dishes RetrivedDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == editDish.DishId);
            RetrivedDish.Chef = editDish.Chef;
            RetrivedDish.Name = editDish.Name;
            RetrivedDish.Calories = editDish.Calories;
            RetrivedDish.Tastiness = editDish.Tastiness;
            RetrivedDish.Description = editDish.Description;
            RetrivedDish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{DishId}")]

        public IActionResult DeleteDish(int DishId)
        {
            Dishes RetrivedDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == DishId);
            dbContext.Dishes.Remove(RetrivedDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
