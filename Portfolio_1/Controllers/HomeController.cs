using Microsoft.AspNetCore.Mvc;
namespace Portfolio_1
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000
        [HttpGet("")]
        public string Index()
        {
            return "This is my Index!";
        }

        // localhost:5000/hello
        [HttpGet("projects")] // type of request


        public string Projects()
        {
            return "These are my projects";
        }
        
        // localhost:5000/users/???
        [HttpGet("users/{username}")]

        public string HelloUser(string username)
        {
            return $"Hello {username}";
        }

        [HttpGet("contact")]

        public string Contact(string username)
        {
            return $"This is my contact";
        }
    }
}