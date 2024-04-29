using Microsoft.AspNetCore.Mvc;

namespace DevLearner.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CSharp()
        {
            return View();
        }
        public IActionResult Python()
        {
            return View();
        }
        public IActionResult CPlusPlus()
        {
            return View();
        }
    }
}
