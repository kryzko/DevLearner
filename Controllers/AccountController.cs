using DevLearner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DevLearner.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CSharpProgramming()
        {
            QuestionsModel[] questions = new QuestionsModel[]
            {
            new QuestionsModel { QuestionText = "Вопрос 1", CorrectAnswer = "Ответ 1" },
            new QuestionsModel { QuestionText = "Вопрос 2", CorrectAnswer = "Ответ 2" },
            };

            ViewBag.Questions = questions;

            return View();
        }
        public IActionResult PythonProgramming()
        {
            return View();
        }


    }
}
