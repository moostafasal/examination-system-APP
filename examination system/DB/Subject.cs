using System.ComponentModel.DataAnnotations;

namespace examination_system.DB
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Student_Subject> StudentSubjects { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
