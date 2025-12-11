using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public Topic QuestionType { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        [Required]
        public List<string> Options { get; set; }=new List<string>();

        
    }
   public enum Topic
    {
        MCQ=0,
        True_False=1,
        WriteAnswer=2
    }
}
