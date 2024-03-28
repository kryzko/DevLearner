using Microsoft.AspNetCore.Mvc;

namespace DevLearner.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
