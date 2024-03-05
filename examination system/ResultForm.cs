using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examination_system
{
    public partial class ResultForm : Form
    {
        private int _result;

        public ResultForm(int result)
        {
            InitializeComponent();
            _result = result;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            // Display the result in the text box
            textBox1.Text = _result.ToString();
        }
    }
}
