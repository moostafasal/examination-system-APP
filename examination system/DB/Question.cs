using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }

        public string CorrectAnswer { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }

    }
}
