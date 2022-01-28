using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products_Categories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Products_Categories.Controllers
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
            ViewBag.ShownProducts = dbContext.Product.ToList();
            return View("Index");
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newProduct);
                dbContext.SaveChanges();
                return RedirectToAction("Index");                
            }
            return RedirectToAction("Index");
        }

        [HttpGet("products/{Id}")]

        public IActionResult ShowProduct(int Id)
        {
            ViewBag.ShownProduct = dbContext.Product.Where(l => l.ProductId == Id).ToList();
            ViewBag.ShownCategories = dbContext.Category.ToList();
            var tester = dbContext.Product.Include(l => l.Association).ThenInclude(u => u.Category).FirstOrDefault(l => l.ProductId == Id);
            return View("ShowProduct", tester);
        }

        [HttpGet("categories/{Id}")]

        public IActionResult ShowCategory(int Id)
        {
            ViewBag.ShownCategory = dbContext.Category.Where(l => l.CategoryId == Id).ToList();
            ViewBag.ShownProducts = dbContext.Product.ToList();
            var tester = dbContext.Category.Include(l => l.Association).ThenInclude(u => u.Product).FirstOrDefault(l => l.CategoryId == Id);
            return View("ShowCategory", tester);
        }


        [HttpGet("categories")]
        public IActionResult Categories()
        {
            ViewBag.ShownCategories = dbContext.Category.ToList();
            return View("Category");
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newCategory);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");                
            }
            return RedirectToAction("Categories");
        }

        [HttpPost("AddAssociationProduct")]
        public IActionResult AddAssociationProduct(Association newAssociation)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Index");                
            }
            return RedirectToAction("Index");
        }

        [HttpPost("AddAssociationCategory")]
        public IActionResult AddAssociationCategory(Association newAssociation)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Index");                
            }
            return RedirectToAction("Index");
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
