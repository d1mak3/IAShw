
namespace StringShuffle
{
	partial class MainForm
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
			this.InputTextBox1 = new System.Windows.Forms.TextBox();
			this.InputTextBox2 = new System.Windows.Forms.TextBox();
			this.OutputLabel = new System.Windows.Forms.Label();
			this.WorkButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// InputTextBox1
			// 
			this.InputTextBox1.Location = new System.Drawing.Point(47, 49);
			this.InputTextBox1.Name = "InputTextBox1";
			this.InputTextBox1.Size = new System.Drawing.Size(272, 26);
			this.InputTextBox1.TabIndex = 0;
			this.InputTextBox1.Click += new System.EventHandler(this.InputTextBox1_Click);
			// 
			// InputTextBox2
			// 
			this.InputTextBox2.Location = new System.Drawing.Point(467, 49);
			this.InputTextBox2.Name = "InputTextBox2";
			this.InputTextBox2.Size = new System.Drawing.Size(272, 26);
			this.InputTextBox2.TabIndex = 1;
			this.InputTextBox2.Click += new System.EventHandler(this.InputTextBox2_Click);
			// 
			// OutputLabel
			// 
			this.OutputLabel.AutoSize = true;
			this.OutputLabel.Location = new System.Drawing.Point(357, 121);
			this.OutputLabel.Name = "OutputLabel";
			this.OutputLabel.Size = new System.Drawing.Size(55, 20);
			this.OutputLabel.TabIndex = 2;
			this.OutputLabel.Text = "Output";
			// 
			// WorkButton
			// 
			this.WorkButton.Location = new System.Drawing.Point(316, 195);
			this.WorkButton.Name = "WorkButton";
			this.WorkButton.Size = new System.Drawing.Size(141, 28);
			this.WorkButton.TabIndex = 3;
			this.WorkButton.Text = "Ok";
			this.WorkButton.UseVisualStyleBackColor = true;
			this.WorkButton.Click += new System.EventHandler(this.WorkButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 281);
			this.Controls.Add(this.WorkButton);
			this.Controls.Add(this.OutputLabel);
			this.Controls.Add(this.InputTextBox2);
			this.Controls.Add(this.InputTextBox1);
			this.Name = "MainForm";
			this.Text = "StringShuffle";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox InputTextBox1;
		private System.Windows.Forms.TextBox InputTextBox2;
		private System.Windows.Forms.Label OutputLabel;
		private System.Windows.Forms.Button WorkButton;
	}
}

