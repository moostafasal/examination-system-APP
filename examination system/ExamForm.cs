using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using examination_system.DB;
using Microsoft.EntityFrameworkCore;

namespace examination_system
{
    public partial class ExamForm : Form
    {
        private List<Question> _questions;
        private List<Answers> Answers;
        private List<StudentAnswer> _selectedAnswers;

        private int _totalScore;
        private int _selectedSubjectId;
        private Student _student;
        private Panel panelQuestions;

        public ExamForm(Student student, int selectedSubjectId)
        {
            InitializeComponent();
            _student = student;
            _selectedSubjectId = selectedSubjectId;
            _selectedAnswers = new List<StudentAnswer>();
            Answers = new List<Answers>();
            panelQuestions = new Panel();
            panelQuestions.Dock = DockStyle.Fill;
            Controls.Add(panelQuestions);
            LoadQuestions();
            DisplayQuestions();
        }

        private void LoadQuestions()
        {
            // Retrieve questions for the selected subject
            using (var dbContext = new ExamDbContext())
            {
                _questions = dbContext.Questions
                    .Include("Answer") // Include answers for each question
                    .Where(q => q.Exam.SubjectId == _selectedSubjectId)
                    .ToList();
            }
        }


        private void DisplayQuestions()
        {
            int yPos = 0;
            foreach (var question in _questions)
            {
                // Create label for question
                var label = new Label
                {
                    Text = question.Text,
                    AutoSize = true,
                    Location = new Point(20, yPos)
                };
                panelQuestions.Controls.Add(label);
                yPos += label.Height + 10;

                // Create group box to group radio buttons for answers
                var groupBox = new GroupBox
                {
                    Location = new Point(10, yPos),
                    Width = panelQuestions.Width - 30,
                    Height = 100,
                    Text = "Answers"
                };
                panelQuestions.Controls.Add(groupBox);

                // Create radio buttons for each option of the answer
                int radioButtonYPos = 40;

                var answer = question.Answer.FirstOrDefault(); // Assuming only one answer per question
                if (answer != null)
                {
                    // Add radio buttons for each option
                    AddRadioButton(groupBox, answer.Option_one, radioButtonYPos, answer);
                    radioButtonYPos += 15; // Adjust spacing
                    AddRadioButton(groupBox, answer.Option_tow, radioButtonYPos, answer);
                    radioButtonYPos += 15; // Adjust spacing
                    AddRadioButton(groupBox, answer.Option_three, radioButtonYPos, answer);
                    radioButtonYPos += 15; // Adjust spacing
                    AddRadioButton(groupBox, answer.Option_four, radioButtonYPos, answer);
                }

                yPos += groupBox.Height + 10; // Update yPos for next question
            }
        }

        private void AddRadioButton(Control parent, string text, int yPos, Answers answer)
        {
            var radioButton = new RadioButton
            {
                Text = text,
                Location = new Point(20, yPos),
                AutoSize = true,
                Tag = answer // Set the Tag property to the Answers object
            };
            parent.Controls.Add(radioButton);

            // Add event handler for radio button selection
            radioButton.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void AddRadioButton(Control parent, string text, int yPos)
        {
            var radioButton = new RadioButton
            {
                Text = text,
                Location = new Point(20, yPos),
                AutoSize = true
            };
            parent.Controls.Add(radioButton);

            // Add event handler for radio button selection
            radioButton.CheckedChanged += RadioButton_CheckedChanged;
        }



        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                // Get the selected answer associated with the radio button
                var selectedAnswer = radioButton.Tag as Answers;

                // Save the selected answer text to the student_answer property
                var studentAnswer = new StudentAnswer
                {
                    StudentId = _student.StudentId,
                    AnswerId = selectedAnswer.AnswerId,
                    student_answer = radioButton.Text // Save the text of the selected radio button
                };
                _selectedAnswers.Add(studentAnswer);

                // Save changes to the database
                using (var dbContext = new ExamDbContext())
                {
                    dbContext.StudentAnswer.Add(studentAnswer);
                    dbContext.SaveChanges();
                }
            }
        }

        private int CalculateScore()
        {
            int score = 0;
            foreach (var selectedAnswer in _selectedAnswers)
            {
                // Retrieve the selected answer text from the StudentAnswer object
                var selectedOption = selectedAnswer.student_answer;

                // Retrieve the corresponding answer object from the database
                var answer = Answers.FirstOrDefault(a => a.AnswerId == selectedAnswer.AnswerId);

                // Ensure that the answer and its correctness value are not null
                if (answer != null && !string.IsNullOrEmpty(answer.CorectAns))
                {
                    // Check if the selected answer matches the correct answer
                    if (selectedOption == answer.CorectAns)
                    {
                        score += 1; // Assuming each correct answer adds 1 to the score
                    }
                }
            }
            return score;
        }


        private void StoreResult()
        {
            using (var dbContext = new ExamDbContext())
            {
                var result = new Result
                {
                    Score = _totalScore,
                    StudentId = _student.StudentId,
                    ExamId = _questions.First().ExamId // Assuming all questions belong to the same exam
                };
                dbContext.Results.Add(result);
                dbContext.SaveChanges();
            }

        }
        private void ExamForm_Load(object sender, EventArgs e)
        {
            // Your code for form load event
        }
        //private void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    // Iterate through radio buttons to find the selected answers
        //    foreach (var control in panelQuestions.Controls)
        //    {
        //        if (control is RadioButton radioButton && radioButton.Checked)
        //        {
        //            var selectedAnswer = (Answers)radioButton.Tag;
        //            _selectedAnswers.Add(selectedAnswer);
        //        }
        //    }

        //    // Calculate score
        //    _totalScore = CalculateScore();

        //    // Store result
        //    StoreResult();

        //    // Show result in ResultForm
        //    ResultForm resultForm = new ResultForm(_totalScore);
        //    resultForm.ShowDialog();

        //    // Close the exam form
        //    this.Close();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            // Iterate through radio buttons to find the selected answers
            foreach (var control in panelQuestions.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (var radioControl in groupBox.Controls)
                    {
                        if (radioControl is RadioButton radioButton && radioButton.Checked)
                        {
                            var selectedAnswer = (Answers)radioButton.Tag;

                            // Create a new StudentAnswer object to store the selected answer
                            var studentAnswer = new StudentAnswer
                            {
                                StudentId = _student.StudentId,
                                AnswerId = selectedAnswer.AnswerId
                            };

                            // Add the selected answer to the list of selected answers
                            _selectedAnswers.Add(studentAnswer);
                        }
                    }
                }
            }

            // Calculate score
            _totalScore = CalculateScore();

            // Store result
            StoreResult();

            // Show result in ResultForm
            ResultForm resultForm = new ResultForm(_totalScore);
            resultForm.ShowDialog();

            // Close the exam form
            this.Close();
        }

    }
}
