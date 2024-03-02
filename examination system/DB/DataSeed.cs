using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examination_system.DB
{
    public static class DataSeed
    {
        public static void SeedData()
        {
            using (var context = new ExamDbContext())
            {
                // Check if data exists
                if (context.Students.Any())
                {
                    return; // Data already seeded
                }

                // Add initial data
                context.Students.AddRange(
                    new Student { StudentId = 1, Name = "Mostafa", Password = "A123" },
                    new Student { StudentId = 2, Name = "Abdulah", Password = "A000" }
                );

                context.Subjects.AddRange(
                    new Subject { SubjectId = 1, Name = "Math" },
                    new Subject { SubjectId = 2, Name = "Science" }
                );

                context.Exams.AddRange(
                    new Exam { Title = "Math Exam", SubjectId = 1 },
                    new Exam { Title = "Science Exam", SubjectId = 2 }
                );

                context.Questions.AddRange(
                    new Question {  Text = "What is 2 + 2?", ExamId = 1 },
                    new Question {  Text = "What is the capital of France?", ExamId = 2 }
                );

                context.Answers.AddRange(
                    new Answer {  Text = "4", IsCorrect = true, QuestionId = 1 },
                    new Answer {  Text = "5", IsCorrect = false, QuestionId = 1 },
                    new Answer {  Text = "Paris", IsCorrect = true, QuestionId = 2 },
                    new Answer {  Text = "London", IsCorrect = false, QuestionId = 2 }
                );

                context.Results.AddRange(
                    new Result {  Score = 90, StudentId = 1, ExamId = 1 },
                    new Result {  Score = 85, StudentId = 2, ExamId = 2 }
                );

                context.SaveChanges();
            }
        }

    }
}
