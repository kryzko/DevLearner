using DevLearner.Services;
using Microsoft.AspNetCore.Mvc;
using WebmailSMTP;

namespace DevLearner.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private readonly MyDbContext _context;
        private readonly EmailService _emailService;

        public HomeController(MyDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Models.UsersInfo user) // Изменено на Task<ActionResult>
        {
            // Проверяем, существует ли пользователь с таким же адресом электронной почты
            var existingUserByEmail = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            // Проверяем, существует ли пользователь с таким же логином и паролем
            var existingUserByLoginAndPassword = _context.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);

            if (existingUserByEmail != null && existingUserByLoginAndPassword != null)
            {
                // Если пользователь с таким же адресом электронной почты или логином и паролем уже существует,
                // возвращаем ошибку или сообщение об этом
                ModelState.AddModelError("Email", "Пользователь с таким адресом электронной почты уже существует.");
                ModelState.AddModelError("Login", "Пользователь с таким логином и паролем уже существует.");
                return View(Index); // Возвращает пользователя обратно на форму с ошибками
            }

            if (ModelState.IsValid)
            {
                // Добавление нового пользователя в базу данных только если он уникален
                _context.Users.Add(user);

                await _emailService.SendEmailAsync(user.Email, "DevLearner регистрация...", "Вы успешно зарегестрировались на нашем сайте!"); // Теперь можно использовать await здесь

                _context.SaveChanges();

                // Перенаправление на другую страницу после успешного сохранения
                return Redirect("/account");
            }

            // Если данные невалидны, возвращаем пользователя обратно на форму
            return View(Index);
        }
    }
}
