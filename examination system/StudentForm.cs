using System;
using System.Windows.Forms;
using examination_system.DB;

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
            }
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
            button1.Location = new Point(605, 300);
            button1.Name = "button1";
            button1.Size = new Size(202, 54);
            button1.TabIndex = 0;
            button1.Text = "Take Exam";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(478, 317);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 64);
            label1.Name = "label1";
            label1.Size = new Size(24, 15);
            label1.TabIndex = 2;
            label1.Text = "ID :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 132);
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
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(670, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(323, 169);
            listBox1.TabIndex = 6;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(585, 250);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 7;
            label5.Text = "Take Exam";
            label5.Click += label5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(139, 61);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 23);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // StudentForm
            // 
            ClientSize = new Size(1024, 389);
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
        }
    }
}
