using DevLearner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;

namespace DevLearner.Controllers
{
    public class AccountController : Controller
    {
        //    private static List<QuestionsModel> questions = new List<QuestionsModel>
        //{
        //    new QuestionsModel { QuestionText = "Вопрос 1", CorrectAnswer = "Ответ 1" },
        //    new QuestionsModel { QuestionText = "Вопрос 2", CorrectAnswer = "Ответ 2" },
        //    // Добавьте больше вопросов по мере необходимости
        //};
        //public static List<QuestionsModel> questions = new List<QuestionsModel>();
        private static QuestionsModel[] questions;

        private static int currentQuestionIndex = 0;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CSharpProgramming()
        {
            questions = new QuestionsModel[]
            {
            new QuestionsModel { QuestionText = "Ваше первое приложение, выведите 'Hello, World!'. Используйте консоль приведённую ниже, чтобы начать писать код. Console.WriteLine() - метод(функция) для вывода информации в консоль, внутри скобок требуеться указать то, что хотите вывести. Но не забудьте взять это в кавычки! ", CorrectAnswer = "Console.WriteLine('Hello, World!');" },
            new QuestionsModel { QuestionText = "Переменные. Запишите данные в переменную, переменная - это контейнер, который хранит в себе информацию о данных, которые ты в нее записал. Например, int number = 13; Где int - тип данных, number - название переменной, 13 - данные, которые в неё записываются. Теперь попробуй также создать переменную с именем SecondNum и значением 8.", CorrectAnswer = "int SecondNum = 8;" },
            };

            ViewBag.Questions = questions;

            return View();
        }
        public IActionResult PythonProgramming()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckAnswer([FromBody]string answer)
        {
            bool isCorrect = CheckAnswerLogic(answer);

            if (isCorrect)
            {
                // Если ответ верный, переходим к следующему вопросу
                currentQuestionIndex++;
            }

            return Json(new { isCorrect = isCorrect });
        }

        
        private bool CheckAnswerLogic(string answer)
        {
            // Проверяем, не вышли ли мы за пределы списка вопросов
            if (currentQuestionIndex >= questions.Length)
            {
                return false; // Возвращаем false, если вопросов больше нет
            }
            // Проверяем, что текущий вопрос существует
            if (questions[currentQuestionIndex] != null)
            {
                // Сравниваем ответ пользователя с правильным ответом
                return answer.Equals(questions[currentQuestionIndex].CorrectAnswer, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                // Обработка ситуации, когда текущий вопрос отсутствует
                // Например, можно вернуть false или выбросить исключение
                return false;
            }
        }
        [HttpGet]
        public IActionResult GetNextQuestion()
        {
            // Проверяем, не вышли ли мы за пределы списка вопросов
            if (currentQuestionIndex >= questions.Length)
            {
                return Ok(new { QuestionText = "Все вопросы были отвечены", CorrectAnswer = "" });
            }

            var nextQuestion = questions[currentQuestionIndex];
            return Ok(nextQuestion);
        }

        private QuestionsModel GetNextQuestionLogic()
        {
            // Здесь должна быть логика для получения следующего вопроса
            // Например, извлечение следующего вопроса из списка вопросов
            // В данном примере просто возвращаем новый экземпляр QuestionsModel
            return new QuestionsModel { QuestionText = "Следующий вопрос", CorrectAnswer = "Правильный ответ" };
        }
        [HttpPost]
        public ActionResult Save(string Name)
        {
            // Обработка данных формы
            return RedirectToPage("CSharpProgramming");
        }


    }
}
