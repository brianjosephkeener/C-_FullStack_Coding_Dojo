using Microsoft.AspNetCore.Mvc;
namespace razor_fun
{
    public class IndexController : Controller
    {
        // Requests
        // localhost:5000
        [HttpGet("")]
        public ViewResult Index()
        {
            // Views/Home/Index.cshtml
            // Views/Shared/Index.cshtml
            return View("Index");
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