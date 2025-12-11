using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Models;
using Online_Exam_System.Repository.Base;

namespace Online_Exam_System.Controllers
{
    public class ExamController : Controller
    {
        private readonly IRepository<Exam> repository;

        public ExamController(IRepository<Exam>repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Exam exam)
        {
            if (ModelState.IsValid)
            {
                repository.AddOne(exam);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index"); ;
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var clientid = repository.FindById(id.Value);
            if (clientid == null)
                return NotFound();
            return Json(clientid);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exam exam)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateOne(exam);
                return RedirectToAction("Index");
            }
            else
                return View(exam);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Delete(int id)
        {
            var exam = repository.FindById(id);
            if (exam == null)
                return NotFound();

            repository.DeleteOne(exam);
            return RedirectToAction("Index");
        }

    }
}
