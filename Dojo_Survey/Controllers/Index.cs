using Microsoft.AspNetCore.Mvc;
namespace Portfolio_2
{
    public class IndexController : Controller
    {
        static string name = "";
        static string location = "";
        static string language = "";
        static string comment = "";
        // Requests
        // localhost:5000
        [HttpGet("")]
        public ViewResult Index() // OR IActionResult for more breadth of return types but less performance efficient
        {
            // Views/Home/Index.cshtml
            // Views/Shared/Index.cshtml
            return View("Index");
        }

        [HttpGet("submissioninfo")]
        public IActionResult Submission()
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = location;
            ViewBag.comment = comment;

            return View("Submission");
        }

        // localhost:5000/projects
        [HttpGet("projects")] // type of request
        public ViewResult Projects()
        {
            return View("projects");
        }
        
        // localhost:5000/users/???
        [HttpGet("users/{username}")]

        public string HelloUser(string username)
        {
            return $"Hello {username}";
        }

        [HttpGet("contact")]
        public RedirectToActionResult Contact()  // OR IActionResult
        {
            // localhost:5000 redirecting to public string Projects
            return RedirectToAction("Projects");
        }
        [HttpGet("redirect")]
        public RedirectToActionResult redirectparameter()
        {
            // localhost:5000 redirecting to public string HelloUser WITH required parameter passed
            var parameter = new{username="BABABOOB"};
            return RedirectToAction("HelloUser", parameter);
        }

[HttpPost("formsubmission")]
public IActionResult Method(string nameG, string locationG, string languageG, string commentG)
{
    name=nameG;
    location=locationG;
    language=languageG;
    comment=commentG;
    
    return RedirectToAction("Submission");
}



    }
}