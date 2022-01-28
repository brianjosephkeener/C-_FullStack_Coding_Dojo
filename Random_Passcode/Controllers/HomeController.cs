using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Random_Passcode.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string GenPass(int len)
        {
            Random rand = new Random();
            string characters = "aAbBcCdDeEfFgGhHiIjJkKLlNnoOpPqQrRsStTuUvVWwxXYyzZ1234567890";
            string result = "";
            for(int i = 0; i < len; i++)
            {
                result = result + characters[rand.Next(characters.Length)];
            }
            return result;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("pass") == null)
            {
                HttpContext.Session.SetString("pass", GenPass(14));
            }
            if(HttpContext.Session.GetInt32("time") == null)
            {
                HttpContext.Session.SetInt32("time", 0);
            }

            ViewBag.Time = HttpContext.Session.GetInt32("time");  
            ViewBag.Pass = HttpContext.Session.GetString("pass");
            return View();
        }
        [HttpGet("generate")]
        public IActionResult newpass()
        {
            int? times = HttpContext.Session.GetInt32("time");
            times++;
            HttpContext.Session.SetInt32("time", (int)times);
            HttpContext.Session.SetString("pass", GenPass(14));
            return RedirectToAction("Index");
        }
    }
}
