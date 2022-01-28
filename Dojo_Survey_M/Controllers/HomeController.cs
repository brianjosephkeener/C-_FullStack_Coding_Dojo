using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojo_Survey_M.Models;

namespace Dojo_Survey_M.Controllers
{  
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {


            return View("Index");
        }

        [HttpPost("surveysubmission")]

        public IActionResult Submission(Survey result)
        {

            return View("Results", result);
        }
}
}
