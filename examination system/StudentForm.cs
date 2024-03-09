using System;
using System.Windows.Forms;
using examination_system.DB;
using Microsoft.EntityFrameworkCore;

namespace examination_system
{
    public class StudentForm : Form
    {
        private Student _student;
        private ExamDbContext _dbContext;
        public StudentForm(Student student)
        {
            InitializeComponent();
            _student = student;
            _dbContext = new ExamDbContext();
        }

        //
        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (_student != null)
            {
                // Populate textBox1 with student ID
                textBox1.Text = _student.StudentId.ToString();

                // Populate textBox2 with student name
                textBox2.Text = _student.UserName;


            listBox1.Items.AddRange(_dbContext.Students.ToArray());
            }
            var subjects = _dbContext.studentSubject
                                 .Where(ss => ss.StudentId == _student.StudentId)
                                 .Select(ss => ss.Subject)
                                 .ToList();

            comboBox1.DisplayMember = "Name"; // Set the display member to be the Name property of the Subject
            comboBox1.DataSource = subjects;


        }



        // Add other methods and event handlers as needed

        private void InitializeComponent()
        {
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listBox1 = new ListBox();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(494, 334);
            button1.Name = "button1";
            button1.Size = new Size(202, 71);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(315, 332);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(139, 73);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 147);
            label1.Name = "label1";
            label1.Size = new Size(24, 15);
            label1.TabIndex = 2;
            label1.Text = "ID :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 76);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 3;
            label2.Text = "Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 61);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 4;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 132);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 5;
            // 
            // listBox1
            // 
            listBox1.Cursor = Cursors.No;
            listBox1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new Point(412, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(323, 214);
            listBox1.TabIndex = 6;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(443, 267);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 7;
            label5.Text = "Take Exam";
            label5.Click += label5_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(139, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 33);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(139, 61);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 35);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // StudentForm
            // 
            ClientSize = new Size(758, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "StudentForm";
            Load += StudentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ruslt 
            //student
            //Exam is
            var studentResults = _dbContext.Results
             .Where(r => r.StudentId == _student.StudentId)
                             .Include(r => r.Exam).ToList();

            foreach (var result in studentResults)
            {
                listBox1.Items.Add($"{result.Exam.Title}: {result.Score}");
            }


        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox listBox1;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private Student student;
        private Subject selectedSubjectId;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = _student.UserName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = _student.StudentId.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Retrieve the selected subject's ID
                int selectedSubjectId = ((Subject)comboBox1.SelectedItem).SubjectId;

                // Pass the student and selected subject ID to the ExamForm
                ExamForm examForm = new ExamForm(_student, selectedSubjectId);
                examForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a subject.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
