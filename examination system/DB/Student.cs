using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        //password

        [Required]
        public string Password { get; set; }


        public ICollection<Student_Subject> StudentSubjects { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
