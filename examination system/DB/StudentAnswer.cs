using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class StudentAnswer
    {
        [Key]
        public int StudentAnswerId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [Required]
        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; } // Removed ForeignKey attribute

        [Required]
        public int AnswerId { get; set; }

        public Answer Answer { get; set; } // Removed ForeignKey attribute
    }
}
