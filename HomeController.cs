using Microsoft.AspNetCore.Mvc;

namespace DevLearner
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
