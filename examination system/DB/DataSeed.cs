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
                //Check if data exists
                if (context.Students.Any())
                {
                    return; // Data already seeded
                }

                // Add initial data
                context.Students.AddRange(
                    new Student { Email = "Mostafa10@gmail.com", UserName = "Mostafa", Password = "A123" },
                    new Student { Email = "Abdulah@gmail.com", UserName = "Abdulah", Password = "A000" }
                );

                context.Subjects.AddRange(
                    new Subject { Name = "Math" },
                    new Subject { Name = "Databeas" }
                );
                context.studentSubject.AddRange(
                    new Student_Subject { StudentId = 1, SubjectId = 1 },
                     new Student_Subject { StudentId = 1, SubjectId = 2 }


                    );


                context.Exams.AddRange(
                    new Exam { Title = "Math Exam ", SubjectId = 1, time = 60, Degree = 30 },
                    new Exam { Title = "Databaes ", SubjectId = 2, time = 60, Degree = 30 }
                ) ;

                context.Questions.AddRange(
                    new Question { Text = "What is 2 + 2?", ExamId = 1, Mark = 5 },
                     new Question { Text = "What is 4 + 4?", ExamId = 1, Mark = 5 },
                     new Question { Text = "What is 2 + 8?", ExamId = 1, Mark = 5 },
                     new Question { Text = "What is 2 + 3?", ExamId = 1, Mark = 5 },
                     new Question { Text = "What is 2 + 10?", ExamId = 1, Mark = 5 }
                );
                //add answrs
                context.Answers.AddRange(
                    new Answers { QuestionId = 1,CorectAns="4",Option_one="2",Option_tow="3",Option_three="4",Option_four="10" },

                    new Answers { QuestionId = 2, CorectAns = "8", Option_one = "4", Option_tow = "9", Option_three = "8", Option_four = "10" },

                     new Answers { QuestionId = 3, CorectAns = "10", Option_one = "1", Option_tow = "9", Option_three = "10", Option_four = "10" },

                     new Answers { QuestionId = 4, CorectAns = "5", Option_one = "8", Option_tow = "9", Option_three = "5", Option_four = "10" },

                      new Answers { QuestionId = 4, CorectAns = "12", Option_one = "9", Option_tow = "12", Option_three = "8", Option_four = "10" },

                    );


            

                context.SaveChanges();

            }
        }
    }
}
