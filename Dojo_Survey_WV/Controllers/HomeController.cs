using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojo_Survey_WV.Models;

namespace Dojo_Survey_WV.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/Home/Create")]
        public IActionResult Submission(User user)
        {
            if(ModelState.IsValid)
            {
                return View("success", user);
            }
            else
            {
                return View("Index");
            }
        }
    }
}
