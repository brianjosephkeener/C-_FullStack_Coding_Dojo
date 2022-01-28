using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Messageclass messageyo = new Messageclass()
            {
                Message = "This is my hello world!"
            };

            return View("Index", messageyo);
        }

        [HttpGet("numbers")]

        public IActionResult Numbers()
        {
            int[] numbers = new int[]
            {
                1, 2, 3, 10, 43, 5
            };
            return View("Numbers", numbers);
        }
        public List<Users> createu()
        {
            return new List<Users>()
            {
                new Users(){ FirstName="Moose", LastName="Phillips"},
                new Users(){ FirstName="Ricky", LastName="Thames"},
                new Users(){ FirstName="Sally", LastName="McSally"},
                new Users(){ FirstName="Barb", LastName="Reardan"}
            };
        }

        [HttpGet("users")]
        public IActionResult AllUsers()
        {
            var users = createu();
            return View("Users", users);
        }


        [HttpGet("user")]
        public IActionResult OneUser()
        {
            var users = createu();
            var user = users[1];
            return View("User", user);
        }
            
    }
}


