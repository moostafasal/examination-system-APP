
namespace examination_system
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 137);
            label1.Name = "label1";
            label1.Size = new Size(353, 65);
            label1.TabIndex = 0;
            label1.Text = "Your Dgree is :";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe Script", 48F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.MenuHighlight;
            textBox1.Location = new Point(387, 112);
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Horizontal;
            textBox1.Size = new Size(279, 110);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.AccessibleRole = AccessibleRole.Grip;
            button1.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(65, 324);
            button1.Name = "button1";
            button1.Size = new Size(250, 54);
            button1.TabIndex = 2;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.AccessibleRole = AccessibleRole.Grip;
            button3.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(408, 324);
            button3.Name = "button3";
            button3.Size = new Size(250, 54);
            button3.TabIndex = 4;
            button3.Text = "Logout";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "ResultForm";
            Text = "ResultForm";
            Load += ResultForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = _result.ToString();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button3;
    }
}