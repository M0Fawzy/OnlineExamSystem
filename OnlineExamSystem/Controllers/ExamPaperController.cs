using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Models;
using Online_Exam_System.Repository.Base;
namespace Online_Exam_System.Controllers
{
    public class ExamPaperController : Controller
    {
        private readonly IRepository<ExamPaper> epRepo;
        private readonly IRepository<Exam> examRepo;
        private readonly IRepository<ExamPaperQuestion> epqRepo;

        public ExamPaperController(IRepository<ExamPaper> epRepo,
                                   IRepository<Exam> examRepo,
                                   IRepository<ExamPaperQuestion> epqRepo)
        {
            this.epRepo = epRepo;
            this.examRepo = examRepo;
            this.epqRepo = epqRepo;
        }

        public IActionResult Index()
        {
            ViewBag.Questions = examRepo.GetAll();
            return View(epRepo.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Questions = examRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, List<int> questionIds, List<int> scores)
        {
            var examPaper = new ExamPaper
            {
                Title = title
            };
            epRepo.AddOne(examPaper);
            int total = 0;
            for (int i = 0; i < questionIds.Count; i++)
            {
                var link = new ExamPaperQuestion
                {
                    ExamPaperId = examPaper.Id,
                    ExamId = questionIds[i],
                    Score = scores[i]
                };
                total += scores[i];
                epqRepo.AddOne(link);
            }
            examPaper.TotalScore = total;
            epRepo.UpdateOne(examPaper);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var examPaper = epRepo.FindById(id);
                if (examPaper == null)
                    return NotFound();

                // Delete all related questions first
                var questions = epqRepo.GetAll()
                    .Where(epq => epq.ExamPaperId == id)
                    .ToList();

                foreach (var q in questions)
                {
                    epqRepo.DeleteOne(q);
                }

                // Delete the exam paper
                epRepo.DeleteOne(examPaper);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            try
            {
                var questions = examRepo.GetAll().Select(q => new
                {
                    id = q.Id,
                    question = q.Question
                }).ToList();

                return Json(questions);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // Get exam details for taking the exam
        [HttpGet]
        public IActionResult GetExamDetails(int paperId)
        {
            var examPaper = epRepo.FindById(paperId);
            if (examPaper == null)
                return NotFound();

            var questions = epqRepo.GetAll()
                .Where(epq => epq.ExamPaperId == paperId)
                .ToList();

            var questionDetails = questions.Select(q => {
                var exam = examRepo.FindById(q.ExamId);
                return new
                {
                    examId = exam.Id,
                    question = exam.Question,
                    questionType = exam.QuestionType,
                    options = exam.Options,
                    correctAnswer = exam.CorrectAnswer,
                    score = q.Score
                };
            }).ToList();

            return Json(new
            {
                title = examPaper.Title,
                totalScore = examPaper.TotalScore,
                questions = questionDetails
            });
        }
    }
}