using System;
using System.Collections.Generic;
using System.Linq;
using examination_system.DB;

namespace examination_system
{
    public class ExamHandler
    {
        private Student _student;
        private Exam _exam;
        private List<Question> _questions;
        private Dictionary<Question, Answers> _studentAnswers;
        private ExamDbContext _dbContext;

        public ExamHandler(Student student, int selectedSubjectId)
        {
            _student = student;
            _dbContext = new ExamDbContext();

            _exam = _dbContext.Exams.FirstOrDefault(e => e.SubjectId == selectedSubjectId);

            if (_exam != null)
            {
                _questions = _dbContext.Questions.Where(q => q.ExamId == _exam.ExamId).ToList();
            }
            else
            {
                throw new InvalidOperationException("No exam found for the selected subject.");
            }
        }

        public void DisplayExamQuestions(BindingSource bindingSource, TextBox questionTextBox, RadioButton[] optionRadioButtons)
        {
            bindingSource.DataSource = _questions;

            if (_questions.Count > 0)
            {
                DisplayQuestion(bindingSource, questionTextBox, optionRadioButtons);
            }
        }

        private void DisplayQuestion(BindingSource bindingSource, TextBox questionTextBox, RadioButton[] optionRadioButtons)
        {
            Question currentQuestion = (Question)bindingSource.Current;

            questionTextBox.Text = currentQuestion.Text;

            List<Answers> options = _dbContext.Answers.Where(a => a.QuestionId == currentQuestion.QuestionId).ToList();
            for (int i = 0; i < options.Count && i < optionRadioButtons.Length; i++)
            {
                string optionText = "";
                switch (i)
                {
                    case 0:
                        optionText = options[i].Option_one;
                        break;
                    case 1:
                        optionText = options[i].Option_tow;
                        break;
                    case 2:
                        optionText = options[i].Option_three;
                        break;
                    case 3:
                        optionText = options[i].Option_four;
                        break;
                }
                optionRadioButtons[i].Text = optionText;
            }
        }

        public void SubmitAnswer(Question question, Answers answer)
        {
            if (_studentAnswers == null)
            {
                _studentAnswers = new Dictionary<Question, Answers>();
            }

            if (_studentAnswers.ContainsKey(question))
            {
                _studentAnswers[question] = answer;
            }
            else
            {
                _studentAnswers.Add(question, answer);
            }
        }

        public Result GetResult()
        {
            int score = CalculateScore();
            StoreResult(score);

            return new Result { StudentId = _student.StudentId, ExamId = _exam.ExamId, Score = score };
        }

        private int CalculateScore()
        {
            int score = 0;

            foreach (var entry in _studentAnswers)
            {
                Question question = entry.Key;
                Answers selectedAnswer = entry.Value;

                Answers correctAnswer = _dbContext.Answers.FirstOrDefault(a => a.QuestionId == question.QuestionId && a.CorectAns == selectedAnswer.CorectAns);

                if (correctAnswer != null && selectedAnswer != null && correctAnswer.CorectAns == selectedAnswer.CorectAns)
                {
                    score += question.Mark;
                }
            }

            return score;
        }

        private void StoreResult(int score)
        {
            Result result = new Result
            {
                StudentId = _student.StudentId,
                ExamId = _exam.ExamId,
                Score = score
            };

            _dbContext.Results.Add(result);
            _dbContext.SaveChanges();
        }
    }
}
