using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LangToNumsOnForms
{
	public partial class Form1 : Form
	{	
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void InputButton_Click(object sender, EventArgs e)
		{
			InputChecker checker = new InputChecker(InputTextBox.Text);
			
			if (checker.CheckInputForMistakes() == "Ok")
			{
				LangConverter converter = new LangConverter(InputTextBox.Text);
				OutputLabel.Text = "Число в арабском представлении: " + converter.ConvertToArabic() +
					"\nЧисло в римском представлении: " + converter.ConvertToRoman();
			}
			else
			{
				OutputLabel.Text = checker.CheckInputForMistakes();
			}
		}		

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
