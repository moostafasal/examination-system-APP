using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }
        public string Answer { get; set; }
        // Foreign key for Student
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        // Foreign key for Question
        
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
