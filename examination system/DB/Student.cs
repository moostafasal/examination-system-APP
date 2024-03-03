using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Student
    {
        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        // Navigation property for subjects
        public ICollection<Student_Subject> SubjectStudents { get; set; }
        // Navigation property for student answers
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
        // Navigation property for results
        public ICollection<Result> Results { get; set; }
    }
}
