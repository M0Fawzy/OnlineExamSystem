using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class ExamPaperQuestion
    {
        [Key]
        public int Id { get; set; }

        public int ExamPaperId { get; set; }
        public int ExamId { get; set; }

        public ExamPaper ExamPaper { get; set; }
        public Exam Exam { get; set; }

        public int Score { get; set; }
    }
}
