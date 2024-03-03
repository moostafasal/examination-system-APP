using examination_system.DB;

namespace examination_system
{
    public partial class Form1 : Form
    {
        private ExamDbContext _dbContext;

        public Form1()
        {
            InitializeComponent();
            _dbContext = new ExamDbContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; // Fetch text from textBox1 for username
            string password = textBox2.Text; // Fetch text from textBox2 for password

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                // Authenticate user
                var student = _dbContext.Students.FirstOrDefault(s => s.UserName == username && s.Password == password);

                if (student != null)
                {
                    // Authentication successful, open new window to display student data
                    //StudentForm studentForm = new StudentForm(student);
                    //studentForm.Show();
                    this.Hide(); // Hide the current login form
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

  
}
