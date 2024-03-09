using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Student
    {
        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }



        public ICollection<Student_Subject> SubjectStudents { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
