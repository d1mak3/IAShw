
namespace first
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.firstDispley = new System.Windows.Forms.Label();
            this.secondDispley = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(12, 45);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Вывести";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(531, 23);
            this.textBox.TabIndex = 1;
            // 
            // firstDispley
            // 
            this.firstDispley.AutoSize = true;
            this.firstDispley.Location = new System.Drawing.Point(12, 71);
            this.firstDispley.Name = "firstDispley";
            this.firstDispley.Size = new System.Drawing.Size(27, 15);
            this.firstDispley.TabIndex = 3;
            this.firstDispley.Text = "first";
            // 
            // secondDispley
            // 
            this.secondDispley.AutoSize = true;
            this.secondDispley.Location = new System.Drawing.Point(12, 86);
            this.secondDispley.Name = "secondDispley";
            this.secondDispley.Size = new System.Drawing.Size(45, 15);
            this.secondDispley.TabIndex = 4;
            this.secondDispley.Text = "second";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(549, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(117, 178);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(672, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(117, 178);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(795, 12);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(117, 178);
            this.richTextBox3.TabIndex = 7;
            this.richTextBox3.Text = "";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(12, 104);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.Size = new System.Drawing.Size(531, 86);
            this.richTextBox5.TabIndex = 9;
            this.richTextBox5.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 192);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.secondDispley);
            this.Controls.Add(this.firstDispley);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label firstDispley;
        private System.Windows.Forms.Label secondDispley;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox5;
    }
}

