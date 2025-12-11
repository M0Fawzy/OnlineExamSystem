using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class ExamPaper
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int TotalScore { get; set; }

        public List<ExamPaperQuestion> Questions { get; set; } = new List<ExamPaperQuestion>();
    }
}
