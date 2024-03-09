using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using examination_system.DB;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace examination_system
{
    public partial class ResultForm : Form
    {
        private int _result;
        private readonly int _studntid;
        private readonly ExamDbContext _examDbContext;

        public ResultForm(int result, int studntid)
        {
            _examDbContext = new ExamDbContext();
            InitializeComponent();
            _result = result;
            this._studntid = studntid;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            // Display the result in the text box
            textBox1.Text = _result.ToString();
        }

        private void ResultForm_Load_1(object sender, EventArgs e)
        {
            textBox1.Text = _result.ToString();


        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var DB = _examDbContext.Students.FirstOrDefault(s => s.StudentId == _studntid);


            if (DB != null)
            {
                // Authentication successful, open new window to display student data
                StudentForm studentForm = new StudentForm(DB);
                studentForm.Show();
                this.Hide();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}

