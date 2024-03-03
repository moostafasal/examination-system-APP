using System;
using System.Linq;
using examination_system.DB;

namespace examination_system.DB
{
    public static class DataSeed
    {
        public static void SeedData()
        {
            using (var context = new ExamDbContext())
            {
                // Check if data exists
                //if (context.Students.Any())
                //{
                //    return; // Data already seeded
                //}

                //// Add initial data
                //context.Students.AddRange(
                //    new Student { UserName = "Mostafa", Password = "A123" },
                //    new Student { UserName = "Abdulah", Password = "A000" }
                //);

                context.Subjects.AddRange(
                    new Subject { Name = "Math" },
                    new Subject { Name = "Science" }
                );

                context.Exams.AddRange(
                    new Exam { Title = "Math Exam", SubjectId = 3 },
                    new Exam { Title = "Science Exam", SubjectId = 4 }
                );

                //context.Questions.AddRange(
                //    new Question { Text = "What is 2 + 2?", CorrectAnswer = "4", ExamId = 1 },
                //    new Question { Text = "What is the capital of France?", CorrectAnswer = "Paris", ExamId = 2 }
                //);

                //context.Results.AddRange(
                //    new Result { Score = 90, StudentId = 1, ExamId = 1 },
                //    new Result { Score = 85, StudentId = 2, ExamId = 2 }
                //);

                context.SaveChanges();

            }
        }
    }
}
