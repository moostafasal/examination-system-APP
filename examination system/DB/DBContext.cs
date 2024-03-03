using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace examination_system.DB
{
    public class ExamDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ExminationSystem;Trusted_Connection=True;;Integrated Security=True ;TrustServerCertificate=True");
            }
        }

        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {

        }

        public ExamDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student_Subject>()
          .HasKey(ss => new { ss.StudentId, ss.SubjectId });

        }

    }


}
