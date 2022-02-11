
namespace LangToNumsOnForms
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
			this.InputTextBox = new System.Windows.Forms.TextBox();
			this.InputButton = new System.Windows.Forms.Button();
			this.OutputLabel = new System.Windows.Forms.Label();
			this.HelpingLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// InputTextBox
			// 
			this.InputTextBox.Location = new System.Drawing.Point(12, 32);
			this.InputTextBox.Name = "InputTextBox";
			this.InputTextBox.Size = new System.Drawing.Size(496, 26);
			this.InputTextBox.TabIndex = 0;
			// 
			// InputButton
			// 
			this.InputButton.Location = new System.Drawing.Point(541, 30);
			this.InputButton.Name = "InputButton";
			this.InputButton.Size = new System.Drawing.Size(90, 28);
			this.InputButton.TabIndex = 1;
			this.InputButton.Text = "Enter";
			this.InputButton.UseVisualStyleBackColor = true;
			this.InputButton.Click += new System.EventHandler(this.InputButton_Click);
			// 
			// OutputLabel
			// 
			this.OutputLabel.Location = new System.Drawing.Point(12, 84);
			this.OutputLabel.Name = "OutputLabel";
			this.OutputLabel.Size = new System.Drawing.Size(496, 85);
			this.OutputLabel.TabIndex = 2;
			// 
			// HelpingLabel
			// 
			this.HelpingLabel.Location = new System.Drawing.Point(12, 214);
			this.HelpingLabel.Name = "HelpingLabel";
			this.HelpingLabel.Size = new System.Drawing.Size(776, 178);
			this.HelpingLabel.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.HelpingLabel);
			this.Controls.Add(this.OutputLabel);
			this.Controls.Add(this.InputButton);
			this.Controls.Add(this.InputTextBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox InputTextBox;
		private System.Windows.Forms.Button InputButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label OutputLabel;
		private System.Windows.Forms.Label HelpingLabel;
	}
}

