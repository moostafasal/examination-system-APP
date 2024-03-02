using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public string Title { get; set; }

        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
