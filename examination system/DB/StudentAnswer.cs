using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }


        public int StudentId { get; set; }

        public Student Student { get; set; }

        public string student_answer { get; set; }


        public int? AnswerId { get; set; }

        public Answers Answer { get; set; }
    }
}
