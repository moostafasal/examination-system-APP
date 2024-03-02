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
        public DbSet<Answer> Answers { get; set; }
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

            modelBuilder.Entity<Student_Subject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<Student_Subject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);
            modelBuilder.Entity<StudentAnswer>()
                .HasOne(sa => sa.Answer)
                .WithMany()
                .HasForeignKey(sa => sa.AnswerId)
                .IsRequired(false); // Optional on the "Many" side

            // Define the relationship between StudentAnswer and Question
            modelBuilder.Entity<StudentAnswer>()
       .HasOne(sa => sa.Question)
       .WithMany()
       .HasForeignKey(sa => sa.QuestionId)
       .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION for this foreign key constraint

            modelBuilder.Entity<StudentAnswer>()
                .HasOne(sa => sa.Answer)
                .WithMany()
                .HasForeignKey(sa => sa.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }


}
