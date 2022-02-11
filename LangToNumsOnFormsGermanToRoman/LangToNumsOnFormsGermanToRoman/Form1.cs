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
		string CreateHelpingStringFromDict(Dictionary<string, int> helpingDict)
		{
			string outputString = "";

			int count = 0;
			foreach (KeyValuePair<string, int> p in helpingDict)
			{
				outputString += p.Key + " - " + p.Value + " ";

				if (count == 3)
					outputString += "\n";
			}

			return outputString;
		}

		string CutExtraSpaces(string input)
		{
			for (int i = 0; i < input.Length; ++i)
			{
				if (input[i] == ' ')
				{
					input = input.Remove(i, 1);
					--i;
				}
				else
				{
					break;
				}
			}

			if (input == "")
				return input;

			for (int i = 1; i < input.Length; ++i)
			{ 
				if (input[i] == ' ' && input[i - 1] == ' ')
				{
					input = input.Remove(i, 1);
					--i;
				}
			}

			if (input[input.Length - 1] == ' ')
			{
				input = input.Remove(input.Length - 1, 1);
			}

			return input;
		}

		public Form1()
		{
			InitializeComponent();
			LangConverter dictFromConverter = new LangConverter("");
			HelpingLabel.Text = CreateHelpingStringFromDict(dictFromConverter.GetLangNums());
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void InputButton_Click(object sender, EventArgs e)
		{
			string input = CutExtraSpaces(InputTextBox.Text);
			InputChecker checker = new InputChecker(input);
			
			if (checker.CheckInputForMistakes() == "Ok")
			{
				LangConverter converter = new LangConverter(input);
				OutputLabel.Text = "Число в арабском представлении: " + converter.ConvertToArabic() +
					"\nЧисло в римском представлении: " + converter.ConvertToRoman();
			}
			else			
				OutputLabel.Text = checker.CheckInputForMistakes();			
		}	

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
