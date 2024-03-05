using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Result
    {
        public int ResultId { get; set; }
        public int Score { get; set; }
        // Foreign key for Student
        public int StudentId { get; set; }
        public Student Student { get; set; }
        // Foreign key for Exam
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
