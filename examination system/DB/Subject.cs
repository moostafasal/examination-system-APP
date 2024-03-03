using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        // Navigation property for exams
        public ICollection<Exam> Exams { get; set; }
        // Navigation property for students
        public ICollection<Student_Subject> SubjectStudents { get; set; }
    }

}
