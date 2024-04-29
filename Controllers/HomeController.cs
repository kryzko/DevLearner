using Microsoft.AspNetCore.Mvc;

namespace DevLearner.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create([FromBody] Models.UsersInfo user)
        {
            if (ModelState.IsValid)
            {
                // Добавление нового пользователя в базу данных
                _context.Users.Add(user);
                _context.SaveChanges();

                // Перенаправление на другую страницу после успешного сохранения
                return Redirect("/");   
            }

            // Если данные невалидны, возвращаем пользователя обратно на форму
            return View(Index);
        }

    }
}
