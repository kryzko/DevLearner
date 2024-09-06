using DevLearner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;

namespace DevLearner.Controllers
{
    public class AccountController : Controller
    {
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
            new QuestionsModel { QuestionText = "Циклы. Напишите цикл, который будет выводить числа от 1 до 10. Для этого используйте цикл for. Например: for(int i = 1; i <= 10; i++)", CorrectAnswer = "for(int i = 1; i <= 10; i++) Console.WriteLine(i);" },

            new QuestionsModel { QuestionText = "Операторы. Напишите выражение, которое складывает два числа: 5 и 7. Используйте оператор '+'. Например: int sum = 5 + 7;", CorrectAnswer = "int sum = 5 + 7;" },

            new QuestionsModel { QuestionText = "Строки. Напишите строку, которая объединяет две другие строки: \"Hello\" и \"World\". Используйте оператор '+'. Например: string greeting = \"Hello\" + \"World\";", CorrectAnswer = "string greeting = \"Hello\" + \"World\";" },

            new QuestionsModel { QuestionText = "Константы. Определите константу с именем PI и значением 3.14159. Константы используются для хранения значений, которые не изменяются после их определения. Например: const double PI = 3.14159;", CorrectAnswer = "const double PI = 3.14159;" },

            new QuestionsModel { QuestionText = "Контекстные менеджеры. Напишите блок кода, который открывает и закрывает поток, используя контекстный менеджер. Например: using (StreamWriter writer = new StreamWriter(\"file.txt\"))", CorrectAnswer = "using (StreamWriter writer = new StreamWriter(\"file.txt\")) writer.Write(\"Hello, World!\");" }

            };

            ViewBag.Questions = questions;

            return View();
        }
        public IActionResult PythonProgramming()
        {
            questions = new QuestionsModel[]
            {
            new QuestionsModel { QuestionText = "Вывод текста. Какой синтаксис используется для вывода текста в консоль в Python?Выведите Hello, World", CorrectAnswer = "print('Hello, World')" },
            new QuestionsModel {QuestionText = "Переменные. Как объявить переменную в Python и присвоить ей значение?Присвойте переменной x значение 10", CorrectAnswer = "x = 10"},
            new QuestionsModel {QuestionText = "Циклы. Напишите цикл, который будет выводить числа от 1 до 5. Используйте цикл for.", CorrectAnswer = "for i in range(1, 6):\n    print(i)"},
            new QuestionsModel {QuestionText = "Операторы. Напишите выражение, которое складывает два числа: 5 и 7. Используйте оператор '+'. Результат должен храниться в переменной sum", CorrectAnswer = "sum = 5 + 7"}
            };

            ViewBag.Questions = questions;
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
            // Просто возвращаем новый экземпляр QuestionsModel
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
