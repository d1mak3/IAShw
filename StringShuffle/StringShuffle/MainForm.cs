using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringShuffle
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void InputTextBox1_Click(object sender, EventArgs e)
		{
			InputTextBox1.Clear();
		}

		private void InputTextBox2_Click(object sender, EventArgs e)
		{
			InputTextBox2.Clear();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void WorkButton_Click(object sender, EventArgs e)
		{
			if (InputTextBox1.Text == String.Empty || InputTextBox2.Text == String.Empty)
			{
				MessageBox.Show("Одна из строк пуста");
				InputTextBox1.Text = "input 1";
				InputTextBox2.Text = "input 2";
			}

			OutputLabel.Text = Shuffle(InputTextBox1.Text, InputTextBox2.Text);
		}		

		string Shuffle(string input1, string input2)
		{
			string output = String.Empty;
			int count = 0;
			if (input1.Length > input2.Length)
			{
				count = 0;
				while (count < input1.Length)
				{
					output += input1[count];

					if (count < input2.Length)
						output += input2[count];

					++count;
				}

				return output;
			}

			count = 0;
			while (count < input2.Length)
			{
				output += input1[count];

				if (count < input1.Length)
					output += input2[count];

				++count;
			}

			return output;
		}
	}
}
