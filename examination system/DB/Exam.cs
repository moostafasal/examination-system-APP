using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Exam
    {
        public int ExamId { get; set; }
        // Navigation property for questions
        public ICollection<Question> Questions { get; set; }
        // Foreign key for Subject

        //title

        public string Title { get; set; }
        public int time { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        //degree
        public int Degree { get; set; }
    }
}
