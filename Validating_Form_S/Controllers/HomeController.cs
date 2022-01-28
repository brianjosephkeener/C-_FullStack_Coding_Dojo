using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Validating_Form_S.Models;

namespace Validating_Form_S.Controllers
{
    public class HomeController : Controller
{
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost("submit")]
        public IActionResult Submit(User user)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }
        [HttpGet("success")]
        public ViewResult Success()
        {
            return View();
        }
    }
}

