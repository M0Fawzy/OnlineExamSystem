using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Models;

namespace Online_Exam_System.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        DbSet<Exam>Exams { get; set; }
        public DbSet<ExamPaper> ExamPapers { get; set; }
        public DbSet<ExamPaperQuestion> ExamPaperQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamPaperQuestion>()
                .HasOne(epq => epq.ExamPaper)
                .WithMany(ep => ep.Questions)
                .HasForeignKey(epq => epq.ExamPaperId);

            modelBuilder.Entity<ExamPaperQuestion>()
                .HasOne(epq => epq.Exam)
                .WithMany()
                .HasForeignKey(epq => epq.ExamId);
        }

    }
}
