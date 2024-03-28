using Microsoft.AspNetCore.Mvc;

namespace DevLearner.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
